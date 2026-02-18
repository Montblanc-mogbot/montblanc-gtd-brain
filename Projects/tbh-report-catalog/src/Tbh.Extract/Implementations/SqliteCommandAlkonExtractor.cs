using Microsoft.Data.Sqlite;
using Tbh.Extract.Interfaces;
using Tbh.Extract.Models.CommandAlkon;

namespace Tbh.Extract.Implementations;

/// <summary>
/// SQLite-based extractor for the dummy Command Alkon database.
/// Reads from ORDL, TKTC, and PLNT tables.
/// </summary>
public class SqliteCommandAlkonExtractor : ICommandAlkonExtractor
{
    private static readonly string[] SupportedDateFormats =
    [
        "yyyy-MM-dd HH:mm:ss",
        "yyyy-MM-dd",
    ];

    private readonly string _connectionString;

    public SqliteCommandAlkonExtractor(string databasePath)
    {
        _connectionString = $"Data Source={databasePath}";
    }

    public async Task<IEnumerable<PlantRecord>> ExtractPlantsAsync(CancellationToken cancellationToken = default)
    {
        var plants = new List<PlantRecord>();

        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        // Read from PLNT table
        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT plant_code, comp_code, name, short_name, addr_city, addr_state
            FROM plnt
            ORDER BY plant_code
        ";

        using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            var city = reader.IsDBNull(4) ? null : reader.GetString(4)?.Trim();
            var state = reader.IsDBNull(5) ? null : reader.GetString(5)?.Trim();
            var location = city != null && state != null ? $"{city}, {state}" : null;

            plants.Add(new PlantRecord
            {
                PlantCode = reader.GetString(0)?.Trim() ?? string.Empty,
                CompanyCode = reader.IsDBNull(1) ? null : reader.GetString(1)?.Trim(),
                Name = reader.GetString(2)?.Trim() ?? string.Empty,
                ShortName = reader.GetString(3)?.Trim() ?? string.Empty,
                Location = location
            });
        }

        return plants;
    }

    public async Task<IEnumerable<CustomerRecord>> ExtractCustomersAsync(CancellationToken cancellationToken = default)
    {
        var customers = new List<CustomerRecord>();

        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        // Read from CUST table - filter active customers
        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT cust_code, name, sort_name, addr_line_1, addr_city, addr_state,
                   addr_postcd, phone_num_1, contct_name, setup_date, tax_code, inactive_code
            FROM cust
            WHERE inactive_code IS NULL OR inactive_code = '00'
            ORDER BY name
        ";

        using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            customers.Add(new CustomerRecord
            {
                CustomerCode = reader.GetString(0)?.Trim() ?? string.Empty,
                Name = reader.GetString(1)?.Trim() ?? string.Empty,
                SortName = reader.IsDBNull(2) ? null : reader.GetString(2)?.Trim(),
                AddressLine1 = reader.IsDBNull(3) ? null : reader.GetString(3)?.Trim(),
                City = reader.IsDBNull(4) ? null : reader.GetString(4)?.Trim(),
                State = reader.IsDBNull(5) ? null : reader.GetString(5)?.Trim(),
                PostalCode = reader.IsDBNull(6) ? null : reader.GetString(6)?.Trim(),
                PhoneNumber = reader.IsDBNull(7) ? null : reader.GetString(7)?.Trim(),
                ContactName = reader.IsDBNull(8) ? null : reader.GetString(8)?.Trim(),
                SetupDate = GetDateTime(reader, 9),
                TaxCode = reader.IsDBNull(10) ? null : reader.GetString(10)?.Trim(),
                InactiveCode = reader.IsDBNull(11) ? null : reader.GetString(11)?.Trim()
            });
        }

        return customers;
    }

    public async Task<IEnumerable<ItemMasterRecord>> ExtractItemsAsync(CancellationToken cancellationToken = default)
    {
        var items = new List<ItemMasterRecord>();

        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        // Read from IMST table
        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT item_code, descr, short_descr, item_cat, matl_type,
                   order_uom, price_uom, taxble_code, print_on_tkt_flag, const_flag
            FROM imst
            ORDER BY item_code
        ";

        using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            items.Add(new ItemMasterRecord
            {
                ItemCode = reader.GetString(0)?.Trim() ?? string.Empty,
                Description = reader.IsDBNull(1) ? null : reader.GetString(1)?.Trim(),
                ShortDescription = reader.IsDBNull(2) ? null : reader.GetString(2)?.Trim(),
                ItemCategory = reader.IsDBNull(3) ? null : reader.GetString(3)?.Trim(),
                MaterialType = reader.IsDBNull(4) ? null : reader.GetString(4)?.Trim(),
                OrderUom = reader.IsDBNull(5) ? null : reader.GetString(5)?.Trim(),
                PriceUom = reader.IsDBNull(6) ? null : reader.GetString(6)?.Trim(),
                IsTaxable = !reader.IsDBNull(7) && reader.GetInt32(7) == 1,
                PrintOnTicket = !reader.IsDBNull(8) && reader.GetInt32(8) == 1,
                IsConstructionItem = !reader.IsDBNull(9) && reader.GetInt32(9) == 1
            });
        }

        return items;
    }

    public async Task<IEnumerable<UomRecord>> ExtractUomsAsync(CancellationToken cancellationToken = default)
    {
        var uoms = new List<UomRecord>();

        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT uom, descr, abbr
            FROM uoms
            ORDER BY uom
        ";

        using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            uoms.Add(new UomRecord
            {
                UomCode = reader.IsDBNull(0) ? string.Empty : reader.GetString(0)?.Trim() ?? string.Empty,
                Name = reader.IsDBNull(1) ? null : reader.GetString(1)?.Trim(),
                Abbreviation = reader.IsDBNull(2) ? null : reader.GetString(2)?.Trim(),
            });
        }

        return uoms;
    }

    public async Task<IEnumerable<TicketRecord>> ExtractTicketsAsync(
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        var records = new List<TicketRecord>();

        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT
                order_date,
                order_code,
                tkt_code,
                tkt_date,
                ship_plant_code,
                ship_plant_loc_code,
                truck_code,
                remove_rsn_code,
                invc_flag,
                invc_code,
                invc_date,
                invc_seq_num,
                tkt_status,
                update_date
            FROM tick
            WHERE date(order_date) >= date(@startDate)
              AND date(order_date) < date(@endDate)
            ORDER BY order_date, order_code, tkt_code
        ";

        command.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"));
        command.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"));

        using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            records.Add(new TicketRecord
            {
                OrderDate = GetDateTimeFromText(reader, 0),
                OrderCode = GetString(reader, 1),
                TicketCode = GetString(reader, 2),
                TicketDate = GetDateTimeFromText(reader, 3),
                ShipPlantCode = GetString(reader, 4),
                ShipPlantLocCode = GetString(reader, 5),
                TruckCode = GetString(reader, 6),
                RemoveReasonCode = GetString(reader, 7),
                InvcFlag = GetString(reader, 8),
                InvcCode = GetString(reader, 9),
                InvcDate = GetDateTimeFromText(reader, 10),
                InvcSeqNum = GetIntFromText(reader, 11),
                TicketStatus = GetString(reader, 12),
                UpdateDate = GetDateTimeFromText(reader, 13),
            });
        }

        return records;
    }

    public async Task<IEnumerable<TicketLineRecord>> ExtractTicketLinesAsync(
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        var records = new List<TicketLineRecord>();

        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT
                order_date,
                order_code,
                tkt_code,
                order_intrnl_line_num,
                delv_qty,
                delv_qty_uom,
                ship_plant_code,
                ext_price_amt,
                update_date
            FROM tktl
            WHERE date(order_date) >= date(@startDate)
              AND date(order_date) < date(@endDate)
            ORDER BY order_date, order_code, tkt_code, order_intrnl_line_num
        ";

        command.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"));
        command.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"));

        using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            records.Add(new TicketLineRecord
            {
                OrderDate = GetDateTimeFromText(reader, 0),
                OrderCode = GetString(reader, 1),
                TicketCode = GetString(reader, 2),
                OrderInternalLineNum = GetIntFromText(reader, 3),
                DeliveredQty = GetDecimalFromText(reader, 4),
                DeliveredQtyUom = GetString(reader, 5),
                ShipPlantCode = GetString(reader, 6),
                ExtendedPriceAmount = GetDecimalFromText(reader, 7),
                UpdateDate = GetDateTimeFromText(reader, 8),
            });
        }

        return records;
    }

    public async Task<IEnumerable<TicketChargeRecord>> ExtractTicketChargesAsync(
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        var records = new List<TicketChargeRecord>();

        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT
                order_date,
                order_code,
                tkt_code,
                tkt_chrg_code,
                delv_qty,
                delv_qty_uom,
                ext_price_amt,
                update_date
            FROM tktc
            WHERE date(order_date) >= date(@startDate)
              AND date(order_date) < date(@endDate)
            ORDER BY order_date, order_code, tkt_code, tkt_chrg_intrnl_line_num
        ";

        command.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"));
        command.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"));

        using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            records.Add(new TicketChargeRecord
            {
                OrderDate = GetDateTimeFromText(reader, 0),
                OrderCode = GetString(reader, 1),
                TicketCode = GetString(reader, 2),
                TicketChargeCode = GetString(reader, 3),
                DeliveredQty = GetDecimalFromText(reader, 4),
                DeliveredQtyUom = GetString(reader, 5),
                ExtendedPriceAmount = GetDecimalFromText(reader, 6),
                UpdateDate = GetDateTimeFromText(reader, 7),
            });
        }

        return records;
    }

    public async Task<IEnumerable<OrderHeaderRecord>> ExtractOrdersAsync(
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        var records = new List<OrderHeaderRecord>();

        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT
                order_date,
                order_code,
                prod_line_code,
                cust_code,
                cust_name,
                ship_to_plant_code,
                zone_code,
                proj_code,
                update_date
            FROM ordr
            WHERE date(order_date) >= date(@startDate)
              AND date(order_date) < date(@endDate)
            ORDER BY order_date, order_code
        ";

        command.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"));
        command.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"));

        using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            records.Add(new OrderHeaderRecord
            {
                OrderDate = GetDateTimeFromText(reader, 0),
                OrderCode = GetString(reader, 1),
                ProductLineCode = GetString(reader, 2),
                CustomerCode = GetString(reader, 3),
                CustomerName = GetString(reader, 4),
                ShipToPlantCode = GetString(reader, 5),
                ZoneCode = GetString(reader, 6),
                ProjectCode = GetString(reader, 7),
                UpdateDate = GetDateTimeFromText(reader, 8),
            });
        }

        return records;
    }

    public async Task<IEnumerable<ItrnRecord>> ExtractItrnAsync(
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        var records = new List<ItrnRecord>();

        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        // ITRN export was imported as a raw table with TEXT columns.
        // Filter by trans_date when present.
        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT
                batch_date,
                batch_num,
                batch_seq,
                unique_num,
                cust_code,
                ship_cust_code,
                trans_type,
                trans_date,
                plant_code,
                comp_code,
                invc_code,
                ar_adj_code,
                pretax_amt,
                tax_amt,
                pmt_amt,
                check_amt,
                cost_amt,
                po,
                proj_code,
                modified_date
            FROM itrn
            WHERE trans_date IS NOT NULL
              AND date(trans_date) >= date(@startDate)
              AND date(trans_date) < date(@endDate)
            ORDER BY trans_date, invc_code
        ";

        command.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"));
        command.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"));

        using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            records.Add(new ItrnRecord
            {
                BatchDate = GetDateTimeFromText(reader, 0),
                BatchNum = GetString(reader, 1),
                BatchSeq = GetString(reader, 2),
                UniqueNum = GetString(reader, 3),
                CustomerCode = GetString(reader, 4),
                ShipCustomerCode = GetString(reader, 5),
                TransactionType = GetString(reader, 6),
                TransactionDate = GetDateTimeFromText(reader, 7),
                PlantCode = GetString(reader, 8),
                CompanyCode = GetString(reader, 9),
                InvoiceCode = GetString(reader, 10),
                ArAdjustmentCode = GetString(reader, 11),
                PretaxAmount = GetDecimalFromText(reader, 12),
                TaxAmount = GetDecimalFromText(reader, 13),
                PaymentAmount = GetDecimalFromText(reader, 14),
                CheckAmount = GetDecimalFromText(reader, 15),
                CostAmount = GetDecimalFromText(reader, 16),
                Po = GetString(reader, 17),
                ProjectCode = GetString(reader, 18),
                ModifiedDate = GetDateTimeFromText(reader, 19),
            });
        }

        return records;
    }

    public async Task<IEnumerable<ArtbRecord>> ExtractArtbAsync(
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        var records = new List<ArtbRecord>();

        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT
                cust_code,
                item_ref_code,
                trans_date,
                prim_trans_type,
                due_date,
                latest_pmt_date,
                curr_bal_amt,
                sales_amt,
                tax_amt
            FROM artb
            WHERE trans_date IS NOT NULL
              AND date(trans_date) >= date(@startDate)
              AND date(trans_date) < date(@endDate)
            ORDER BY trans_date, item_ref_code
        ";

        command.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"));
        command.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"));

        using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            records.Add(new ArtbRecord
            {
                CustomerCode = GetString(reader, 0),
                InvoiceCode = GetString(reader, 1),
                TransactionDate = GetDateTimeFromText(reader, 2),
                PrimaryTransactionType = GetString(reader, 3),
                DueDate = GetDateTimeFromText(reader, 4),
                LatestPaymentDate = GetDateTimeFromText(reader, 5),
                CurrentBalanceAmount = GetDecimalFromText(reader, 6),
                SalesAmount = GetDecimalFromText(reader, 7),
                TaxAmount = GetDecimalFromText(reader, 8),
            });
        }

        return records;
    }

    public async Task<IEnumerable<SalesDetailRecord>> ExtractSalesDetailAsync(
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        var records = new List<SalesDetailRecord>();

        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        // Query ORDL (Order Detail) with plant from PLNT
        // Default to plant 1 (WRM - Westminster) for now since ORDL doesn't have plant codes
        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT 
                order_date,
                order_code,
                order_intrnl_line_num,
                prod_code,
                prod_descr,
                short_prod_descr,
                price,
                price_uom,
                order_qty,
                delv_qty,
                delv_qty_uom,
                usage_code,
                update_date
            FROM ordl
            WHERE date(order_date) >= date(@startDate) 
              AND date(order_date) < date(@endDate)
            ORDER BY order_date, order_code
        ";

        command.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"));
        command.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"));

        using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            records.Add(MapOrderDetail(reader));
        }

        return records;
    }

    public async Task ExportSalesDetailToCsvAsync(
        DateTime startDate,
        DateTime endDate,
        string outputPath,
        CancellationToken cancellationToken = default)
    {
        var records = await ExtractSalesDetailAsync(startDate, endDate, cancellationToken);

        var lines = new List<string>
        {
            "OrderDate,Plant,OrderCode,ItemCode,ItemDescription,DeliveryQuantity,Price,ExtendedAmount"
        };

        foreach (var r in records)
        {
            var extAmt = (r.DeliveryQuantity ?? 0) * (r.ExtendedPriceAmount ?? 0);
            lines.Add($"{r.OrderDate:yyyy-MM-dd},{r.ShipPlantCode},{r.OrderCode},{r.ItemCode},{r.ItemType},{r.DeliveryQuantity},{r.ExtendedPriceAmount},{extAmt:F2}");
        }

        await File.WriteAllLinesAsync(outputPath, lines, cancellationToken);
    }

    private static SalesDetailRecord MapOrderDetail(SqliteDataReader r)
    {
        var orderDate = GetDateTime(r, 0);
        var delvQty = GetDecimal(r, 9) ?? 0;
        var price = GetDecimal(r, 6) ?? 0;

        return new SalesDetailRecord
        {
            OrderDate = orderDate,
            OrderCode = GetString(r, 1),
            TicketCode = $"{GetString(r, 1)}-{GetDecimal(r, 2):F0}",
            TicketDate = orderDate,
            // Default to Plant 1 (WRM - Westminster) since ORDL doesn't have plant codes
            // This will be refined when we understand usage_code to plant mapping
            ShipPlantCode = "1",
            ShipCompanyCode = "1",
            PricePlantCode = "1",
            PriceCompanyCode = "1",
            CustomerCode = "CUST",
            ItemCode = GetString(r, 3),
            ItemType = GetString(r, 5),
            DeliveryQuantity = delvQty,
            DeliveryQuantityUom = GetString(r, 10),
            PriceQuantity = delvQty,
            ExtendedPriceAmount = delvQty * price,
            ExtendedMaterialCostAmount = null,
            UpdateDate = GetDateTime(r, 12),
        };
    }

    private static DateTime? GetDateTime(SqliteDataReader r, int i) =>
        r.IsDBNull(i) ? null : r.GetDateTime(i);

    private static string? GetString(SqliteDataReader r, int i) =>
        r.IsDBNull(i) ? null : r.GetString(i)?.Trim();

    private static decimal? GetDecimal(SqliteDataReader r, int i) =>
        r.IsDBNull(i) ? null : (decimal)r.GetDouble(i);

    private static DateTime? GetDateTimeFromText(SqliteDataReader r, int i)
    {
        var s = GetString(r, i);
        if (string.IsNullOrWhiteSpace(s)) return null;
        if (DateTime.TryParseExact(s.Trim(), SupportedDateFormats, System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.AssumeLocal, out var dt))
        {
            return dt;
        }
        if (DateTime.TryParse(s.Trim(), out var fallback)) return fallback;
        return null;
    }

    private static int? GetIntFromText(SqliteDataReader r, int i)
    {
        var s = GetString(r, i);
        if (string.IsNullOrWhiteSpace(s)) return null;
        return int.TryParse(s.Trim(), out var n) ? n : null;
    }

    private static decimal? GetDecimalFromText(SqliteDataReader r, int i)
    {
        var s = GetString(r, i);
        if (string.IsNullOrWhiteSpace(s)) return null;
        return decimal.TryParse(s.Trim(), out var n) ? n : null;
    }
}
