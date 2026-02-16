===== NON-EMPTY BASE TABLES =====

## Table: dbo.acat
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| acct_cat_code | char | No | 4 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| invc_doc_fmt_group_code | char | Yes | 8 |
| cred_memo_doc_fmt_group_code | char | Yes | 8 |
| debit_memo_doc_fmt_group_code | char | Yes | 8 |
| recpt_doc_fmt_group_code | char | Yes | 8 |
| next_invc_seq | char | Yes | 3 |
| next_cred_memo_seq | char | Yes | 3 |
| next_debit_memo_seq | char | Yes | 3 |
| next_recpt_seq | char | Yes | 3 |
| book_tax_sep_flag | bit | Yes |  |
| sep_cust_code | char | Yes | 10 |
| sep_adj_code | char | Yes | 3 |
| gov_cust_flag | bit | Yes |  |
| sep_pretax_tax_invc_flag | bit | Yes |  |
| tax_invc_flag | bit | Yes |  |
| tax_invc_seq | char | Yes | 3 |
| tax_invc_doc_fmt_group_code | char | Yes | 8 |
| tkt_overrun_doc_fmt_group_code | char | Yes | 8 |
| lang | char | Yes | 3 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.acct
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| acct_code | char | No | 6 |
| sub_acct_code | char | No | 6 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| sum_flag | char | Yes | 1 |
| acct_type | char | Yes | 2 |
| acct_sign | char | Yes | 1 |
| limit_cost_center_flag | bit | Yes |  |
| src_code_01 | char | Yes | 2 |
| src_code_02 | char | Yes | 2 |
| src_code_03 | char | Yes | 2 |
| src_code_04 | char | Yes | 2 |
| src_code_05 | char | Yes | 2 |
| src_code_06 | char | Yes | 2 |
| src_code_07 | char | Yes | 2 |
| src_code_08 | char | Yes | 2 |
| src_code_09 | char | Yes | 2 |
| src_code_10 | char | Yes | 2 |
| updt_flag_01 | char | Yes | 1 |
| updt_flag_02 | char | Yes | 1 |
| updt_flag_03 | char | Yes | 1 |
| updt_flag_04 | char | Yes | 1 |
| updt_flag_05 | char | Yes | 1 |
| updt_flag_06 | char | Yes | 1 |
| updt_flag_07 | char | Yes | 1 |
| updt_flag_08 | char | Yes | 1 |
| updt_flag_09 | char | Yes | 1 |
| updt_flag_10 | char | Yes | 1 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.acty
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| acct_type | char | No | 2 |
| descr | char | No | 40 |
| acct_class | char | Yes | 1 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.addl
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| file_name | char | No | 4 |
| key_field | char | No | 64 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.adio
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| rec_code | char | No | 3 |
| descr | char | Yes | 40 |
| short_descr | char | Yes | 8 |
| proc_type_code | char | Yes | 2 |
| mgr_num | numeric | Yes |  |
| strt_time | datetime | Yes |  |
| end_time | datetime | Yes |  |
| log_file_flag | bit | Yes |  |
| log_det_flag | bit | Yes |  |
| file_name | char | Yes | 4 |
| intfc_file_name | char | Yes | 128 |
| doc_fmt_group_code | char | Yes | 8 |
| tkt_intfc_file_name | char | Yes | 32 |
| tkt_doc_fmt_group_code | char | Yes | 8 |
| incl_remove_flag | bit | Yes |  |
| incl_susp_flag | bit | Yes |  |
| prod_line_code | char | Yes | 2 |
| use_standing_order_flag | bit | Yes |  |
| create_sundry_chrg_flag | bit | Yes |  |
| prefix_plant_code_flag | bit | Yes |  |
| replace_dupl_flag | bit | Yes |  |
| export_order_type | char | Yes | 1 |
| export_stndng_order_type | char | Yes | 1 |
| replc_dupl_tkt_flag | bit | Yes |  |
| log_code | char | Yes | 2 |
| conv_qty_system_uom_flag | bit | Yes |  |
| proc_subtype_code | char | Yes | 1 |
| invc_exported_tkt_flag | bit | Yes |  |
| proc_interval_code | char | Yes | 2 |
| day_to_proc_code | char | Yes | 2 |
| num_days_back_code | numeric | Yes |  |
| num_days_include_code | numeric | Yes |  |
| report_type | char | Yes | 2 |
| report_seq | char | Yes | 2 |
| cust_code_from | char | Yes | 10 |
| cust_code_to | char | Yes | 10 |
| acc_cat_from | char | Yes | 4 |
| acc_cat_to | char | Yes | 4 |
| comp_code_from | char | Yes | 4 |
| comp_code_to | char | Yes | 4 |
| price_plant_from | char | Yes | 3 |
| price_plant_to | char | Yes | 3 |
| invoice_date_offset | numeric | Yes |  |
| message_code | char | Yes | 4 |
| incl_rel_order_tkt_flag | bit | Yes |  |
| pmt_type_list | char | Yes | 80 |
| calc_unld_by_tkt_code | char | Yes | 2 |
| generate_order_code | char | Yes | 2 |
| separate | char | Yes | 2 |
| incl_intf_tkts_code | char | Yes | 2 |
| tickets_to_include | char | Yes | 1 |
| incl_intf_ordrs_flag | bit | Yes |  |
| output_type | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| plant_code_list | varchar | Yes | 2000 |
| comp_code_list | varchar | Yes | 200 |
| order_type_list | varchar | Yes | 200 |
| pmt_meth_list | varchar | Yes | 200 |
| cust_code_list | varchar | Yes | 2000 |

## Table: dbo.ajcd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| adj_code | char | No | 3 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| invc_print | bit | Yes |  |
| write_off_adj | bit | Yes |  |
| prepay_adj | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.arhd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| batch_date | datetime | No |  |
| batch_num | numeric | No |  |
| next_batch_seq | numeric | Yes |  |
| trans_type | numeric | Yes |  |
| comp_code | char | Yes | 4 |
| user_name | char | Yes | 20 |
| plant_code | char | Yes | 3 |
| bank_code | char | Yes | 3 |
| begin_cut_date | datetime | Yes |  |
| end_cut_date | datetime | Yes |  |
| text | char | Yes | 120 |
| batch_stat | numeric | Yes |  |
| ctrl_finc_chrg_amt | numeric | Yes |  |
| compt_finc_chrg_amt | numeric | Yes |  |
| ctrl_adj_amt | numeric | Yes |  |
| compt_adj_amt | numeric | Yes |  |
| ctrl_pretax_amt | numeric | Yes |  |
| ctrl_assgn_amt | numeric | Yes |  |
| compt_assgn_amt | numeric | Yes |  |
| ctrl_pmt_amt | numeric | Yes |  |
| compt_pmt_amt | numeric | Yes |  |
| ctrl_misc_pmt_amt | numeric | Yes |  |
| compt_misc_pmt_amt | numeric | Yes |  |
| compt_pretax_amt | numeric | Yes |  |
| ctrl_disc_allowed_amt | numeric | Yes |  |
| compt_disc_allowed_amt | numeric | Yes |  |
| ctrl_disc_taken_amt | numeric | Yes |  |
| compt_disc_taken_amt | numeric | Yes |  |
| ctrl_retain_amt | numeric | Yes |  |
| compt_retain_amt | numeric | Yes |  |
| ctrl_tax_amt | numeric | Yes |  |
| compt_tax_amt | numeric | Yes |  |
| sales_acct_code | char | Yes | 6 |
| sales_sub_acct_code | char | Yes | 6 |
| cash_acct_code | char | Yes | 6 |
| cash_sub_acct_code | char | Yes | 6 |
| ar_acct_code | char | Yes | 6 |
| ar_sub_acct_code | char | Yes | 6 |
| retain_acct_code | char | Yes | 6 |
| retain_sub_acct_code | char | Yes | 6 |
| disc_allowed_acct_code | char | Yes | 6 |
| disc_allowed_sub_acct_code | char | Yes | 6 |
| disc_taken_acct_code | char | Yes | 6 |
| disc_taken_sub_acct_code | char | Yes | 6 |
| tax_acct_code | char | Yes | 6 |
| tax_sub_acct_code | char | Yes | 6 |
| rel_date_time | datetime | Yes |  |
| post_date_time | datetime | Yes |  |
| created_by_invc_flag | bit | Yes |  |
| source | char | Yes | 2 |
| source_file_loc | char | Yes | 128 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.arpd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| acctng_year | numeric | No |  |
| acctng_perds | numeric | Yes |  |
| perd_begin_date_01 | datetime | Yes |  |
| perd_begin_date_02 | datetime | Yes |  |
| perd_begin_date_03 | datetime | Yes |  |
| perd_begin_date_04 | datetime | Yes |  |
| perd_begin_date_05 | datetime | Yes |  |
| perd_begin_date_06 | datetime | Yes |  |
| perd_begin_date_07 | datetime | Yes |  |
| perd_begin_date_08 | datetime | Yes |  |
| perd_begin_date_09 | datetime | Yes |  |
| perd_begin_date_10 | datetime | Yes |  |
| perd_begin_date_11 | datetime | Yes |  |
| perd_begin_date_12 | datetime | Yes |  |
| perd_begin_date_13 | datetime | Yes |  |
| perd_end_date_01 | datetime | Yes |  |
| perd_end_date_02 | datetime | Yes |  |
| perd_end_date_03 | datetime | Yes |  |
| perd_end_date_04 | datetime | Yes |  |
| perd_end_date_05 | datetime | Yes |  |
| perd_end_date_06 | datetime | Yes |  |
| perd_end_date_07 | datetime | Yes |  |
| perd_end_date_08 | datetime | Yes |  |
| perd_end_date_09 | datetime | Yes |  |
| perd_end_date_10 | datetime | Yes |  |
| perd_end_date_11 | datetime | Yes |  |
| perd_end_date_12 | datetime | Yes |  |
| perd_end_date_13 | datetime | Yes |  |
| perd_open_01 | bit | Yes |  |
| perd_open_02 | bit | Yes |  |
| perd_open_03 | bit | Yes |  |
| perd_open_04 | bit | Yes |  |
| perd_open_05 | bit | Yes |  |
| perd_open_06 | bit | Yes |  |
| perd_open_07 | bit | Yes |  |
| perd_open_08 | bit | Yes |  |
| perd_open_09 | bit | Yes |  |
| perd_open_10 | bit | Yes |  |
| perd_open_11 | bit | Yes |  |
| perd_open_12 | bit | Yes |  |
| perd_open_13 | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.artb
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| item_ref_code | char | No | 12 |
| ship_cust_code | char | Yes | 10 |
| ref_cust_code | char | Yes | 10 |
| sort_name | char | Yes | 8 |
| trans_date | datetime | Yes |  |
| prim_trans_type | numeric | Yes |  |
| comp_code | char | Yes | 4 |
| plant_code | char | Yes | 3 |
| proj_code | char | Yes | 12 |
| ar_aging_date | datetime | Yes |  |
| due_date | datetime | Yes |  |
| disc_date | datetime | Yes |  |
| latest_pmt_date | datetime | Yes |  |
| curr_bal_amt | numeric | Yes |  |
| disc_allowed_amt | numeric | Yes |  |
| disc_allowed_tax_amt | numeric | Yes |  |
| slsmn_empl_code | char | Yes | 12 |
| sales_amt | numeric | Yes |  |
| cred_memo_amt | numeric | Yes |  |
| cred_memo_tax_amt | numeric | Yes |  |
| debit_memo_amt | numeric | Yes |  |
| debit_memo_tax_amt | numeric | Yes |  |
| pmt_amt | numeric | Yes |  |
| adj_amt | numeric | Yes |  |
| assgn_amt | numeric | Yes |  |
| tax_amt | numeric | Yes |  |
| tax_adj_amt | numeric | Yes |  |
| finc_chrg_amt | numeric | Yes |  |
| disc_taken_amt | numeric | Yes |  |
| disc_taken_tax_amt | numeric | Yes |  |
| retain_amt | numeric | Yes |  |
| retain_tax_amt | numeric | Yes |  |
| po | char | Yes | 24 |
| cust_job_num | char | Yes | 24 |
| lot_block | char | Yes | 10 |
| ar_rsn_code | char | Yes | 3 |
| stmnt_sort_code | char | Yes | 13 |
| acct_cat_code | char | Yes | 4 |
| cross_ref_invc_code | char | Yes | 12 |
| tax_invc_code | char | Yes | 12 |
| delv_addr | char | Yes | 40 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.audo
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_date | datetime | No |  |
| order_code | char | No | 12 |
| audit_log_date | datetime | No |  |
| audit_log_time | datetime | No |  |
| user_name | char | Yes | 20 |
| audit_log | char | Yes | 887 |
| prev_value_1 | char | Yes | 2000 |
| curr_value_1 | char | Yes | 2000 |
| cust_initiated_change_code | char | Yes | 2 |
| rsn_code | char | Yes | 3 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| orig_order_info | varchar | Yes | -1 |
| prev_value_2 | varchar | Yes | -1 |
| curr_value_2 | varchar | Yes | -1 |

## Table: dbo.audt
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| audit_date | datetime | No |  |
| audit_time | datetime | No |  |
| file_name | char | No | 5 |
| key_value | char | No | 60 |
| unique_line_num | numeric | No |  |
| audit_type | numeric | Yes |  |
| user_name | char | Yes | 20 |
| form | char | Yes | 40 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| prev_value | varchar | Yes | 2000 |
| curr_value | varchar | Yes | 2000 |
| order_chng_log | varchar | Yes | 2000 |

## Table: dbo.bact
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| appl_code | numeric | No |  |
| batch_date | datetime | No |  |
| batch_num | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.bkcd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| bank_code | char | No | 3 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| fed_routing_num | char | Yes | 12 |
| bank_acct_num | char | Yes | 20 |
| comp_code | char | Yes | 4 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.ccon
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| contct_code | char | No | 12 |
| unique_num | numeric | No |  |
| contct_type | char | Yes | 2 |
| primary_flag | bit | Yes |  |
| mob_tkt_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.clap
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| intrnl_line_num | numeric | No |  |
| assoc_prod_code | char | No | 12 |
| sort_line_num | numeric | Yes |  |
| prod_descr | char | Yes | 40 |
| short_prod_descr | char | Yes | 16 |
| price | numeric | Yes |  |
| price_uom | char | Yes | 5 |
| price_ext_code | char | Yes | 1 |
| effect_date | datetime | Yes |  |
| prev_price | numeric | Yes |  |
| prev_price_ext_code | char | Yes | 1 |
| est_qty | numeric | Yes |  |
| dflt_load_qty | numeric | Yes |  |
| price_in_mix_price_flag | bit | Yes |  |
| order_qty_uom | char | Yes | 5 |
| order_qty_ext_code | char | Yes | 1 |
| order_dosage_qty | numeric | Yes |  |
| order_dosage_qty_uom | char | Yes | 5 |
| delv_qty_uom | char | Yes | 5 |
| price_qty_ext_code | char | Yes | 1 |
| tkt_qty_ext_code | char | Yes | 1 |
| per_cem_wgt_divisor | numeric | Yes |  |
| quote_code | char | Yes | 15 |
| allow_price_adjust_flag | bit | Yes |  |
| sep_invc_flag | bit | Yes |  |
| modified_date | datetime | Yes |  |
| auth_user_name | char | Yes | 20 |
| price_status | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| price_expir_date | datetime | Yes |  |

## Table: dbo.cmct
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| mgr_num | numeric | No |  |
| mgr_name | char | Yes | 60 |
| process_id | char | Yes | 15 |
| computer_name | char | Yes | 50 |
| ip_address | char | Yes | 20 |
| status | char | Yes | 3 |
| prompt_type | char | Yes | 3 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cmdsig_alert_alerttype
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| AlertTypeID | int | No |  |
| AlertType | nvarchar | No | 50 |

## Table: dbo.cmdsig_alert_notification
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| NotificationID | int | No |  |
| NotificationMethod | nvarchar | No | 50 |

## Table: dbo.cmdsig_alert_priority
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| AlertPriorityID | int | No |  |
| AlertPriority | nvarchar | No | 50 |

## Table: dbo.cmdsig_error_log
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cmdsig_error_log_id | numeric | No |  |
| trans_id | varchar | No | 38 |
| trace_date_time | datetime | No |  |
| error_type | varchar | Yes | 6 |
| error_level | varchar | Yes | 3 |
| error_code | numeric | Yes |  |
| error_text | varchar | Yes | 128 |
| error_line_num | varchar | Yes | 10 |
| truck_code | varchar | Yes | 10 |
| veh_radio_code | varchar | Yes | 16 |
| tkt_code | varchar | Yes | 8 |
| tkt_date | datetime | Yes |  |
| cmdsig_trace_log_id | numeric | Yes |  |
| TIME_STAMP | datetime | Yes |  |

## Table: dbo.cmdsig_jbus_pid
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| pid | numeric | No |  |
| mid | numeric | No |  |
| pid_desc | varchar | No | 50 |
| sign | varchar | Yes | 1 |
| scaling_factor_eng | numeric | Yes |  |
| scaling_factor_met | numeric | Yes |  |
| units_eng | varchar | Yes | 6 |
| units_met | varchar | Yes | 6 |
| default_label | varchar | Yes | 6 |
| MIN_RANGE_ENG | numeric | Yes |  |
| MAX_RANGE_ENG | numeric | Yes |  |
| MIN_RANGE_MET | numeric | Yes |  |
| MAX_RANGE_MET | numeric | Yes |  |

## Table: dbo.cmdsig_jbus_thres_template_dtl
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cmdsig_jbus_thres_template_id | numeric | No |  |
| entry_index | numeric | No |  |
| pid | numeric | Yes |  |
| mid | numeric | Yes |  |
| threshold_value | numeric | Yes |  |
| direction | varchar | Yes | 1 |
| trigger_delay | numeric | Yes |  |
| retrigger_delay | numeric | Yes |  |
| precision | numeric | Yes |  |
| label | varchar | Yes | 6 |
| is_english_units | char | Yes | 1 |

## Table: dbo.cmdsig_jbus_thres_template_hdr
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cmdsig_jbus_thres_template_id | numeric | No |  |
| template_name | varchar | No | 30 |
| created_date_time | datetime | Yes |  |
| updated_date_time | datetime | Yes |  |

## Table: dbo.cmdsig_status_lookup
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| trans_type | varchar | No | 3 |
| trans_sub_type | varchar | No | 3 |
| description | varchar | Yes | 128 |

## Table: dbo.cmdsig_trans_type_description
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| trans_type | varchar | No | 3 |
| description | varchar | Yes | 128 |

## Table: dbo.cmdsig_transaction_log
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cmdsig_transaction_log_id | numeric | No |  |
| trans_id | varchar | No | 38 |
| trans_date_time | datetime | No |  |
| tkt_code | varchar | Yes | 8 |
| tkt_date | datetime | Yes |  |
| date_time_offset | numeric | Yes |  |
| veh_radio_code | varchar | Yes | 16 |
| veh_ipaddr | varchar | Yes | 15 |
| veh_fleet_code | varchar | Yes | 4 |
| veh_group_code | varchar | Yes | 4 |
| signl_unit_num | varchar | Yes | 3 |
| target_unit_type | varchar | Yes | 3 |
| protocol_version | varchar | Yes | 3 |
| truck_code | varchar | Yes | 10 |
| employee_code | varchar | Yes | 12 |
| trans_qty | varchar | Yes | 10 |
| trans_qty_uom | varchar | Yes | 5 |
| trans_value | varchar | Yes | 10 |
| trans_value_uom | varchar | Yes | 5 |
| message_string | varchar | Yes | 1024 |
| trans_cat | varchar | Yes | 4 |
| trans_type | varchar | Yes | 3 |
| trans_sub_type | varchar | Yes | 3 |
| trans_origin | varchar | Yes | 3 |
| trans_origin_ipaddr | varchar | Yes | 25 |
| trans_origin_machname | varchar | Yes | 32 |
| trans_origin_username | varchar | Yes | 25 |
| time_to_live | numeric | Yes |  |
| edx_message_string | varchar | Yes | 4000 |
| mix_information | varchar | Yes | 1024 |
| order_date | datetime | Yes |  |
| order_code | varchar | Yes | 12 |
| ship_plant_code | varchar | Yes | 3 |
| prod_line_code | varchar | Yes | 2 |
| TIME_STAMP | datetime | Yes |  |

## Table: dbo.cmdsig_transaction_messages
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| gps_update_required | char | No | 1 |
| cmdsig_transaction_messages_id | numeric | No |  |
| veh_radio_code | varchar | No | 16 |
| trans_id | varchar | No | 38 |
| vehicle_ack_required | char | No | 1 |
| driver_ack_required | char | No | 1 |
| edx_message_string | varchar | Yes | 4000 |
| trans_date_time | datetime | Yes |  |
| tkt_code | varchar | Yes | 8 |
| tkt_date | datetime | Yes |  |
| driver_ack | datetime | Yes |  |
| vehicle_ack | datetime | Yes |  |
| message_string | varchar | Yes | 512 |
| msg_retries | numeric | Yes |  |
| truck_code | varchar | Yes | 10 |
| msg_text | varchar | Yes | 128 |
| created_datetime | datetime | Yes |  |
| updated_datetime | datetime | Yes |  |

## Table: dbo.cmdsig_version
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| id | int | No |  |
| upgrade_date_time | datetime | No |  |
| upgrade_log | text | Yes | 2147483647 |
| db_version | varchar | Yes | 15 |

## Table: dbo.cmdsig_vsc_settings
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| vsc_settings_id | int | No |  |
| truck_code | char | No | 10 |
| vsc_type_id | int | No |  |
| vsc_type_value | int | No |  |
| posted_datetime | datetime | Yes |  |
| sent_datetime | datetime | Yes |  |
| ack_datetime | datetime | Yes |  |
| ack_nack | bit | Yes |  |
| packet_sequence | nvarchar | Yes | 255 |

## Table: dbo.cmdsig_vsc_settings_type
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| vsc_type_id | int | No |  |
| vsc_type_desc | nvarchar | No | 50 |
| vsc_type_default | int | No |  |
| vsc_type_allowableformat | nvarchar | No | 50 |
| vsc_type_length | int | No |  |

## Table: dbo.cnf0
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| key_field | char | No | 1 |
| lab_loc_code | char | Yes | 4 |
| constant_cubic_ft_lbs | numeric | Yes |  |
| constant_us_gals_lbs | numeric | Yes |  |
| show_order_sel_flag | char | Yes | 2 |
| auto_tkting_copy_code | char | Yes | 2 |
| agg_tkting_copy_ordr | char | Yes | 2 |
| gross_wgt_diff_qty | numeric | Yes |  |
| gross_wgt_diff_qty_uom | char | Yes | 5 |
| ca_truck_track_order_qty | numeric | Yes |  |
| cb_truck_track_order_qty | numeric | Yes |  |
| cc_truck_track_order_qty | numeric | Yes |  |
| cd_truck_track_order_qty | numeric | Yes |  |
| track_plant_line_convert_code | numeric | Yes |  |
| sched_adj_code | char | Yes | 1 |
| req_order_qty | char | Yes | 1 |
| ca_truck_track_plant_qty | numeric | Yes |  |
| cc_truck_track_plant_qty | numeric | Yes |  |
| cd_truck_track_plant_qty | numeric | Yes |  |
| cb_truck_track_plant_qty | numeric | Yes |  |
| ca_show_delv_meth | char | Yes | 2 |
| cb_show_delv_meth | char | Yes | 2 |
| cc_show_delv_meth | char | Yes | 2 |
| cd_show_delv_meth | char | Yes | 2 |
| adjust_current_tkt_code | char | Yes | 1 |
| cc_newassgn_msg_timing_code | numeric | Yes |  |
| ca_newassgn_msg_timing_code | numeric | Yes |  |
| cb_newassgn_msg_timing_code | numeric | Yes |  |
| cd_newassgn_msg_timing_code | numeric | Yes |  |
| cc_newassgn_msg_freq_code | numeric | Yes |  |
| ca_newassgn_msg_freq_code | numeric | Yes |  |
| cb_newassgn_msg_freq_code | numeric | Yes |  |
| cd_newassgn_msg_freq_code | numeric | Yes |  |
| display_notes_line | char | Yes | 2 |
| notes_order_code | char | Yes | 2 |
| notes_order_auto_disp_code | char | Yes | 2 |
| notes_tkt_code | char | Yes | 2 |
| notes_tkt_auto_disp_code | char | Yes | 2 |
| notes_batch_code | char | Yes | 2 |
| orders_ship_to_plant_dflt_code | char | Yes | 2 |
| display_ship_to_plant_code | char | Yes | 1 |
| min_max_slump_code | char | Yes | 1 |
| slump_by_loc_code | char | Yes | 1 |
| require_slump_ordr_tkt | char | Yes | 1 |
| slump_modifier_label | char | Yes | 16 |
| ascii_character_filter | char | Yes | 2 |
| proj_sundry_override_flag | char | Yes | 2 |
| batch_non_mix_orders_code | char | Yes | 2 |
| cc_truck_track_dual_timer_mins | numeric | Yes |  |
| restrict_order_to_job | char | Yes | 2 |
| restrict_order_to_plant | char | Yes | 2 |
| restrict_ticket_to_job | char | Yes | 2 |
| restrict_ticket_to_plant | char | Yes | 2 |
| submittal_service_location | char | Yes | 100 |
| qc_server_name | char | Yes | 50 |
| qc_database_name | char | Yes | 50 |
| product_updates_site | char | Yes | 50 |
| dflt_freight_amt_cart_code | char | Yes | 3 |
| freight_amt_cart_code | char | Yes | 3 |
| ca_dflt_sched_plant_code | char | Yes | 1 |
| cc_dflt_sched_plant_code | char | Yes | 1 |
| delay_per_email | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cnf1
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| key_field | char | No | 1 |
| audit_file_chng | char | Yes | 1 |
| audit_post | bit | Yes |  |
| order_chng_log_flag | bit | Yes |  |
| system_name | char | Yes | 40 |
| imperial_flag | bit | Yes |  |
| use_mult_cust_flag | bit | Yes |  |
| dflt_date_fmt | numeric | Yes |  |
| dflt_date_order | numeric | Yes |  |
| dflt_lang | char | Yes | 3 |
| dflt_prim_curr_code | char | Yes | 4 |
| dflt_rptng_curr_code | char | Yes | 4 |
| dflt_acct_cat_code | char | Yes | 4 |
| dflt_ar_cred_empl_code | char | Yes | 12 |
| dflt_ar_type_code | char | Yes | 1 |
| dflt_cred_code | char | Yes | 3 |
| dflt_cred_limit_amt | numeric | Yes |  |
| dflt_cust_job_num_req_flag | bit | Yes |  |
| dflt_finc_chrg_flag | bit | Yes |  |
| dflt_invc_det_sum_code | char | Yes | 1 |
| dflt_invc_grouping_code | char | Yes | 1 |
| dflt_invc_sub_grouping_code | char | Yes | 1 |
| dflt_invc_freq_code | char | Yes | 1 |
| dflt_invc_sep_prod_line_flag | bit | Yes |  |
| dflt_invc_single_mult_code | char | Yes | 1 |
| dflt_invc_comb_haul_flag | bit | Yes |  |
| dflt_invc_show_min_haul_flag | bit | Yes |  |
| dflt_non_tax_rsn_code | char | Yes | 3 |
| dflt_po_req_flag | bit | Yes |  |
| dflt_print_stmnt_flag | bit | Yes |  |
| dflt_stmnt_cycle_code | char | Yes | 1 |
| dflt_tax_code | char | Yes | 3 |
| dflt_taxble_code | char | Yes | 1 |
| dflt_allow_price_adj_flag | bit | Yes |  |
| dflt_metric_cstmry_code | char | Yes | 1 |
| dflt_ca_apply_min_load_flag | bit | Yes |  |
| dflt_cb_apply_min_load_flag | bit | Yes |  |
| dflt_cc_apply_min_load_flag | bit | Yes |  |
| dflt_cd_apply_min_load_flag | bit | Yes |  |
| dflt_ca_apply_zone_chrg_flag | bit | Yes |  |
| dflt_cb_apply_zone_chrg_flag | bit | Yes |  |
| dflt_cc_apply_zone_chrg_flag | bit | Yes |  |
| dflt_cd_apply_zone_chrg_flag | bit | Yes |  |
| dflt_ca_apply_excess_unld_flag | bit | Yes |  |
| dflt_cb_apply_excess_unld_flag | bit | Yes |  |
| dflt_cc_apply_excess_unld_flag | bit | Yes |  |
| dflt_cd_apply_excess_unld_flag | bit | Yes |  |
| dflt_ca_apply_season_chrg_flag | bit | Yes |  |
| dflt_cb_apply_season_chrg_flag | bit | Yes |  |
| dflt_cc_apply_season_chrg_flag | bit | Yes |  |
| dflt_cd_apply_season_chrg_flag | bit | Yes |  |
| dflt_ca_apply_cart_hler_flag | bit | Yes |  |
| dflt_cb_apply_cart_hler_flag | bit | Yes |  |
| dflt_cc_apply_cart_hler_flag | bit | Yes |  |
| dflt_cd_apply_cart_hler_flag | bit | Yes |  |
| dflt_ca_apply_sur_hler_flag | bit | Yes |  |
| dflt_cb_apply_sur_hler_flag | bit | Yes |  |
| dflt_cc_apply_sur_hler_flag | bit | Yes |  |
| dflt_cd_apply_sur_hler_flag | bit | Yes |  |
| dflt_ca_cart_code | char | Yes | 3 |
| dflt_cb_cart_code | char | Yes | 3 |
| dflt_cc_cart_code | char | Yes | 3 |
| dflt_cd_cart_code | char | Yes | 3 |
| dflt_ca_apply_min_haul_flag | bit | Yes |  |
| dflt_cb_apply_min_haul_flag | bit | Yes |  |
| dflt_cc_apply_min_haul_flag | bit | Yes |  |
| dflt_cd_apply_min_haul_flag | bit | Yes |  |
| dflt_ca_force_price_uom_flag | bit | Yes |  |
| dflt_cb_force_price_uom_flag | bit | Yes |  |
| dflt_cc_force_price_uom_flag | bit | Yes |  |
| dflt_cd_force_price_uom_flag | bit | Yes |  |
| dflt_ca_min_load_chrg_table_id | char | Yes | 3 |
| dflt_cb_min_load_chrg_table_id | char | Yes | 3 |
| dflt_cc_min_load_chrg_table_id | char | Yes | 3 |
| dflt_cd_min_load_chrg_table_id | char | Yes | 3 |
| dflt_ca_excess_unld_table_id | char | Yes | 3 |
| dflt_cb_excess_unld_table_id | char | Yes | 3 |
| dflt_cc_excess_unld_table_id | char | Yes | 3 |
| dflt_cd_excess_unld_table_id | char | Yes | 3 |
| dflt_ca_season_chrg_table_id | char | Yes | 3 |
| dflt_cb_season_chrg_table_id | char | Yes | 3 |
| dflt_cc_season_chrg_table_id | char | Yes | 3 |
| dflt_cd_season_chrg_table_id | char | Yes | 3 |
| dflt_ca_min_load_sep_invc_flag | bit | Yes |  |
| dflt_cb_min_load_sep_invc_flag | bit | Yes |  |
| dflt_cc_min_load_sep_invc_flag | bit | Yes |  |
| dflt_cd_min_load_sep_invc_flag | bit | Yes |  |
| dflt_ca_excess_sep_invc_flag | bit | Yes |  |
| dflt_cb_excess_sep_invc_flag | bit | Yes |  |
| dflt_cc_excess_sep_invc_flag | bit | Yes |  |
| dflt_cd_excess_sep_invc_flag | bit | Yes |  |
| dflt_ca_season_sep_invc_flag | bit | Yes |  |
| dflt_cb_season_sep_invc_flag | bit | Yes |  |
| dflt_cc_season_sep_invc_flag | bit | Yes |  |
| dflt_cd_season_sep_invc_flag | bit | Yes |  |
| dflt_ca_price_cat | char | Yes | 3 |
| dflt_cb_price_cat | char | Yes | 3 |
| dflt_cc_price_cat | char | Yes | 3 |
| dflt_cd_price_cat | char | Yes | 3 |
| dflt_ca_price_plant_code | char | Yes | 3 |
| dflt_cb_price_plant_code | char | Yes | 3 |
| dflt_cc_price_plant_code | char | Yes | 3 |
| dflt_cd_price_plant_code | char | Yes | 3 |
| dflt_ca_print_tkt_prices_flag | bit | Yes |  |
| dflt_cb_print_tkt_prices_flag | bit | Yes |  |
| dflt_cc_print_tkt_prices_flag | bit | Yes |  |
| dflt_cd_print_tkt_prices_flag | bit | Yes |  |
| dflt_ca_prod_price | numeric | Yes |  |
| dflt_cb_prod_price | numeric | Yes |  |
| dflt_cc_prod_price | numeric | Yes |  |
| dflt_cd_prod_price | numeric | Yes |  |
| dflt_ca_res_quoted_prod_flag | bit | Yes |  |
| dflt_cb_res_quoted_prod_flag | bit | Yes |  |
| dflt_cc_res_quoted_prod_flag | bit | Yes |  |
| dflt_cd_res_quoted_prod_flag | bit | Yes |  |
| dflt_ca_print_mix_wgts_flag | bit | Yes |  |
| dflt_cb_print_mix_wgts_flag | bit | Yes |  |
| dflt_cc_print_mix_wgts_flag | bit | Yes |  |
| dflt_cd_print_mix_wgts_flag | bit | Yes |  |
| dflt_ca_sales_anl_code | char | Yes | 3 |
| dflt_cb_sales_anl_code | char | Yes | 3 |
| dflt_cc_sales_anl_code | char | Yes | 3 |
| dflt_cd_sales_anl_code | char | Yes | 3 |
| dflt_ca_sched_load_size | numeric | Yes |  |
| dflt_cb_sched_load_size | numeric | Yes |  |
| dflt_cc_sched_load_size | numeric | Yes |  |
| dflt_cd_sched_load_size | numeric | Yes |  |
| dflt_ca_sched_load_size_uom | char | Yes | 5 |
| dflt_cb_sched_load_size_uom | char | Yes | 5 |
| dflt_cc_sched_load_size_uom | char | Yes | 5 |
| dflt_cd_sched_load_size_uom | char | Yes | 5 |
| dflt_ca_sched_plant_code | char | Yes | 3 |
| dflt_cb_sched_plant_code | char | Yes | 3 |
| dflt_cc_sched_plant_code | char | Yes | 3 |
| dflt_cd_sched_plant_code | char | Yes | 3 |
| dflt_ca_slsmn_empl_code | char | Yes | 12 |
| dflt_cb_slsmn_empl_code | char | Yes | 12 |
| dflt_cc_slsmn_empl_code | char | Yes | 12 |
| dflt_cd_slsmn_empl_code | char | Yes | 12 |
| dflt_ca_terms_code | char | Yes | 3 |
| dflt_cb_terms_code | char | Yes | 3 |
| dflt_cc_terms_code | char | Yes | 3 |
| dflt_cd_terms_code | char | Yes | 3 |
| dflt_ca_track_order_color | numeric | Yes |  |
| dflt_cb_track_order_color | numeric | Yes |  |
| dflt_cc_track_order_color | numeric | Yes |  |
| dflt_cd_track_order_color | numeric | Yes |  |
| dflt_ca_track_truck_color | numeric | Yes |  |
| dflt_cb_track_truck_color | numeric | Yes |  |
| dflt_cc_track_truck_color | numeric | Yes |  |
| dflt_cd_track_truck_color | numeric | Yes |  |
| dflt_ca_track_truck_flag_code | char | Yes | 1 |
| dflt_cb_track_truck_flag_code | char | Yes | 1 |
| dflt_cc_track_truck_flag_code | char | Yes | 1 |
| dflt_cd_track_truck_flag_code | char | Yes | 1 |
| dflt_ca_trade_disc_amt | numeric | Yes |  |
| dflt_cb_trade_disc_amt | numeric | Yes |  |
| dflt_cc_trade_disc_amt | numeric | Yes |  |
| dflt_cd_trade_disc_amt | numeric | Yes |  |
| dflt_ca_trade_disc_amt_uom | char | Yes | 5 |
| dflt_cb_trade_disc_amt_uom | char | Yes | 5 |
| dflt_cc_trade_disc_amt_uom | char | Yes | 5 |
| dflt_cd_trade_disc_amt_uom | char | Yes | 5 |
| dflt_ca_trade_disc_pct | numeric | Yes |  |
| dflt_cb_trade_disc_pct | numeric | Yes |  |
| dflt_cc_trade_disc_pct | numeric | Yes |  |
| dflt_cd_trade_disc_pct | numeric | Yes |  |
| dflt_ca_zone_code | char | Yes | 8 |
| dflt_cb_zone_code | char | Yes | 8 |
| dflt_cc_zone_code | char | Yes | 8 |
| dflt_cd_zone_code | char | Yes | 8 |
| type_price | char | Yes | 1 |
| com_mgr_thrshld | numeric | Yes |  |
| show_blocking_user_flag | bit | Yes |  |
| system_id | char | Yes | 16 |
| dflt_invc_delv_meth | char | Yes | 2 |
| license_violation_message_code | char | Yes | 2 |
| dflt_pump_split_tkt_invc_code | char | Yes | 2 |
| dflt_stmt_delv_meth | char | Yes | 2 |
| dflt_ca_stat | char | Yes | 1 |
| dflt_cc_stat | char | Yes | 1 |
| dflt_cb_stat | char | Yes | 1 |
| dflt_cd_stat | char | Yes | 1 |
| order_chng_cust_initiated_code | char | Yes | 2 |
| form_logging | bit | Yes |  |
| order_chng_rsn_req_code | char | Yes | 2 |
| twilio_account_sid | char | Yes | 50 |
| twilio_auth_token | char | Yes | 50 |
| twilio_from_phone | char | Yes | 20 |
| whatsapp_phone | char | Yes | 29 |
| allow_text_to_moving_trucks | bit | Yes |  |
| default_phone_country_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| user_defined | varchar | Yes | 2000 |
| dflt_volume_calc_uom | varchar | Yes | 1700 |
| dflt_user_options | varchar | Yes | 1700 |
| user_defined_order_chng_log | varchar | Yes | 1700 |
| license_violation_email_1 | varchar | Yes | 100 |
| license_violation_email_2 | varchar | Yes | 100 |
| license_violation_email_3 | varchar | Yes | 100 |

## Table: dbo.cnf2
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| key_field | char | No | 1 |
| days_allow_disptch | numeric | Yes |  |
| days_to_save_order_tkt_det | numeric | Yes |  |
| allow_disptch_act_quote_flag | bit | Yes |  |
| allow_man_entry_wgts_flag | bit | Yes |  |
| allow_tkt_overload_truck_flag | bit | Yes |  |
| trlr_wgt_sep_flag | bit | Yes |  |
| tare_each_load_flag | bit | Yes |  |
| exceed_qty_flag | bit | Yes |  |
| clear_daily_flag | bit | Yes |  |
| cutoff_qty | numeric | Yes |  |
| load_var_qty | numeric | Yes |  |
| cart_freq_code | char | Yes | 1 |
| haul_chrg_prod_code | char | Yes | 12 |
| post_trvl_toler | numeric | Yes |  |
| post_trvl_load_bound | numeric | Yes |  |
| post_trvl_load_reclaim | numeric | Yes |  |
| ca_allow_add_prod_tkt_flag | bit | Yes |  |
| cb_allow_add_prod_tkt_flag | bit | Yes |  |
| cc_allow_add_prod_tkt_flag | bit | Yes |  |
| cd_allow_add_prod_tkt_flag | bit | Yes |  |
| ca_allow_po_chng_tkt_flag | bit | Yes |  |
| cb_allow_po_chng_tkt_flag | bit | Yes |  |
| cc_allow_po_chng_tkt_flag | bit | Yes |  |
| cd_allow_po_chng_tkt_flag | bit | Yes |  |
| ca_force_proj_flag | bit | Yes |  |
| cb_force_proj_flag | bit | Yes |  |
| cc_force_proj_flag | bit | Yes |  |
| cd_force_proj_flag | bit | Yes |  |
| ca_truck_track_first_stat | numeric | Yes |  |
| cb_truck_track_first_stat | numeric | Yes |  |
| cc_truck_track_first_stat | numeric | Yes |  |
| cd_truck_track_first_stat | numeric | Yes |  |
| ca_truck_track_lead_mins | numeric | Yes |  |
| cb_truck_track_lead_mins | numeric | Yes |  |
| cc_truck_track_lead_mins | numeric | Yes |  |
| cd_truck_track_lead_mins | numeric | Yes |  |
| ca_truck_track_msg_code | char | Yes | 1 |
| cb_truck_track_msg_code | char | Yes | 1 |
| cc_truck_track_msg_code | char | Yes | 1 |
| cd_truck_track_msg_code | char | Yes | 1 |
| ca_show_map_page_flag | bit | Yes |  |
| cb_show_map_page_flag | bit | Yes |  |
| cc_show_map_page_flag | bit | Yes |  |
| cd_show_map_page_flag | bit | Yes |  |
| ca_show_zone_code_flag | bit | Yes |  |
| cb_show_zone_code_flag | bit | Yes |  |
| cc_show_zone_code_flag | bit | Yes |  |
| cd_show_zone_code_flag | bit | Yes |  |
| ca_price_plant_from_sched_flag | bit | Yes |  |
| cb_price_plant_from_sched_flag | bit | Yes |  |
| cc_price_plant_from_sched_flag | bit | Yes |  |
| cd_price_plant_from_sched_flag | bit | Yes |  |
| ca_show_delv_meth_flag | bit | Yes |  |
| cb_show_delv_meth_flag | bit | Yes |  |
| cc_show_delv_meth_flag | bit | Yes |  |
| cd_show_delv_meth_flag | bit | Yes |  |
| dflt_qc_approvl_flag | bit | Yes |  |
| use_order_mix_design_flag | bit | Yes |  |
| type_moves_to_job_flag | bit | Yes |  |
| disable_unload_time_flag | bit | Yes |  |
| disable_wash_time_flag | bit | Yes |  |
| po_on_simp_tkting_flag | bit | Yes |  |
| zone_on_simp_tkting_flag | bit | Yes |  |
| cart_on_simp_tkting_flag | bit | Yes |  |
| content_pricing_flag | bit | Yes |  |
| cstmry_content_item_code | char | Yes | 12 |
| cstmry_content_descr | char | Yes | 40 |
| metric_content_item_code | char | Yes | 12 |
| metric_content_descr | char | Yes | 40 |
| ca_truck_pre_tkting_color | numeric | Yes |  |
| cb_truck_pre_tkting_color | numeric | Yes |  |
| cc_truck_pre_tkting_color | numeric | Yes |  |
| cd_truck_pre_tkting_color | numeric | Yes |  |
| overhd_loadout_devtn_pct | numeric | Yes |  |
| ca_tare_days | numeric | Yes |  |
| cb_tare_days | numeric | Yes |  |
| cc_tare_days | numeric | Yes |  |
| cd_tare_days | numeric | Yes |  |
| use_ship_addr_flag | bit | Yes |  |
| dflt_map_radius | numeric | Yes |  |
| mix_design_doc_fmt_code | char | Yes | 8 |
| generic_mix_flag | bit | Yes |  |
| generic_loc_code | char | Yes | 4 |
| truck_signl_unit_chng_code | char | Yes | 1 |
| dynamic_plant_fleet_size_flag | bit | Yes |  |
| dflt_ca_order_type | char | Yes | 2 |
| dflt_cb_order_type | char | Yes | 2 |
| dflt_cc_order_type | char | Yes | 2 |
| dflt_cd_order_type | char | Yes | 2 |
| ca_apply_min_haul_pay_flag | bit | Yes |  |
| cb_apply_min_haul_pay_flag | bit | Yes |  |
| cc_apply_min_haul_pay_flag | bit | Yes |  |
| cd_apply_min_haul_pay_flag | bit | Yes |  |
| ca_show_map_page_code | char | Yes | 1 |
| cb_show_map_page_code | char | Yes | 1 |
| cc_show_map_page_code | char | Yes | 1 |
| cd_show_map_page_code | char | Yes | 1 |
| ca_show_zone_code_code | char | Yes | 1 |
| cb_show_zone_code_code | char | Yes | 1 |
| cc_show_zone_code_code | char | Yes | 1 |
| cd_show_zone_code_code | char | Yes | 1 |
| dflt_ca_sched_load_size_code | char | Yes | 1 |
| dflt_mfin_log_code | char | Yes | 2 |
| dflt_cb_sched_load_size_code | char | Yes | 1 |
| dflt_mfin_log_detail_flag | bit | Yes |  |
| dflt_cc_sched_load_size_code | char | Yes | 1 |
| use_shp_plt_tx_on_fob_tkt_flag | bit | Yes |  |
| dflt_cd_sched_load_size_code | char | Yes | 1 |
| ac_db_hits | numeric | Yes |  |
| ex_db_hits | numeric | Yes |  |
| db_violations | numeric | Yes |  |
| db_violation_date | datetime | Yes |  |
| gps_indicate_symbol | char | Yes | 3 |
| map_intfc_type | numeric | Yes |  |
| ca_truck_pre_tkt_status | numeric | Yes |  |
| cb_truck_pre_tkt_status | numeric | Yes |  |
| cc_truck_pre_tkt_status | numeric | Yes |  |
| cd_truck_pre_tkt_status | numeric | Yes |  |
| display_drop_information | char | Yes | 2 |
| dflt_ca_allow_price_chng_flag | bit | Yes |  |
| dflt_cb_allow_price_chng_flag | bit | Yes |  |
| dflt_cc_allow_price_chng_flag | bit | Yes |  |
| dflt_cd_allow_price_chng_flag | bit | Yes |  |
| ship_post_code_req_flag | bit | Yes |  |
| cc_map_update_truck_coord_flag | bit | Yes |  |
| dflt_cc_map_truck_poll_type | numeric | Yes |  |
| dflt_cc_map_upd_ord_coord_flag | bit | Yes |  |
| dflt_cc_map_upd_prj_coord_flag | bit | Yes |  |
| ca_barcode_seq_num | char | Yes | 3 |
| cb_barcode_seq_num | char | Yes | 3 |
| cc_barcode_seq_num | char | Yes | 3 |
| cd_barcode_seq_num | char | Yes | 3 |
| ca_barcode_card_format | char | Yes | 8 |
| cb_barcode_card_format | char | Yes | 8 |
| cc_barcode_card_format | char | Yes | 8 |
| cd_barcode_card_format | char | Yes | 8 |
| update_sched_qty_flag | bit | Yes |  |
| show_truck_under_load_code | char | Yes | 2 |
| sim_tkt_remove_rsn_code | char | Yes | 3 |
| cust_proj_zone_chrg_price_adj | char | Yes | 2 |
| cust_apply_zone_code | char | Yes | 2 |
| ca_driver_callin_interval | numeric | Yes |  |
| cb_driver_callin_interval | numeric | Yes |  |
| cc_driver_callin_interval | numeric | Yes |  |
| cd_driver_callin_interval | numeric | Yes |  |
| driver_callin_truck_assgn_code | char | Yes | 2 |
| allow_price_chng_option | char | Yes | 2 |
| list_items_by_plant | char | Yes | 2 |
| cc_allow_air_pct_code | char | Yes | 2 |
| cd_allow_air_pct_code | char | Yes | 2 |
| alt_truck_capacity_name_1 | char | Yes | 16 |
| alt_truck_capacity_1 | numeric | Yes |  |
| alt_truck_capacity_name_2 | char | Yes | 16 |
| alt_truck_capacity_2 | numeric | Yes |  |
| alt_truck_capacity_name_3 | char | Yes | 16 |
| alt_truck_capacity_3 | numeric | Yes |  |
| alt_truck_capacity_name_4 | char | Yes | 16 |
| alt_truck_capacity_4 | numeric | Yes |  |
| pour_rate_days_back | numeric | Yes |  |
| pour_rate_mgr_num | numeric | Yes |  |
| cc_returned_conc_opt | char | Yes | 2 |
| ca_truck_pre_tkt_mult_code | char | Yes | 2 |
| cb_truck_pre_tkt_mult_code | char | Yes | 2 |
| cc_truck_pre_tkt_mult_code | char | Yes | 2 |
| cd_truck_pre_tkt_mult_code | char | Yes | 2 |
| rec_source_of_truck_stat_code | char | Yes | 2 |
| dflt_sched_rate_type_code | char | Yes | 1 |
| schedulecom_empl_code | char | Yes | 2 |
| ca_clear_track_truck_flag_code | char | Yes | 2 |
| cb_clear_track_truck_flag_code | char | Yes | 2 |
| cc_clear_track_truck_flag_code | char | Yes | 2 |
| cd_clear_track_truck_flag_code | char | Yes | 2 |
| email_invc_server | char | Yes | 100 |
| email_invc_server_port | numeric | Yes |  |
| email_invc_server_ssl_code | char | Yes | 2 |
| email_invc_user_name | char | Yes | 40 |
| email_invc_password | char | Yes | 40 |
| email_invc_from_addr | char | Yes | 100 |
| force_shipaddr_to_delvaddr_code | char | Yes | 2 |
| alt_truck_capacity_rnd_code | char | Yes | 1 |
| forward_task_message_code | char | Yes | 2 |
| enhanced_batch_code_func_code | char | Yes | 2 |
| dflt_prim_cont_ordr | char | Yes | 2 |
| fiscal_note_interface_code | char | Yes | 2 |
| fiscal_note_request_file_loc | char | Yes | 128 |
| fiscal_note_response_file_loc | char | Yes | 128 |
| fiscal_note_proc_file_loc | char | Yes | 128 |
| fiscal_note_notproc_file_loc | char | Yes | 128 |
| fiscal_note_error_file_loc | char | Yes | 128 |
| email_ordtkt_from_addr | char | Yes | 100 |
| email_notify_ordr_create | bit | Yes |  |
| email_notify_ordr_cancel | bit | Yes |  |
| email_notify_tkt_create | bit | Yes |  |
| email_notify_tkt_cancel | bit | Yes |  |
| ordr_doc_format | char | Yes | 8 |
| tkt_doc_format | char | Yes | 8 |
| ordr_email_subj | char | Yes | 100 |
| tkt_email_subj | char | Yes | 100 |
| fiscal_note_natop_code_1 | numeric | Yes |  |
| fiscal_note_natop_code_2 | numeric | Yes |  |
| fiscal_note_dest_code | char | Yes | 2 |
| fiscal_note_vers | char | Yes | 8 |
| fiscal_note_vers_effect_date | datetime | Yes |  |
| fiscal_note_prev_vers | char | Yes | 8 |
| fiscal_note_doc_fmt_code_1 | char | Yes | 8 |
| fiscal_note_doc_fmt_code_2 | char | Yes | 8 |
| fiscal_note_doc_fmt_code_3 | char | Yes | 8 |
| fiscal_note_corr_letter_days | numeric | Yes |  |
| fiscal_note_corr_letter_text | char | Yes | 1000 |
| fiscal_note_acct_cat_code | char | Yes | 4 |
| fiscal_note_incl_ipi_flag | bit | Yes |  |
| next_ctct_seq | char | Yes | 3 |
| mobileticket_email_addr | char | Yes | 100 |
| water_added_item_code | char | Yes | 12 |
| cc_days_allow_tkt | numeric | Yes |  |
| cc_codes_required | bit | Yes |  |
| cc_truck_seal_code | char | Yes | 2 |
| third_party_map_reg_server_ip | char | Yes | 45 |
| third_party_map_reg_server_port | numeric | Yes |  |
| invc_body_doc_format | char | Yes | 8 |
| quote_email_system | char | Yes | 2 |
| email_quote_from_addr | char | Yes | 100 |
| cover_page_dflt | char | Yes | 2 |
| email_notify_order_change | bit | Yes |  |
| ordr_chgd_type_notf_code | char | Yes | 40 |
| tick_crtd_type_notf_code | char | Yes | 2 |
| use_journey_code | char | Yes | 2 |
| cc_zero_price_chrgs_code | char | Yes | 2 |
| cc_truck_expir_date_check | char | Yes | 2 |
| email_notify_addresses_code | char | Yes | 2 |
| encrypt_equation | varchar | Yes | 2000 |
| delv_time_zone | varchar | Yes | 2000 |
| mapit_url | char | Yes | 250 |
| print_hard_copy_code | char | Yes | 2 |
| delayed_tkt_print | char | Yes | 2 |
| show_loaded_status_flag | bit | Yes |  |
| dispatch_day_time_offset | numeric | Yes |  |
| cn_encrypt_flag | bit | Yes |  |
| google_api_key | char | Yes | 70 |
| allow_launch_ct | numeric | Yes |  |
| upd_mobtkt_loadtime | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cnf3
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| key_field | char | No | 1 |
| invc_compt_tax_disc_flag | bit | Yes |  |
| invc_doc_fmt_group_code | char | Yes | 8 |
| invc_by_ordr_or_tkt_date | char | Yes | 1 |
| invc_terms_disc_calc_meth | char | Yes | 1 |
| sep_cred_debit_trans_flag | bit | Yes |  |
| use_plant_terms_flag | bit | Yes |  |
| use_prod_terms_disc_flag | bit | Yes |  |
| tax_loc_non_tax_rsn_code | char | Yes | 3 |
| dflt_ca_memo_rsn_code | char | Yes | 3 |
| dflt_cb_memo_rsn_code | char | Yes | 3 |
| dflt_cc_memo_rsn_code | char | Yes | 3 |
| dflt_cd_memo_rsn_code | char | Yes | 3 |
| dflt_susp_rsn_code | char | Yes | 3 |
| compt_tax_by_ship_plant_flag | bit | Yes |  |
| sales_tax_gl_ship_plant_flag | bit | Yes |  |
| allow_invoice_closed_perd_code | char | Yes | 1 |
| dflt_taxble_susp_rsn_code | char | Yes | 3 |
| round_tax_by_ship_plant_flag | bit | Yes |  |
| allow_order_closed_perd_code | char | Yes | 1 |
| days_allowed_cred_inquiry | numeric | Yes |  |
| credit_suspend_prompt | char | Yes | 2 |
| suspend_shipped_orders_flag | bit | Yes |  |
| suppress_zero_priced_invc_flag | bit | Yes |  |
| days_forward_cred_suspend | numeric | Yes |  |
| days_forward_sus_rsn_code | char | Yes | 3 |
| email_invc_doc_fmt_group_code | char | Yes | 8 |
| calc_cod_max_tax | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cnf4
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| key_field | char | No | 1 |
| invy_cost_meth | char | Yes | 1 |
| invy_cost_trans_from_invc_flag | bit | Yes |  |
| invy_update_costs_to_gl_flag | bit | Yes |  |
| invy_update_rcpts_to_gl_flag | bit | Yes |  |
| invy_update_usages_to_gl_flag | bit | Yes |  |
| invy_update_sales_to_gl_flag | bit | Yes |  |
| invy_update_trfs_to_gl_flag | bit | Yes |  |
| invy_update_convs_to_gl_flag | bit | Yes |  |
| invy_update_adjs_to_gl_flag | bit | Yes |  |
| invy_gl_src_code | char | Yes | 2 |
| invy_auto_create_gl_flag | bit | Yes |  |
| invy_auto_create_gl_other_flag | bit | Yes |  |
| perd_end_post_stat | char | Yes | 2 |
| perd_end_trnf_det_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cnf5
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| key_field | char | No | 1 |
| aging_code_cat_1 | char | Yes | 2 |
| aging_code_cat_2 | char | Yes | 2 |
| aging_code_cat_3 | char | Yes | 2 |
| aging_code_cat_4 | char | Yes | 2 |
| aging_code_cat_5 | char | Yes | 2 |
| aging_code_cat_6 | char | Yes | 2 |
| aging_code_cat_7 | char | Yes | 2 |
| aging_descr_cat_1 | char | Yes | 12 |
| aging_descr_cat_2 | char | Yes | 12 |
| aging_descr_cat_3 | char | Yes | 12 |
| aging_descr_cat_4 | char | Yes | 12 |
| aging_descr_cat_5 | char | Yes | 12 |
| aging_descr_cat_6 | char | Yes | 12 |
| aging_descr_cat_7 | char | Yes | 12 |
| aging_by_date_code | char | Yes | 1 |
| aging_meth_code | char | Yes | 1 |
| aging_prox_day_of_month | numeric | Yes |  |
| ar_gl_src_code | char | Yes | 2 |
| ar_qty_gl_src_code | char | Yes | 2 |
| ar_grace_days | numeric | Yes |  |
| atb_comb_adj_flag | bit | Yes |  |
| atb_print_disc_avail_flag | bit | Yes |  |
| atb_print_zero_item_flag | bit | Yes |  |
| atb_sum_line_space | numeric | Yes |  |
| disc_adj_code | char | Yes | 3 |
| cred_by_comp_flag | bit | Yes |  |
| net_rev_post_date_code | char | Yes | 1 |
| disc_meth | char | Yes | 1 |
| stmnt_comb_adj_flag | bit | Yes |  |
| stmnt_disc_day_of_month | numeric | Yes |  |
| stmnt_doc_fmt_group_code | char | Yes | 8 |
| stmnt_msg_code_aging_cat_1 | char | Yes | 4 |
| stmnt_msg_code_aging_cat_2 | char | Yes | 4 |
| stmnt_msg_code_aging_cat_3 | char | Yes | 4 |
| stmnt_msg_code_aging_cat_4 | char | Yes | 4 |
| stmnt_msg_code_aging_cat_5 | char | Yes | 4 |
| stmnt_msg_code_aging_cat_6 | char | Yes | 4 |
| stmnt_msg_code_aging_cat_7 | char | Yes | 4 |
| stmnt_option_code | char | Yes | 2 |
| stmnt_lot_block_total_flag | bit | Yes |  |
| stmnt_print_proj_total_flag | bit | Yes |  |
| stmnt_print_zero_flag | bit | Yes |  |
| stmnt_print_zero_item_flag | bit | Yes |  |
| stmnt_ref_print_seq_code | char | Yes | 4 |
| book_disc_taken_code | char | Yes | 1 |
| tax_on_disc_non_tax_rsn_code | char | Yes | 3 |
| use_cut_sub_trans_flag | bit | Yes |  |
| rcpt_doc_fmt_code | char | Yes | 8 |
| next_rcpt_seq | char | Yes | 3 |
| archive_invc_flag | bit | Yes |  |
| archive_sales_tax_flag | bit | Yes |  |
| archive_gl_flag | bit | Yes |  |
| apply_meth_type | char | Yes | 1 |
| dflt_pmt_apply_method | char | Yes | 1 |
| manual_disc_pmt_apply_method | char | Yes | 2 |
| cred_by_proj_flag | bit | Yes |  |
| dflt_plnt_rec_trans | char | Yes | 2 |
| pmt_import_dflt_stat | char | Yes | 1 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| net_rev_post_trans_types | varchar | Yes | 2000 |

## Table: dbo.cnf6
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| key_field | char | No | 1 |
| acct_code_len | numeric | Yes |  |
| budget_round_amt | numeric | Yes |  |
| comp_code_len | numeric | Yes |  |
| cost_center_len | numeric | Yes |  |
| mult_comp_flag | bit | Yes |  |
| num_budget | numeric | Yes |  |
| sub_acct_code_len | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cnf7
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| key_field | char | No | 1 |
| quote_doc_fmt_group_code | char | Yes | 8 |
| next_quote_seq | char | Yes | 3 |
| use_trade_disc_for_proj_flag | bit | Yes |  |
| use_trade_disc_for_quote_flag | bit | Yes |  |
| use_zone_chrgs_for_proj_flag | bit | Yes |  |
| use_zone_chrgs_for_quote_flag | bit | Yes |  |
| updt_proj_quote_sales_rec_type | char | Yes | 2 |
| quote_form | char | Yes | 128 |
| days_quote_valid | numeric | Yes |  |
| next_proj_seq | char | Yes | 3 |
| next_job_seq | char | Yes | 3 |
| use_proj_begin_date_code | char | Yes | 2 |
| use_proj_expir_date_code | char | Yes | 2 |
| copy_proj_prod_code | char | Yes | 2 |
| copy_quote_prod_code | char | Yes | 2 |
| copy_job_prod_code | char | Yes | 2 |
| use_cust_default_code | char | Yes | 2 |
| valid_job_stage_code | char | Yes | 2 |
| update_job_with_quote_prod | char | Yes | 2 |
| price_auth_after_discount_code | char | Yes | 2 |
| prod_select_price_option | char | Yes | 2 |
| proj_forecast_dflt_code | char | Yes | 2 |
| ca_slsmn_empl_code_prj_dft_cd | char | Yes | 2 |
| cb_slsmn_empl_code_prj_dft_cd | char | Yes | 2 |
| cc_slsmn_empl_code_prj_dft_cd | char | Yes | 2 |
| cd_slsmn_empl_code_prj_dft_cd | char | Yes | 2 |
| ca_sales_anl_code_prj_dft_code | char | Yes | 2 |
| cb_sales_anl_code_prj_dft_code | char | Yes | 2 |
| cc_sales_anl_code_prj_dft_code | char | Yes | 2 |
| cd_sales_anl_code_prj_dft_code | char | Yes | 2 |
| ca_price_plant_code_prj_dft_cd | char | Yes | 2 |
| cb_price_plant_code_prj_dft_cd | char | Yes | 2 |
| cc_price_plant_code_prj_dft_cd | char | Yes | 2 |
| cd_price_plant_code_prj_dft_cd | char | Yes | 2 |
| ca_price_cat_prj_dft_code | char | Yes | 2 |
| cb_price_cat_prj_dft_code | char | Yes | 2 |
| cc_price_cat_prj_dft_code | char | Yes | 2 |
| cd_price_cat_prj_dft_code | char | Yes | 2 |
| ca_trade_disc_pct_prj_dft_code | char | Yes | 2 |
| cb_trade_disc_pct_prj_dft_code | char | Yes | 2 |
| cc_trade_disc_pct_prj_dft_code | char | Yes | 2 |
| cd_trade_disc_pct_prj_dft_code | char | Yes | 2 |
| ca_trade_disc_amt_prj_dft_code | char | Yes | 2 |
| cb_trade_disc_amt_prj_dft_code | char | Yes | 2 |
| cc_trade_disc_amt_prj_dft_code | char | Yes | 2 |
| cd_trade_disc_amt_prj_dft_code | char | Yes | 2 |
| ca_terms_code_prj_dft_code | char | Yes | 2 |
| cb_terms_code_prj_dft_code | char | Yes | 2 |
| cc_terms_code_prj_dft_code | char | Yes | 2 |
| cd_terms_code_prj_dft_code | char | Yes | 2 |
| ca_zone_code_prj_dft_code | char | Yes | 2 |
| cb_zone_code_prj_dft_code | char | Yes | 2 |
| cc_zone_code_prj_dft_code | char | Yes | 2 |
| cd_zone_code_prj_dft_code | char | Yes | 2 |
| ca_min_load_chg_prj_dft_code | char | Yes | 2 |
| cb_min_load_chg_prj_dft_code | char | Yes | 2 |
| cc_min_load_chg_prj_dft_code | char | Yes | 2 |
| cd_min_load_chg_prj_dft_code | char | Yes | 2 |
| ca_season_chg_prj_dft_code | char | Yes | 2 |
| cb_season_chg_prj_dft_code | char | Yes | 2 |
| cc_season_chg_prj_dft_code | char | Yes | 2 |
| cd_season_chg_prj_dft_code | char | Yes | 2 |
| ca_unld_chg_prj_dft_code | char | Yes | 2 |
| cb_unld_chg_prj_dft_code | char | Yes | 2 |
| cc_unld_chg_prj_dft_code | char | Yes | 2 |
| cd_unld_chg_prj_dft_code | char | Yes | 2 |
| ca_sundry_chg_prj_dft_code | char | Yes | 2 |
| cb_sundry_chg_prj_dft_code | char | Yes | 2 |
| cc_sundry_chg_prj_dft_code | char | Yes | 2 |
| cd_sundry_chg_prj_dft_code | char | Yes | 2 |
| ca_cart_chg_prj_dft_code | char | Yes | 2 |
| cb_cart_chg_prj_dft_code | char | Yes | 2 |
| cc_cart_chg_prj_dft_code | char | Yes | 2 |
| cd_cart_chg_prj_dft_code | char | Yes | 2 |
| ca_surc_code_prj_dft_code | char | Yes | 2 |
| cb_surc_code_prj_dft_code | char | Yes | 2 |
| cc_surc_code_prj_dft_code | char | Yes | 2 |
| cd_surc_code_prj_dft_code | char | Yes | 2 |
| tax_code_prj_dft_code | char | Yes | 2 |
| taxble_flag_prj_dft_code | char | Yes | 2 |
| non_tax_rsn_code_prj_dft_code | char | Yes | 2 |
| auto_assign_cust_code | char | Yes | 2 |
| document_security | char | Yes | 2 |
| quot_cart_rate_pricing_code | char | Yes | 2 |
| proj_cart_rate_pricing_code | char | Yes | 2 |
| price_plant_user_priv_code | char | Yes | 2 |
| dflt_price_disp_type | char | Yes | 1 |
| use_project_contact | char | Yes | 2 |
| disable_price_escalation | bit | Yes |  |
| quote_print_method | char | Yes | 2 |
| quote_form_fr | char | Yes | 128 |
| use_grid_view | char | Yes | 2 |
| auto_assign_proj_code | char | Yes | 2 |
| proj_forecast_meth_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cnf8
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| key_field | char | No | 1 |
| dflt_max_load_size | numeric | Yes |  |
| dflt_max_truck_size | numeric | Yes |  |
| order_status_delay_flag | char | Yes | 2 |
| max_mins_early | numeric | Yes |  |
| max_mins_late | numeric | Yes |  |
| dflt_priority | numeric | Yes |  |
| adjust_cement_with_slump_code | char | Yes | 2 |
| callin_seniority_meth | char | Yes | 2 |
| drci_driver_puncin_options | char | Yes | 2 |
| drci_driver_error_color | numeric | Yes |  |
| drci_allow_early_callin_code | char | Yes | 2 |
| callin_hours_worked_weeks | char | Yes | 2 |
| callin_week_begin_day | char | Yes | 1 |
| callin_incomplete_days_assump | char | Yes | 2 |
| callin_incomplete_days_hours | numeric | Yes |  |
| callin_incomplete_days_punchout | datetime | Yes |  |
| drci_import_doc_fmt_code | char | Yes | 8 |
| drci_import_file_loc | char | Yes | 128 |
| drci_export_doc_fmt_code | char | Yes | 8 |
| drci_export_file_loc | char | Yes | 128 |
| drci_import_export_flag | bit | Yes |  |
| schedulecom_plant_code | char | Yes | 2 |
| sched_unassigned_trucks | char | Yes | 2 |
| dflt_lunch_task_code | char | Yes | 5 |
| dflt_qc_load_mins | numeric | Yes |  |
| dflt_max_deadhead_mins | numeric | Yes |  |
| mix_cost_tolerance_pct | numeric | Yes |  |
| max_dist_per_load | numeric | Yes |  |
| max_age_of_concrete | numeric | Yes |  |
| warn_time_max_age_of_concrete | numeric | Yes |  |
| drci_calc_weekly_roll_hrs | char | Yes | 2 |
| use_optimized_plants_only | char | Yes | 2 |
| traffic_infl_service | char | Yes | 2 |
| traffic_infl_to_job_mins | numeric | Yes |  |
| traffic_infl_to_plant_mins | numeric | Yes |  |
| traffic_infl_query_mins | numeric | Yes |  |
| traffic_infl_validity_mins | numeric | Yes |  |
| traffic_infl_plant_mins | numeric | Yes |  |
| traffic_infl_plant_dist | numeric | Yes |  |
| traffic_infl_inflate_pct | numeric | Yes |  |
| lock_in_call_in | char | Yes | 1 |
| max_critical_pct | numeric | Yes |  |
| schedulecom_url | char | Yes | 100 |
| schedulecom_username | char | Yes | 40 |
| schedulecom_password | char | Yes | 40 |
| schedulecom_timeout | numeric | Yes |  |
| truck_assignment_code | char | Yes | 2 |
| suggestion_ignored_mins | numeric | Yes |  |
| tkt_print_preload_flag | bit | Yes |  |
| sc_on_demand | char | Yes | 2 |
| dflt_callin_status | char | Yes | 2 |
| efficiency_num_loads | numeric | Yes |  |
| efficiency_reduction_rate | numeric | Yes |  |
| default_shift_number | char | Yes | 2 |
| yard_batcher_employee_sort | char | Yes | 2 |
| opt_group_drci_by_plant | char | Yes | 2 |
| dflt_qc_load_mins_jobsite | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cnf9
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| key_field | char | No | 1 |
| truck_rental_chrg | numeric | Yes |  |
| labor_chrg | numeric | Yes |  |
| min_truck_time | numeric | Yes |  |
| min_oper_time | numeric | Yes |  |
| direct_labor_pct | numeric | Yes |  |
| tax_withhold_pct | numeric | Yes |  |
| benefits_pct | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cnfa
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| key_field | char | No | 1 |
| verify_city_code_flag | bit | Yes |  |
| verify_state_code_flag | bit | Yes |  |
| verify_cntry_code_flag | bit | Yes |  |
| addr_line_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cnfc
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| key_field | char | No | 1 |
| ccard_processor_code | char | Yes | 2 |
| ccard_charge_code | char | Yes | 2 |
| ccard_generic_acct | char | Yes | 10 |
| ccard_prt_detail_code | char | Yes | 2 |
| ccard_addl_auth_amt | numeric | Yes |  |
| ccard_amt_override_code | char | Yes | 2 |
| ccard_ship_override_code | char | Yes | 2 |
| ccard_req_l3_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cnfo
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| key_field | char | No | 1 |
| keep_order_copy_code | char | Yes | 2 |
| keep_prod_copy_code | char | Yes | 2 |
| keep_assoc_prod_copy_code | char | Yes | 2 |
| keep_schedule_copy_code | char | Yes | 2 |
| keep_loads_copy_code | char | Yes | 2 |
| cust_name_copy_code | char | Yes | 2 |
| delv_addr_copy_code | char | Yes | 2 |
| instr_copy_code | char | Yes | 2 |
| note_text_copy_code | char | Yes | 2 |
| map_page_copy_code | char | Yes | 2 |
| po_copy_code | char | Yes | 2 |
| hler_code_copy_code | char | Yes | 2 |
| stat_copy_code | char | Yes | 2 |
| zone_code_copy_code | char | Yes | 2 |
| cust_job_num_copy_code | char | Yes | 2 |
| delv_meth_copy_code | char | Yes | 2 |
| price_plant_copy_code | char | Yes | 2 |
| zone_chrg_copy_code | char | Yes | 2 |
| min_load_chrg_copy_code | char | Yes | 2 |
| season_chrg_copy_code | char | Yes | 2 |
| unld_chrg_copy_code | char | Yes | 2 |
| sundry_chrg_copy_code | char | Yes | 2 |
| tax_code_copy_code | char | Yes | 2 |
| taxable_code_copy_code | char | Yes | 2 |
| non_tax_rsn_copy_code | char | Yes | 2 |
| tax_exempt_copy_code | char | Yes | 2 |
| track_order_color_copy_code | char | Yes | 2 |
| slsmn_empl_copy_code | char | Yes | 2 |
| sales_anl_copy_code | char | Yes | 2 |
| print_mix_wgts_copy_code | char | Yes | 2 |
| order_msgs_copy_code | char | Yes | 2 |
| user_defined_copy_code | char | Yes | 2 |
| air_trim_pct_copy_code | char | Yes | 2 |
| keep_sched_req_copy_code | char | Yes | 2 |
| pour_meth_code_copy_code | char | Yes | 2 |
| user_price_copy_code | char | Yes | 2 |
| proj_code_copy_code | char | Yes | 2 |
| ship_addr_copy_code | char | Yes | 2 |
| pkt_num_copy_code | char | Yes | 2 |
| keep_offset | char | Yes | 2 |
| order_by_name_copy_code | char | Yes | 2 |
| order_by_phone_copy_code | char | Yes | 2 |
| notf_email_copy_code | char | Yes | 2 |
| email_addr_mobile_copy_code | char | Yes | 2 |
| site_phone_copy_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cnfu
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| fld_name | char | No | 40 |
| fld_pos | char | Yes | 1 |
| fld_order | numeric | Yes |  |
| data_type | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cnot
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| unique_num | numeric | No |  |
| note_date | datetime | Yes |  |
| note_type_code | numeric | Yes |  |
| sort_name | char | Yes | 8 |
| proj_code | char | Yes | 12 |
| item_ref_code | char | Yes | 12 |
| user_name | char | Yes | 20 |
| contct_name | char | Yes | 40 |
| contct_phone | char | Yes | 14 |
| contct_fax | char | Yes | 14 |
| follow_up_date | datetime | Yes |  |
| follow_up_flag | bit | Yes |  |
| commit_amt | numeric | Yes |  |
| commit_date | datetime | Yes |  |
| status_flag | bit | Yes |  |
| order_flag | bit | Yes |  |
| invc_prep_flag | bit | Yes |  |
| invc_print_flag | bit | Yes |  |
| lien_flag | bit | Yes |  |
| rcvb_flag | bit | Yes |  |
| order_date | datetime | Yes |  |
| order_code | char | Yes | 12 |
| lot_block | char | Yes | 10 |
| note_cmplt_date | datetime | Yes |  |
| tick_flag | bit | Yes |  |
| batch_flag | bit | Yes |  |
| proj_flag | bit | Yes |  |
| order_auto_disp_flag | bit | Yes |  |
| invc_prep_auto_disp_flag | bit | Yes |  |
| invc_print_auto_disp_flag | bit | Yes |  |
| ar_auto_disp_flag | bit | Yes |  |
| tick_auto_disp_flag | bit | Yes |  |
| batch_auto_disp_flag | bit | Yes |  |
| proj_auto_disp_flag | bit | Yes |  |
| job_id | char | Yes | 15 |
| quote_code | char | Yes | 15 |
| unique_line_num | numeric | Yes |  |
| item_code | char | Yes | 12 |
| job_flag | bit | Yes |  |
| quote_flag | bit | Yes |  |
| job_auto_disp_flag | bit | Yes |  |
| quote_auto_disp_flag | bit | Yes |  |
| rev_num | char | Yes | 3 |
| truck_code | char | Yes | 10 |
| truck_flag | bit | Yes |  |
| truck_auto_disp_flag | bit | Yes |  |
| cust_auto_disp_flag | bit | Yes |  |
| item_flag | bit | Yes |  |
| item_auto_disp_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| note_text | varchar | Yes | -1 |
| disp_opt | varchar | Yes | -1 |

## Table: dbo.comp
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| comp_code | char | No | 4 |
| name | char | No | 40 |
| short_name | char | Yes | 8 |
| acctng_year | numeric | Yes |  |
| net_profit_cost_center | char | Yes | 12 |
| net_profit_acct_code | char | Yes | 6 |
| net_profit_sub_acct_code | char | Yes | 6 |
| rev_cost_center | char | Yes | 12 |
| rev_acct_code | char | Yes | 6 |
| rev_sub_acct_code | char | Yes | 6 |
| finc_chrg_annl_pct | numeric | Yes |  |
| finc_chrg_calc_level_code | char | Yes | 1 |
| finc_chrg_calc_meth_code | char | Yes | 1 |
| finc_chrg_on_finc_chrg_flag | bit | Yes |  |
| finc_chrg_min_amt | numeric | Yes |  |
| finc_chrg_waive_amt | numeric | Yes |  |
| save_detail | numeric | Yes |  |
| save_bal | numeric | Yes |  |
| addr_line_1 | char | Yes | 40 |
| addr_line_2 | char | Yes | 40 |
| addr_line_3 | char | Yes | 40 |
| phone_num | char | Yes | 14 |
| remit_to_line_1 | char | Yes | 40 |
| remit_to_line_2 | char | Yes | 40 |
| remit_to_line_3 | char | Yes | 40 |
| tax_id_code | char | Yes | 20 |
| third_party_credit_id | char | Yes | 12 |
| addr_city | char | Yes | 40 |
| addr_state | char | Yes | 10 |
| addr_cntry | char | Yes | 3 |
| addr_postcd | char | Yes | 10 |
| remit_to_city | char | Yes | 40 |
| remit_to_state | char | Yes | 10 |
| remit_to_cntry | char | Yes | 3 |
| remit_to_postcd | char | Yes | 10 |
| third_party_taxareaid | char | Yes | 10 |
| third_party_edx_id | char | Yes | 40 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cost
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cost_center | char | No | 12 |
| descr | char | No | 40 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| cost_center_abbr | char | Yes | 12 |

## Table: dbo.cprd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| intrnl_line_num | numeric | No |  |
| sort_line_num | numeric | Yes |  |
| prod_code | char | Yes | 12 |
| batch_code | char | Yes | 12 |
| prod_descr | char | Yes | 40 |
| short_prod_descr | char | Yes | 16 |
| est_qty | numeric | Yes |  |
| price_uom | char | Yes | 5 |
| price | numeric | Yes |  |
| price_ext_code | char | Yes | 1 |
| price_plant_code | char | Yes | 3 |
| effect_date | datetime | Yes |  |
| prev_price | numeric | Yes |  |
| prev_price_ext_code | char | Yes | 1 |
| delv_price_flag | bit | Yes |  |
| dflt_load_qty | numeric | Yes |  |
| order_qty_uom | char | Yes | 5 |
| order_qty_ext_code | char | Yes | 1 |
| order_dosage_qty | numeric | Yes |  |
| order_dosage_qty_uom | char | Yes | 5 |
| delv_qty_uom | char | Yes | 5 |
| price_qty_ext_code | char | Yes | 1 |
| tkt_qty_ext_code | char | Yes | 1 |
| usage_code | char | Yes | 4 |
| rm_slump | char | Yes | 8 |
| rm_slump_uom | char | Yes | 5 |
| quote_code | char | Yes | 15 |
| allow_price_adjust_flag | bit | Yes |  |
| sep_invc_flag | bit | Yes |  |
| item_type | char | Yes | 2 |
| override_terms_disc_flag | bit | Yes |  |
| disc_rate_type | char | Yes | 1 |
| disc_amt | numeric | Yes |  |
| disc_amt_uom | char | Yes | 5 |
| content_up_price | numeric | Yes |  |
| content_down_price | numeric | Yes |  |
| content_up_price_effect_date | datetime | Yes |  |
| content_down_price_effect_date | datetime | Yes |  |
| prev_content_up_price | numeric | Yes |  |
| prev_content_down_price | numeric | Yes |  |
| modified_date | datetime | Yes |  |
| type_price | char | Yes | 1 |
| auto_prod_flag | bit | Yes |  |
| item_cat_price_flag | bit | Yes |  |
| auth_user_name | char | Yes | 20 |
| price_status | char | Yes | 2 |
| price_expir_date | datetime | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| ca_sur_codes | varchar | Yes | -1 |
| cb_sur_codes | varchar | Yes | -1 |
| cc_sur_codes | varchar | Yes | -1 |
| cd_sur_codes | varchar | Yes | -1 |
| ca_sur_rates | varchar | Yes | -1 |
| cb_sur_rates | varchar | Yes | -1 |
| cc_sur_rates | varchar | Yes | -1 |
| cd_sur_rates | varchar | Yes | -1 |
| ca_sundry_chrg_table_ids | varchar | Yes | -1 |
| cb_sundry_chrg_table_ids | varchar | Yes | -1 |
| cc_sundry_chrg_table_ids | varchar | Yes | -1 |
| cd_sundry_chrg_table_ids | varchar | Yes | -1 |
| ca_sundry_chrg_sep_invc_flags | varchar | Yes | -1 |
| cb_sundry_chrg_sep_invc_flags | varchar | Yes | -1 |
| cc_sundry_chrg_sep_invc_flags | varchar | Yes | -1 |
| cd_sundry_chrg_sep_invc_flags | varchar | Yes | -1 |

## Table: dbo.cred
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cred_code | char | No | 3 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| cred_type | char | Yes | 1 |
| alt_prt_flag | bit | Yes |  |
| check_cred_flag | bit | Yes |  |
| cred_over_auth_code | char | Yes | 12 |
| disp_descr_flag | bit | Yes |  |
| ca_force_proj_flag | bit | Yes |  |
| cb_force_proj_flag | bit | Yes |  |
| cc_force_proj_flag | bit | Yes |  |
| cd_force_proj_flag | bit | Yes |  |
| ca_exceed_order_qty_flag | bit | Yes |  |
| cb_exceed_order_qty_flag | bit | Yes |  |
| cc_exceed_order_qty_flag | bit | Yes |  |
| cd_exceed_order_qty_flag | bit | Yes |  |
| incr_approved_order_amount | numeric | Yes |  |
| allow_cred_override_auth_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.CT_APPLICATIONEXCEPTIONS
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| UserId | nvarchar | Yes | 255 |
| EarliestDateTime | datetime | Yes |  |
| LatestDateTime | datetime | Yes |  |
| CTVersion | nvarchar | Yes | 20 |
| HostVersion | nvarchar | Yes | 50 |
| MachineName | nvarchar | Yes | 100 |
| MachineLoginName | nvarchar | Yes | 255 |
| ExceptionsCount | int | Yes |  |
| ExceptionMessage | nvarchar | Yes | 4000 |
| InnerExceptionMessage | nvarchar | Yes | 4000 |
| ExceptionStackTrace | nvarchar | Yes | -1 |
| InnerExceptionStackTrace | nvarchar | Yes | -1 |
| AdditionalText | nvarchar | Yes | 4000 |

## Table: dbo.CT_DISP_CONFIG
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| Id | int | No |  |
| UserId | nvarchar | No | 255 |
| Name | nvarchar | No | 50 |
| Disp_Type_Id | int | No |  |
| Value | nvarchar | No | -1 |
| Modified_Date | datetime | No |  |
| Admin_VersionNo | int | Yes |  |
| Admin_UpdatedBy | nvarchar | Yes | 255 |
| Admin_UpdatedDate | datetime | Yes |  |
| Configuration | nvarchar | Yes | 255 |

## Table: dbo.CT_DISP_CONFIG_TYPE
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| DISP_TYPE_ID | int | No |  |
| Name | nvarchar | No | 50 |
| Description | nvarchar | No | 255 |

## Table: dbo.CT_OPTION
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| BACKDOOR_ADMIN_PASSWORD | nvarchar | Yes | 16 |
| ALLOW_APPLICATION_LAUNCH | bit | Yes |  |
| ALLOW_NONADMIN_DB_UPDATE | bit | Yes |  |
| ALLOW_DB_DOWNGRADE | bit | Yes |  |
| ALLOW_PLANT_GROUP_SELECTION | bit | Yes |  |
| MAPIT_SIGNALING_UNITS | nvarchar | Yes | 64 |
| FIVE_CUBITS_CLIENT_ID | nvarchar | Yes | 64 |
| FIVE_CUBITS_CLIENT_SECRET | nvarchar | Yes | 64 |

## Table: dbo.CT_ORIENTATION
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| ORIENTATIONID | int | No |  |
| Culture | nvarchar | No | 50 |
| Orientation | nvarchar | No | 50 |

## Table: dbo.CT_UPGRADE
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| CT_VERSION_NEW | nvarchar | No | 20 |
| SUCCESS | char | No | 1 |
| UPGRADE_DATE_TIME | datetime | No |  |
| CT_VERSION_OLD | nvarchar | Yes | 20 |

## Table: dbo.CT_USER_SET
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| Set_Type_Id | int | No |  |
| Value | nvarchar | No | -1 |
| Modified_Date | datetime | No |  |
| Id | int | No |  |
| UserId | nvarchar | No | 255 |
| Configuration | nvarchar | Yes | 255 |
| Admin_VersionNo | int | Yes |  |
| Admin_UpdatedBy | nvarchar | Yes | 255 |
| Admin_UpdatedDate | datetime | Yes |  |

## Table: dbo.CT_USER_SET_TYPE
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| SET_TYPE_ID | int | No |  |
| Name | nvarchar | No | 50 |
| Description | nvarchar | No | 255 |

## Table: dbo.CT_VERSION
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| KEY_FIELD | int | No |  |
| CT_VERSION | nvarchar | No | 20 |
| UPGRADE_DATE_TIME | datetime | No |  |

## Table: dbo.ctct
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| contct_code | char | No | 12 |
| contct_type | char | Yes | 2 |
| name | char | Yes | 40 |
| addr_line_1 | char | Yes | 40 |
| addr_line_2 | char | Yes | 40 |
| addr_city | char | Yes | 40 |
| addr_state | char | Yes | 10 |
| addr_cntry | char | Yes | 3 |
| addr_postcd | char | Yes | 10 |
| phone_num_1 | char | Yes | 14 |
| phone_num_2 | char | Yes | 14 |
| phone_num_3 | char | Yes | 14 |
| phone_num_4 | char | Yes | 14 |
| email_addr | char | Yes | 256 |
| cust_code | char | Yes | 10 |
| comp_name | char | Yes | 40 |
| email_addr_2 | char | Yes | 256 |
| email_addr_3 | char | Yes | 256 |
| inactive_flag | bit | Yes |  |
| email_addr_mobile | char | Yes | 256 |
| title | char | Yes | 10 |
| phone_num_1_type_code | char | Yes | 2 |
| phone_num_2_type_code | char | Yes | 2 |
| phone_num_3_type_code | char | Yes | 2 |
| phone_num_4_type_code | char | Yes | 2 |
| job_title | char | Yes | 100 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cttn
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| phone_num | char | No | 14 |
| contact_code | char | No | 12 |
| unique_num | numeric | No |  |
| cust_code | char | Yes | 10 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.ctty
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| contct_type | char | No | 2 |
| descr | char | Yes | 40 |
| short_descr | char | Yes | 8 |
| allow_view_by_disptch_flag | bit | Yes |  |
| default_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cuco
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| comp_code | char | No | 4 |
| sort_name | char | Yes | 8 |
| last_stmnt_amt | numeric | Yes |  |
| last_stmnt_date | datetime | Yes |  |
| last_invc_amt | numeric | Yes |  |
| last_invc_date | datetime | Yes |  |
| last_check_amt | numeric | Yes |  |
| last_check_date | datetime | Yes |  |
| curr_bal_amt | numeric | Yes |  |
| curr_ret_amt | numeric | Yes |  |
| high_bal_amt | numeric | Yes |  |
| high_bal_date | datetime | Yes |  |
| cred_code | char | Yes | 3 |
| cred_chng_date | datetime | Yes |  |
| prev_cred_code | char | Yes | 3 |
| cred_limit_amt | numeric | Yes |  |
| ar_cred_empl_code | char | Yes | 12 |
| avg_pmt_days | numeric | Yes |  |
| avg_pmt_trans | numeric | Yes |  |
| booked_orders_amt | numeric | Yes |  |
| shipped_orders_amt | numeric | Yes |  |
| cred_update_date | datetime | Yes |  |
| perform_cred_update_flag | bit | Yes |  |
| modified_date | datetime | Yes |  |
| cc_apply_zone_chrg_flag | bit | Yes |  |
| ca_apply_zone_chrg_flag | bit | Yes |  |
| cb_apply_zone_chrg_flag | bit | Yes |  |
| cd_apply_zone_chrg_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cuhs
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| acctng_year | numeric | No |  |
| acctng_perd | numeric | No |  |
| cust_code | char | No | 10 |
| comp_code | char | No | 4 |
| plant_code | char | No | 3 |
| sort_name | char | Yes | 8 |
| sales_amt | numeric | Yes |  |
| tax_sales_amt | numeric | Yes |  |
| cost_amt | numeric | Yes |  |
| finc_chrg_amt | numeric | Yes |  |
| cred_amt | numeric | Yes |  |
| tax_cred_amt | numeric | Yes |  |
| debit_amt | numeric | Yes |  |
| tax_debit_amt | numeric | Yes |  |
| pmt_amt | numeric | Yes |  |
| disc_taken_amt | numeric | Yes |  |
| adj_amt | numeric | Yes |  |
| tax_adj_amt | numeric | Yes |  |
| net_rev_amt | numeric | Yes |  |
| bal_amt | numeric | Yes |  |
| aging_amt_01 | numeric | Yes |  |
| aging_amt_02 | numeric | Yes |  |
| aging_amt_03 | numeric | Yes |  |
| aging_amt_04 | numeric | Yes |  |
| aging_amt_05 | numeric | Yes |  |
| aging_amt_06 | numeric | Yes |  |
| aging_amt_07 | numeric | Yes |  |
| aging_code_cat_01 | char | Yes | 2 |
| aging_code_cat_02 | char | Yes | 2 |
| aging_code_cat_03 | char | Yes | 2 |
| aging_code_cat_04 | char | Yes | 2 |
| aging_code_cat_05 | char | Yes | 2 |
| aging_code_cat_06 | char | Yes | 2 |
| aging_code_cat_07 | char | Yes | 2 |
| invc_count | numeric | Yes |  |
| finc_chrg_count | numeric | Yes |  |
| cred_count | numeric | Yes |  |
| debit_count | numeric | Yes |  |
| pmt_count_01 | numeric | Yes |  |
| pmt_count_02 | numeric | Yes |  |
| pmt_count_03 | numeric | Yes |  |
| pmt_count_04 | numeric | Yes |  |
| pmt_count_05 | numeric | Yes |  |
| pmt_count_06 | numeric | Yes |  |
| pmt_count_07 | numeric | Yes |  |
| disc_taken_count | numeric | Yes |  |
| adj_count | numeric | Yes |  |
| tax_adj_count | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.curr
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| curr_code | char | No | 4 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| curr_symbol | char | Yes | 2 |
| curr_symbol_plcmnt | char | Yes | 1 |
| thous_sep | char | Yes | 1 |
| dec_sep | char | Yes | 1 |
| dec_places_flag | bit | Yes |  |
| neg_sign | char | Yes | 1 |
| neg_sign_plcmnt | char | Yes | 1 |
| alt_curr_conv_factor | numeric | Yes |  |
| iso_curr_code | char | Yes | 4 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cusc
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| intrnl_line_num | numeric | No |  |
| prod_line_code | char | No | 2 |
| sundry_chrg_table_id | char | No | 3 |
| sort_line_num | numeric | Yes |  |
| item_code | char | Yes | 12 |
| price | numeric | Yes |  |
| price_uom | char | Yes | 5 |
| price_ext_code | char | Yes | 1 |
| effect_date | datetime | Yes |  |
| prev_price | numeric | Yes |  |
| prev_price_ext_code | char | Yes | 1 |
| sep_invc_flag | bit | Yes |  |
| modified_date | datetime | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cuso
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| ca_apply_min_haul_pay_flag | bit | Yes |  |
| cb_apply_min_haul_pay_flag | bit | Yes |  |
| cc_apply_min_haul_pay_flag | bit | Yes |  |
| cd_apply_min_haul_pay_flag | bit | Yes |  |
| ca_allow_price_chng_flag | bit | Yes |  |
| cb_allow_price_chng_flag | bit | Yes |  |
| cc_allow_price_chng_flag | bit | Yes |  |
| cd_allow_price_chng_flag | bit | Yes |  |
| invc_proj_page_break_flag | bit | Yes |  |
| prelien_date_calc_code | char | Yes | 1 |
| tax_exempt_profile_code | char | Yes | 3 |
| ca_allow_price_suppress_flag | bit | Yes |  |
| cb_allow_price_suppress_flag | bit | Yes |  |
| cc_allow_price_suppress_flag | bit | Yes |  |
| cd_allow_price_suppress_flag | bit | Yes |  |
| ca_tkt_print_doc_fmt_code | char | Yes | 8 |
| cb_tkt_print_doc_fmt_code | char | Yes | 8 |
| cc_tkt_print_doc_fmt_code | char | Yes | 8 |
| cd_tkt_print_doc_fmt_code | char | Yes | 8 |
| invc_delv_meth | char | Yes | 2 |
| invc_email_to_addr | char | Yes | 100 |
| invc_email_to_contct_code | char | Yes | 12 |
| addr_city_code | char | Yes | 10 |
| tax_id | char | Yes | 20 |
| state_tax_id | char | Yes | 20 |
| nbrhood | char | Yes | 40 |
| addr_line_1_num | char | Yes | 10 |
| addr_line_1_name | char | Yes | 30 |
| pump_split_tkt_invc_code | char | Yes | 2 |
| stmt_delv_meth | char | Yes | 2 |
| stmt_email_to_addr | char | Yes | 100 |
| stmt_email_to_contct_code | char | Yes | 12 |
| cc_trade_disc_effect_date | datetime | Yes |  |
| cc_prev_trade_disc_amt | numeric | Yes |  |
| cc_prev_trade_disc_pct | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.cust
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| name | char | Yes | 40 |
| sort_name | char | Yes | 8 |
| addr_line_1 | char | Yes | 40 |
| addr_line_2 | char | Yes | 40 |
| addr_city | char | Yes | 40 |
| addr_state | char | Yes | 10 |
| addr_cntry | char | Yes | 3 |
| addr_postcd | char | Yes | 10 |
| contct_name | char | Yes | 40 |
| phone_num_1 | char | Yes | 14 |
| phone_num_2 | char | Yes | 14 |
| phone_num_3 | char | Yes | 14 |
| phone_num_4 | char | Yes | 14 |
| setup_date | datetime | Yes |  |
| invc_name | char | Yes | 40 |
| invc_addr_line_1 | char | Yes | 40 |
| invc_addr_line_2 | char | Yes | 40 |
| invc_city | char | Yes | 40 |
| invc_state | char | Yes | 10 |
| invc_cntry | char | Yes | 3 |
| invc_postcd | char | Yes | 10 |
| stmnt_name | char | Yes | 40 |
| stmnt_addr_line_1 | char | Yes | 40 |
| stmnt_addr_line_2 | char | Yes | 40 |
| stmnt_city | char | Yes | 40 |
| stmnt_state | char | Yes | 10 |
| stmnt_cntry | char | Yes | 3 |
| stmnt_postcd | char | Yes | 10 |
| ca_sales_anl_code | char | Yes | 3 |
| cb_sales_anl_code | char | Yes | 3 |
| cc_sales_anl_code | char | Yes | 3 |
| cd_sales_anl_code | char | Yes | 3 |
| ca_slsmn_empl_code | char | Yes | 12 |
| cb_slsmn_empl_code | char | Yes | 12 |
| cc_slsmn_empl_code | char | Yes | 12 |
| cd_slsmn_empl_code | char | Yes | 12 |
| tax_code | char | Yes | 3 |
| taxble_code | numeric | Yes |  |
| non_tax_rsn_code | char | Yes | 3 |
| tax_id_code | char | Yes | 20 |
| ca_price_cat | char | Yes | 3 |
| cb_price_cat | char | Yes | 3 |
| cc_price_cat | char | Yes | 3 |
| cd_price_cat | char | Yes | 3 |
| ca_price_plant_code | char | Yes | 3 |
| cb_price_plant_code | char | Yes | 3 |
| cc_price_plant_code | char | Yes | 3 |
| cd_price_plant_code | char | Yes | 3 |
| ca_trade_disc_pct | numeric | Yes |  |
| cb_trade_disc_pct | numeric | Yes |  |
| cc_trade_disc_pct | numeric | Yes |  |
| cd_trade_disc_pct | numeric | Yes |  |
| ca_trade_disc_amt | numeric | Yes |  |
| cb_trade_disc_amt | numeric | Yes |  |
| cc_trade_disc_amt | numeric | Yes |  |
| cd_trade_disc_amt | numeric | Yes |  |
| ca_trade_disc_amt_uom | char | Yes | 5 |
| cb_trade_disc_amt_uom | char | Yes | 5 |
| cc_trade_disc_amt_uom | char | Yes | 5 |
| cd_trade_disc_amt_uom | char | Yes | 5 |
| ca_terms_code | char | Yes | 3 |
| cb_terms_code | char | Yes | 3 |
| cc_terms_code | char | Yes | 3 |
| cd_terms_code | char | Yes | 3 |
| ca_cart_code | char | Yes | 3 |
| cb_cart_code | char | Yes | 3 |
| cc_cart_code | char | Yes | 3 |
| cd_cart_code | char | Yes | 3 |
| ca_cart_rate | numeric | Yes |  |
| cb_cart_rate | numeric | Yes |  |
| cc_cart_rate | numeric | Yes |  |
| cd_cart_rate | numeric | Yes |  |
| ca_apply_min_haul_flag | bit | Yes |  |
| cb_apply_min_haul_flag | bit | Yes |  |
| cc_apply_min_haul_flag | bit | Yes |  |
| cd_apply_min_haul_flag | bit | Yes |  |
| ca_apply_zone_chrg_flag | bit | Yes |  |
| cb_apply_zone_chrg_flag | bit | Yes |  |
| cc_apply_zone_chrg_flag | bit | Yes |  |
| cd_apply_zone_chrg_flag | bit | Yes |  |
| ca_zone_code | char | Yes | 8 |
| cb_zone_code | char | Yes | 8 |
| cc_zone_code | char | Yes | 8 |
| cd_zone_code | char | Yes | 8 |
| ca_apply_min_load_chrg_flag | bit | Yes |  |
| cb_apply_min_load_chrg_flag | bit | Yes |  |
| cc_apply_min_load_chrg_flag | bit | Yes |  |
| cd_apply_min_load_chrg_flag | bit | Yes |  |
| ca_min_load_chrg_table_id | char | Yes | 3 |
| cb_min_load_chrg_table_id | char | Yes | 3 |
| cc_min_load_chrg_table_id | char | Yes | 3 |
| cd_min_load_chrg_table_id | char | Yes | 3 |
| ca_apply_excess_unld_chrg_flag | bit | Yes |  |
| cb_apply_excess_unld_chrg_flag | bit | Yes |  |
| cc_apply_excess_unld_chrg_flag | bit | Yes |  |
| cd_apply_excess_unld_chrg_flag | bit | Yes |  |
| ca_excess_unld_chrg_table_id | char | Yes | 3 |
| cb_excess_unld_chrg_table_id | char | Yes | 3 |
| cc_excess_unld_chrg_table_id | char | Yes | 3 |
| cd_excess_unld_chrg_table_id | char | Yes | 3 |
| ca_apply_season_chrg_flag | bit | Yes |  |
| cb_apply_season_chrg_flag | bit | Yes |  |
| cc_apply_season_chrg_flag | bit | Yes |  |
| cd_apply_season_chrg_flag | bit | Yes |  |
| ca_season_chrg_table_id | char | Yes | 3 |
| cb_season_chrg_table_id | char | Yes | 3 |
| cc_season_chrg_table_id | char | Yes | 3 |
| cd_season_chrg_table_id | char | Yes | 3 |
| ca_apply_sundry_chrg_flag | bit | Yes |  |
| cb_apply_sundry_chrg_flag | bit | Yes |  |
| cc_apply_sundry_chrg_flag | bit | Yes |  |
| cd_apply_sundry_chrg_flag | bit | Yes |  |
| ca_min_load_sep_invc_flag | bit | Yes |  |
| cb_min_load_sep_invc_flag | bit | Yes |  |
| cc_min_load_sep_invc_flag | bit | Yes |  |
| cd_min_load_sep_invc_flag | bit | Yes |  |
| ca_excess_unld_sep_invc_flag | bit | Yes |  |
| cb_excess_unld_sep_invc_flag | bit | Yes |  |
| cc_excess_unld_sep_invc_flag | bit | Yes |  |
| cd_excess_unld_sep_invc_flag | bit | Yes |  |
| ca_season_sep_invc_flag | bit | Yes |  |
| cb_season_sep_invc_flag | bit | Yes |  |
| cc_season_sep_invc_flag | bit | Yes |  |
| cd_season_sep_invc_flag | bit | Yes |  |
| ca_auto_sundry_sep_invc_flag | bit | Yes |  |
| cb_auto_sundry_sep_invc_flag | bit | Yes |  |
| cc_auto_sundry_sep_invc_flag | bit | Yes |  |
| cd_auto_sundry_sep_invc_flag | bit | Yes |  |
| ca_apply_cart_rate_hler_flag | bit | Yes |  |
| cb_apply_cart_rate_hler_flag | bit | Yes |  |
| cc_apply_cart_rate_hler_flag | bit | Yes |  |
| cd_apply_cart_rate_hler_flag | bit | Yes |  |
| ca_apply_sur_rate_hler_flag | bit | Yes |  |
| cb_apply_sur_rate_hler_flag | bit | Yes |  |
| cc_apply_sur_rate_hler_flag | bit | Yes |  |
| cd_apply_sur_rate_hler_flag | bit | Yes |  |
| ca_print_tkt_prices_flag | bit | Yes |  |
| cb_print_tkt_prices_flag | bit | Yes |  |
| cc_print_tkt_prices_flag | bit | Yes |  |
| cd_print_tkt_prices_flag | bit | Yes |  |
| ca_force_price_uom_flag | bit | Yes |  |
| cb_force_price_uom_flag | bit | Yes |  |
| cc_force_price_uom_flag | bit | Yes |  |
| cd_force_price_uom_flag | bit | Yes |  |
| ca_restrict_quoted_prod_flag | bit | Yes |  |
| cb_restrict_quoted_prod_flag | bit | Yes |  |
| cc_restrict_quoted_prod_flag | bit | Yes |  |
| cd_restrict_quoted_prod_flag | bit | Yes |  |
| allow_price_adjust_flag | bit | Yes |  |
| ar_type_code | char | Yes | 1 |
| stmnt_cycle_code | char | Yes | 1 |
| finc_chrg_flag | bit | Yes |  |
| print_stmnt_flag | bit | Yes |  |
| po_req_flag | bit | Yes |  |
| cust_job_num_req_flag | bit | Yes |  |
| acct_cat_code | char | Yes | 4 |
| cred_limtn_code | char | Yes | 3 |
| cred_card_name | char | Yes | 40 |
| cred_card_num | char | Yes | 30 |
| cred_card_expir_date | datetime | Yes |  |
| cred_card_resp_name | char | Yes | 40 |
| susp_rsn_code | char | Yes | 3 |
| invc_grouping_code | char | Yes | 1 |
| invc_sub_grouping_code | char | Yes | 1 |
| invc_det_sum_code | char | Yes | 1 |
| invc_single_mult_day_code | char | Yes | 1 |
| invc_freq_code | char | Yes | 1 |
| invc_copies | numeric | Yes |  |
| invc_comb_haul_flag | bit | Yes |  |
| invc_show_min_haul_flag | bit | Yes |  |
| invc_sep_by_prod_line_flag | bit | Yes |  |
| ca_track_order_color | numeric | Yes |  |
| cb_track_order_color | numeric | Yes |  |
| cc_track_order_color | numeric | Yes |  |
| cd_track_order_color | numeric | Yes |  |
| ca_print_mix_wgts_flag | bit | Yes |  |
| cb_print_mix_wgts_flag | bit | Yes |  |
| cc_print_mix_wgts_flag | bit | Yes |  |
| cd_print_mix_wgts_flag | bit | Yes |  |
| metric_cstmry_code | char | Yes | 1 |
| intrnl_line_num | numeric | Yes |  |
| quote_flag | bit | Yes |  |
| lien_loc_req_code | char | Yes | 1 |
| lien_exp_flag | bit | Yes |  |
| ca_dflt_order_type | char | Yes | 2 |
| cb_dflt_order_type | char | Yes | 2 |
| cc_dflt_order_type | char | Yes | 2 |
| cd_dflt_order_type | char | Yes | 2 |
| ca_cart_rate_effect_date | datetime | Yes |  |
| cb_cart_rate_effect_date | datetime | Yes |  |
| cc_cart_rate_effect_date | datetime | Yes |  |
| cd_cart_rate_effect_date | datetime | Yes |  |
| ca_prev_cart_rate | numeric | Yes |  |
| cb_prev_cart_rate | numeric | Yes |  |
| cc_prev_cart_rate | numeric | Yes |  |
| cd_prev_cart_rate | numeric | Yes |  |
| priority | numeric | Yes |  |
| max_mins_early | numeric | Yes |  |
| max_mins_late | numeric | Yes |  |
| dataout_date | datetime | Yes |  |
| modified_date | datetime | Yes |  |
| restrict_ordr_by_estqty_code | char | Yes | 2 |
| ca_print_tkt_costs_flag | bit | Yes |  |
| cb_print_tkt_costs_flag | bit | Yes |  |
| cc_print_tkt_costs_flag | bit | Yes |  |
| cd_print_tkt_costs_flag | bit | Yes |  |
| ca_print_tkt_totals_flag | bit | Yes |  |
| cb_print_tkt_totals_flag | bit | Yes |  |
| cc_print_tkt_totals_flag | bit | Yes |  |
| cd_print_tkt_totals_flag | bit | Yes |  |
| ca_print_for_cash_orders | bit | Yes |  |
| cb_print_for_cash_orders | bit | Yes |  |
| cc_print_for_cash_orders | bit | Yes |  |
| cd_print_for_cash_orders | bit | Yes |  |
| ca_print_for_charge_orders | bit | Yes |  |
| cb_print_for_charge_orders | bit | Yes |  |
| cc_print_for_charge_orders | bit | Yes |  |
| cd_print_for_charge_orders | bit | Yes |  |
| mobileticket_code | char | Yes | 2 |
| guid | char | Yes | 36 |
| inactive_code | char | Yes | 2 |
| inactive_date | datetime | Yes |  |
| edx_synch_status_code | char | Yes | 1 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| tax_exempt_id | varchar | Yes | -1 |
| user_defined | varchar | Yes | -1 |
| ca_order_sur_codes | varchar | Yes | -1 |
| cb_order_sur_codes | varchar | Yes | -1 |
| cc_order_sur_codes | varchar | Yes | -1 |
| cd_order_sur_codes | varchar | Yes | -1 |
| ca_order_sur_rates | varchar | Yes | -1 |
| cb_order_sur_rates | varchar | Yes | -1 |
| cc_order_sur_rates | varchar | Yes | -1 |
| cb_sundry_chrg_table_ids | varchar | Yes | -1 |
| cd_order_sur_rates | varchar | Yes | -1 |
| ca_sundry_chrg_table_ids | varchar | Yes | -1 |
| cc_sundry_chrg_table_ids | varchar | Yes | -1 |
| cd_sundry_chrg_table_ids | varchar | Yes | -1 |
| ca_sundry_chrg_sep_invc_flags | varchar | Yes | -1 |
| cb_sundry_chrg_sep_invc_flags | varchar | Yes | -1 |
| cc_sundry_chrg_sep_invc_flags | varchar | Yes | -1 |
| cd_sundry_chrg_sep_invc_flags | varchar | Yes | -1 |

## Table: dbo.cwhd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| report_id | char | No | 8 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| pswd | char | Yes | 16 |
| page_len | numeric | Yes |  |
| cell_id | numeric | Yes |  |
| order_by | char | Yes | 30 |
| select_form | char | Yes | 8 |
| verify_flag | bit | Yes |  |
| predef_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| section_list | varchar | Yes | -1 |
| file_list | varchar | Yes | -1 |
| sort_list | varchar | Yes | -1 |
| variable_list | varchar | Yes | -1 |
| profile_expr | varchar | Yes | -1 |
| select_expr | varchar | Yes | -1 |
| merge_expr | varchar | Yes | -1 |

## Table: dbo.cwln
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| report_id | char | No | 8 |
| cell_id | numeric | No |  |
| cell_row | numeric | Yes |  |
| cell_col | numeric | Yes |  |
| cell_sec | char | Yes | 3 |
| cell_type | char | Yes | 1 |
| cell_field | char | Yes | 40 |
| cell_attr | char | Yes | 1 |
| cell_mask_len | numeric | Yes |  |
| cell_mask_type | char | Yes | 1 |
| cell_mask_seg | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| cell_text | varchar | Yes | -1 |
| cell_mask | varchar | Yes | -1 |
| cell_expr | varchar | Yes | -1 |
| cell_when_expr | varchar | Yes | -1 |
| cell_attr_expr | varchar | Yes | -1 |

## Table: dbo.docf
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| doc_fmt_code | char | No | 8 |
| unique_num | numeric | No |  |
| line_num | numeric | Yes |  |
| field_type | numeric | Yes |  |
| field_name | char | Yes | 6 |
| field_occ | numeric | Yes |  |
| field_sub_occ | numeric | Yes |  |
| field_sub_sub_occ | numeric | Yes |  |
| field_attr_1 | numeric | Yes |  |
| field_attr_2 | numeric | Yes |  |
| field_attr_3 | numeric | Yes |  |
| field_attr_4 | numeric | Yes |  |
| field_start_pos | numeric | Yes |  |
| field_end_pos | numeric | Yes |  |
| field_left_flag | bit | Yes |  |
| field_mask | char | Yes | 160 |
| field_prod_line_code | char | Yes | 2 |
| database_field_name | char | Yes | 40 |
| html_width | numeric | Yes |  |
| html_height | numeric | Yes |  |
| html_left | numeric | Yes |  |
| html_top | numeric | Yes |  |
| image_source | char | Yes | 100 |
| html_style | char | Yes | 100 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.docg
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| doc_fmt_group_code | char | No | 8 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| doc_fmt_group_type | char | Yes | 2 |
| doc_fmt_code_01 | char | Yes | 8 |
| doc_fmt_code_type_01 | char | Yes | 2 |
| doc_fmt_code_02 | char | Yes | 8 |
| doc_fmt_code_type_02 | char | Yes | 2 |
| doc_fmt_code_03 | char | Yes | 8 |
| doc_fmt_code_type_03 | char | Yes | 2 |
| doc_fmt_code_04 | char | Yes | 8 |
| doc_fmt_code_type_04 | char | Yes | 2 |
| doc_fmt_code_05 | char | Yes | 8 |
| doc_fmt_code_type_05 | char | Yes | 2 |
| doc_fmt_code_06 | char | Yes | 8 |
| doc_fmt_code_type_06 | char | Yes | 2 |
| doc_fmt_code_07 | char | Yes | 8 |
| doc_fmt_code_type_07 | char | Yes | 2 |
| doc_fmt_code_08 | char | Yes | 8 |
| doc_fmt_code_type_08 | char | Yes | 2 |
| doc_fmt_code_09 | char | Yes | 8 |
| doc_fmt_code_type_09 | char | Yes | 2 |
| doc_fmt_code_10 | char | Yes | 8 |
| doc_fmt_code_type_10 | char | Yes | 2 |
| det_lines | numeric | Yes |  |
| use_fast_reports_code | bit | Yes |  |
| keep_template_file_code | char | Yes | 2 |
| template_file_name | char | Yes | 60 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.docs
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| doc_fmt_code | char | No | 8 |
| descr | char | Yes | 40 |
| short_descr | char | Yes | 8 |
| doc_type | char | Yes | 2 |
| eof_code | numeric | Yes |  |
| print_method_code | char | Yes | 1 |
| unique_num | numeric | Yes |  |
| doc_username | char | Yes | 40 |
| doc_password | char | Yes | 40 |
| doc_table_name | char | Yes | 40 |
| use_html | char | Yes | 2 |
| html_line_spacing | numeric | Yes |  |
| template_file_name | char | Yes | 60 |
| keep_template_file_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| doc_connect_string | varchar | Yes | 2000 |

## Table: dbo.doct
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| doc_type | char | No | 2 |
| tag_name | char | No | 6 |
| descr | char | Yes | 40 |
| tag_type | char | Yes | 1 |
| file_name | char | Yes | 4 |
| field_name | char | Yes | 32 |
| field_data_type | char | Yes | 1 |
| lookup_file_name | char | Yes | 4 |
| multi_occ_flag | bit | Yes |  |
| key_fmt_flag | bit | Yes |  |
| prod_line_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| lookup_field_names | varchar | Yes | -1 |

## Table: dbo.drvt
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_date | datetime | No |  |
| driv_empl_code | char | No | 12 |
| punch_in_time_1 | datetime | Yes |  |
| punch_in_time_2 | datetime | Yes |  |
| punch_in_time_3 | datetime | Yes |  |
| punch_in_time_4 | datetime | Yes |  |
| punch_in_time_5 | datetime | Yes |  |
| punch_in_time_6 | datetime | Yes |  |
| punch_out_time_1 | datetime | Yes |  |
| punch_out_time_2 | datetime | Yes |  |
| punch_out_time_3 | datetime | Yes |  |
| punch_out_time_4 | datetime | Yes |  |
| punch_out_time_5 | datetime | Yes |  |
| punch_out_time_6 | datetime | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.emlg
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| unique_num | numeric | No |  |
| contact_code | char | Yes | 8 |
| user_name | char | Yes | 20 |
| request_date | datetime | Yes |  |
| delivered_date | datetime | Yes |  |
| is_delivered | bit | Yes |  |
| document_date | datetime | Yes |  |
| document_code | char | Yes | 36 |
| document_type | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| xml_message | varchar | Yes | -1 |
| xml_error_text | varchar | Yes | -1 |
| file_list | varchar | Yes | -1 |
| attachment_list | varchar | Yes | -1 |

## Table: dbo.empl
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| empl_code | char | No | 12 |
| name | char | Yes | 40 |
| short_name | char | Yes | 8 |
| addr_line_1 | char | Yes | 40 |
| addr_line_2 | char | Yes | 40 |
| addr_city | char | Yes | 40 |
| addr_state | char | Yes | 10 |
| addr_cntry | char | Yes | 3 |
| addr_postcd | char | Yes | 10 |
| phone_num | char | Yes | 14 |
| phone_line_num | numeric | Yes |  |
| assgn_plant_code | char | Yes | 3 |
| dflt_truck_code | char | Yes | 10 |
| pr_code | char | Yes | 20 |
| snrty_code | numeric | Yes |  |
| driv_flag | bit | Yes |  |
| slsmn_flag | bit | Yes |  |
| weigh_master_flag | bit | Yes |  |
| ar_cred_flag | bit | Yes |  |
| batchmn_flag | bit | Yes |  |
| weigh_master_lic_num | char | Yes | 20 |
| driv_ot_code | char | Yes | 4 |
| calc_time_flag | bit | Yes |  |
| super_empl_code | char | Yes | 12 |
| email_addr | char | Yes | 100 |
| email_addr_2 | char | Yes | 100 |
| email_addr_3 | char | Yes | 100 |
| off_until_date | datetime | Yes |  |
| guid | char | Yes | 36 |
| empl_status_code | char | Yes | 2 |
| snrty_group_code | char | Yes | 12 |
| alternate_empl_code | char | Yes | 12 |
| union_steward_code | char | Yes | 2 |
| snrty_group_cost_tier_code | numeric | Yes |  |
| floater_flag | bit | Yes |  |
| unassigned_flag | bit | Yes |  |
| inspector_flag | bit | Yes |  |
| inactive_code | char | Yes | 2 |
| inactive_date | datetime | Yes |  |
| driv_efficiency | numeric | Yes |  |
| batcher_efficiency | numeric | Yes |  |
| hard_leash_flag | bit | Yes |  |
| hard_leash_distance | numeric | Yes |  |
| max_shift_time | datetime | Yes |  |
| driver_team | char | Yes | 2 |
| default_driver_note | char | Yes | 200 |
| earliest_callin_time | datetime | Yes |  |
| sync_external_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.emtm
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| unique_num | numeric | No |  |
| order_date | datetime | Yes |  |
| order_code | char | Yes | 12 |
| tkt_code | char | Yes | 8 |
| empl_code | char | Yes | 12 |
| start_time | datetime | Yes |  |
| end_time | datetime | Yes |  |
| task_code | char | Yes | 5 |
| empl_clock_flag | bit | Yes |  |
| empl_productive_flag | bit | Yes |  |
| empl_dot_flag | bit | Yes |  |
| start_status | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.etsk
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| task_code | char | No | 5 |
| descr | char | Yes | 40 |
| short_descr | char | Yes | 8 |
| empl_clock_flag | bit | Yes |  |
| empl_productive_flag | bit | Yes |  |
| empl_dot_flag | bit | Yes |  |
| truck_clock_flag | bit | Yes |  |
| truck_productive_flag | bit | Yes |  |
| condition_code | char | Yes | 5 |
| reserved_task_flag | bit | Yes |  |
| task_type_code | char | Yes | 2 |
| persist_task_code | char | Yes | 2 |
| mandatory_flag | bit | Yes |  |
| applicable_code | char | Yes | 2 |
| empl_planned_flag | bit | Yes |  |
| end_of_day_flag | char | Yes | 2 |
| in_yard | bit | Yes |  |
| approval_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.evcd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| event_code | char | No | 3 |
| severity | char | Yes | 2 |
| db_enabled | char | Yes | 2 |
| wel_enabled | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.EXPD
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| PRIM_KEY | char | No | 36 |
| EXP_IID | char | Yes | 36 |
| WINUSER_NAME | char | Yes | 32 |
| CSUSER_NAME | char | Yes | 32 |
| CSGROUP_NAME | char | Yes | 32 |
| TRANSACTION_NO | numeric | Yes |  |
| UPDATE_WINUSER_NAME | char | Yes | 32 |
| UPDATE_CSUSER_NAME | char | Yes | 32 |
| UPDATE_DATE | datetime | Yes |  |
| U_VERSION | char | Yes | 1 |
| XML | text | Yes | 2147483647 |

## Table: dbo.fcus
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| user_name | char | No | 20 |
| form_name | char | No | 16 |
| file_name | char | No | 6 |
| field_name | char | No | 40 |
| column_name | char | No | 40 |
| width | numeric | Yes |  |
| filter_type | char | Yes | 40 |
| filter_from | char | Yes | 200 |
| filter_thru | char | Yes | 80 |
| sort_order | numeric | Yes |  |
| col_seq_num | numeric | Yes |  |
| override_column | char | Yes | 1000 |
| type | char | Yes | 2 |
| sel_seq_num | numeric | Yes |  |
| filter_type_index | numeric | Yes |  |
| show_delete_record_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.game
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| user_name | char | No | 20 |
| curr_amt | numeric | Yes |  |
| loan_amt | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| stats | varchar | Yes | 2000 |

## Table: dbo.glcd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| gl_entry_code | numeric | No |  |
| gl_entity_code | numeric | No |  |
| gl_entity_key_code | char | No | 30 |
| cost_center | char | Yes | 12 |
| acct_code | char | Yes | 6 |
| sub_acct_code | char | Yes | 6 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.gldt
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| batch_date | datetime | No |  |
| batch_num | numeric | No |  |
| batch_seq | numeric | No |  |
| batch_sub_seq | numeric | No |  |
| trans_type | numeric | Yes |  |
| cost_center | char | Yes | 12 |
| acct_code | char | Yes | 6 |
| sub_acct_code | char | Yes | 6 |
| prod_code | char | Yes | 12 |
| qty | numeric | Yes |  |
| qty_uom | char | Yes | 5 |
| trans_date | datetime | Yes |  |
| trans_amt | numeric | Yes |  |
| ref_note | char | Yes | 40 |
| gl_dist_type | char | Yes | 1 |
| post_stat | char | Yes | 1 |
| updt_stat | bit | Yes |  |
| comp_code | char | Yes | 4 |
| cf_batch_date | datetime | Yes |  |
| cf_batch_num | numeric | Yes |  |
| cf_batch_seq | numeric | Yes |  |
| qty_trans_flag | bit | Yes |  |
| acct_code_derived_from_code | char | Yes | 6 |
| sub_acct_derived_from_code | char | Yes | 6 |
| cost_center_derived_from_code | char | Yes | 6 |
| dataout_date | datetime | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.glpd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| comp_code | char | No | 4 |
| acctng_year | numeric | No |  |
| acctng_perd | numeric | Yes |  |
| perd_begin_date_01 | datetime | Yes |  |
| perd_begin_date_02 | datetime | Yes |  |
| perd_begin_date_03 | datetime | Yes |  |
| perd_begin_date_04 | datetime | Yes |  |
| perd_begin_date_05 | datetime | Yes |  |
| perd_begin_date_06 | datetime | Yes |  |
| perd_begin_date_07 | datetime | Yes |  |
| perd_begin_date_08 | datetime | Yes |  |
| perd_begin_date_09 | datetime | Yes |  |
| perd_begin_date_10 | datetime | Yes |  |
| perd_begin_date_11 | datetime | Yes |  |
| perd_begin_date_12 | datetime | Yes |  |
| perd_begin_date_13 | datetime | Yes |  |
| perd_end_date_01 | datetime | Yes |  |
| perd_end_date_02 | datetime | Yes |  |
| perd_end_date_03 | datetime | Yes |  |
| perd_end_date_04 | datetime | Yes |  |
| perd_end_date_05 | datetime | Yes |  |
| perd_end_date_06 | datetime | Yes |  |
| perd_end_date_07 | datetime | Yes |  |
| perd_end_date_08 | datetime | Yes |  |
| perd_end_date_09 | datetime | Yes |  |
| perd_end_date_10 | datetime | Yes |  |
| perd_end_date_11 | datetime | Yes |  |
| perd_end_date_12 | datetime | Yes |  |
| perd_end_date_13 | datetime | Yes |  |
| perd_open_01 | bit | Yes |  |
| perd_open_02 | bit | Yes |  |
| perd_open_03 | bit | Yes |  |
| perd_open_04 | bit | Yes |  |
| perd_open_05 | bit | Yes |  |
| perd_open_06 | bit | Yes |  |
| perd_open_07 | bit | Yes |  |
| perd_open_08 | bit | Yes |  |
| perd_open_09 | bit | Yes |  |
| perd_open_10 | bit | Yes |  |
| perd_open_11 | bit | Yes |  |
| perd_open_12 | bit | Yes |  |
| perd_open_13 | bit | Yes |  |
| budget_1 | bit | Yes |  |
| budget_2 | bit | Yes |  |
| budget_3 | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.hler
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| hler_code | char | No | 8 |
| name | char | Yes | 40 |
| contct_name | char | Yes | 40 |
| phone_num | char | Yes | 14 |
| comp_code | char | Yes | 4 |
| insur_name | char | Yes | 40 |
| insur_expir_date | datetime | Yes |  |
| rental_flag | bit | Yes |  |
| addr_city_code | char | Yes | 10 |
| addr_line_1 | char | Yes | 40 |
| addr_line_2 | char | Yes | 40 |
| addr_city | char | Yes | 40 |
| addr_state | char | Yes | 10 |
| addr_cntry | char | Yes | 3 |
| addr_postcd | char | Yes | 10 |
| tax_id | char | Yes | 20 |
| state_tax_id | char | Yes | 20 |
| addr_line_1_num | char | Yes | 10 |
| addr_line_1_name | char | Yes | 30 |
| guid | char | Yes | 36 |
| inactive_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.iapd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| item_code | char | No | 12 |
| loc_code | char | No | 4 |
| auto_prod_code | char | No | 12 |
| sort_line_num | numeric | Yes |  |
| descr | char | Yes | 40 |
| qty | numeric | Yes |  |
| qty_uom | char | Yes | 5 |
| modified_date | datetime | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.icat
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| item_cat | char | No | 6 |
| descr | char | Yes | 40 |
| short_descr | char | Yes | 8 |
| item_type | char | Yes | 2 |
| matl_type | char | Yes | 1 |
| dflt_order_uom | char | Yes | 5 |
| dflt_price_uom | char | Yes | 5 |
| dflt_batch_uom | char | Yes | 5 |
| dflt_invy_uom | char | Yes | 5 |
| dflt_order_qty_ext_code | char | Yes | 1 |
| dflt_order_dosage_qty | numeric | Yes |  |
| dflt_order_dosage_qty_uom | char | Yes | 5 |
| dflt_price_qty_ext_code | char | Yes | 1 |
| dflt_tkt_qty_ext_code | char | Yes | 1 |
| dflt_delv_uom | char | Yes | 5 |
| dflt_per_cem_wgt_divisor | numeric | Yes |  |
| dflt_purch_uom | char | Yes | 5 |
| dflt_taxble_code | numeric | Yes |  |
| dflt_tax_rate_code | numeric | Yes |  |
| dflt_strgth | numeric | Yes |  |
| dflt_strgth_uom | char | Yes | 5 |
| dflt_slump | char | Yes | 8 |
| dflt_slump_uom | char | Yes | 5 |
| dflt_rpt_uom | char | Yes | 5 |
| dflt_cem_type | char | Yes | 8 |
| dflt_agg_size | char | Yes | 8 |
| dflt_min_temp | numeric | Yes |  |
| dflt_pct_recycle | numeric | Yes |  |
| dispens_type_code | char | Yes | 1 |
| tax_class_code | char | Yes | 8 |
| fiscal_note_ncm | char | Yes | 8 |
| dflt_proj_restrict | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| note_text | varchar | Yes | -1 |

## Table: dbo.icst
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| item_code | char | No | 12 |
| loc_code | char | No | 4 |
| const_item_code | char | No | 12 |
| sort_line_num | numeric | Yes |  |
| qty | numeric | Yes |  |
| qty_uom | char | Yes | 5 |
| vol_pct | numeric | Yes |  |
| modified_date | datetime | Yes |  |
| dose_qty | numeric | Yes |  |
| trim_adj | numeric | Yes |  |
| trim_adj_uom | char | Yes | 5 |
| design_qty | numeric | Yes |  |
| design_qty_uom | char | Yes | 5 |
| water_trim | numeric | Yes |  |
| water_trim_uom | char | Yes | 5 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.ictx
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| item_cat | char | No | 6 |
| tax_auth | char | No | 4 |
| tax_loc | char | No | 8 |
| taxble_code | char | Yes | 1 |
| non_tax_rsn_code | char | Yes | 3 |
| override_rate_cur_pct | numeric | Yes |  |
| override_rate_effect_date | datetime | Yes |  |
| override_rate_prev_pct | numeric | Yes |  |
| override_tax_loc | char | Yes | 8 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.idtl
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| loc_code | char | No | 4 |
| trans_date | datetime | No |  |
| doc_num | numeric | No |  |
| seq_num | numeric | No |  |
| trfs_to_loc_code | char | Yes | 4 |
| sub_seq_num | numeric | Yes |  |
| item_code | char | Yes | 12 |
| trans_type | numeric | Yes |  |
| unique_num | numeric | Yes |  |
| qty | numeric | Yes |  |
| qty_uom | char | Yes | 5 |
| appl_code | char | Yes | 2 |
| matl_ven_code | char | Yes | 10 |
| haul_ven_code | char | Yes | 10 |
| matl_po_num | char | Yes | 15 |
| haul_po_num | char | Yes | 15 |
| tkt_code | char | Yes | 8 |
| matl_cost | numeric | Yes |  |
| matl_cost_uom | char | Yes | 5 |
| haul_cost | numeric | Yes |  |
| haul_cost_uom | char | Yes | 5 |
| labor_cost | numeric | Yes |  |
| labor_cost_uom | char | Yes | 5 |
| frt_meth | char | Yes | 2 |
| truck_code | char | Yes | 10 |
| hler_code | char | Yes | 8 |
| bol | char | Yes | 16 |
| post_stat | numeric | Yes |  |
| ship_terms | numeric | Yes |  |
| matl_cost_ext_code | numeric | Yes |  |
| haul_cost_ext_code | numeric | Yes |  |
| labor_cost_ext_code | numeric | Yes |  |
| po_stat_code | numeric | Yes |  |
| ordered_qty | numeric | Yes |  |
| ordered_qty_uom | char | Yes | 5 |
| adj_qty_flag | bit | Yes |  |
| adj_to_qty_flag | bit | Yes |  |
| cost_adj_type | numeric | Yes |  |
| pct_markup | numeric | Yes |  |
| markup_on_matl_cost | numeric | Yes |  |
| replcmnt_cost | numeric | Yes |  |
| replcmnt_cost_ext_code | char | Yes | 1 |
| avg_cost | numeric | Yes |  |
| avg_cost_ext_code | char | Yes | 1 |
| std_cost | numeric | Yes |  |
| std_cost_ext_code | char | Yes | 1 |
| rsn_code | char | Yes | 3 |
| invy_rsn_code | char | Yes | 3 |
| haul_distance | numeric | Yes |  |
| haul_distance_uom | char | Yes | 5 |
| haul_pct | numeric | Yes |  |
| haul_wgt | numeric | Yes |  |
| haul_wgt_uom | char | Yes | 5 |
| adj_to_qty | numeric | Yes |  |
| cumul_avg_bal | numeric | Yes |  |
| created_date | datetime | Yes |  |
| haul_tkt_code | char | Yes | 12 |
| from_loc_code | char | Yes | 4 |
| from_seq_num | numeric | Yes |  |
| delivery_guid | char | Yes | 36 |
| saleable_item_code | char | Yes | 12 |
| guid | char | Yes | 36 |
| adj_qty_rev_flag | bit | Yes |  |
| rev_orig_doc_num | numeric | Yes |  |
| rev_orig_trans_date | datetime | Yes |  |
| rev_orig_seq_num | numeric | Yes |  |
| receipt_tkt_code | char | Yes | 50 |
| order_date | datetime | Yes |  |
| order_code | char | Yes | 12 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.igw2
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| user_name | char | No | 20 |
| comp_code | char | No | 4 |
| order_code | char | No | 12 |
| order_date | datetime | No |  |
| tkt_code | char | No | 8 |
| postcd | char | Yes | 10 |
| order_type | char | Yes | 1 |
| cust_name | char | Yes | 20 |
| cust_code | char | Yes | 10 |
| proj_code | char | Yes | 12 |
| invc_code | char | Yes | 12 |
| invc_seq_num | numeric | Yes |  |
| acct_cat_code | char | Yes | 4 |
| slsmn_empl_code | char | Yes | 12 |
| invc_delv_meth | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.iloc
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| item_code | char | No | 12 |
| loc_code | char | No | 4 |
| curr_std_cost | numeric | Yes |  |
| prev_std_cost | numeric | Yes |  |
| cost_ext_code | char | Yes | 1 |
| prev_cost_ext_code | char | Yes | 1 |
| mixer_time | numeric | Yes |  |
| moist_pct | numeric | Yes |  |
| spec_grav | numeric | Yes |  |
| batch_uom | char | Yes | 5 |
| batch_code | char | Yes | 12 |
| batch_mix_dwnld_flag | bit | Yes |  |
| max_batch_size | numeric | Yes |  |
| max_qty | numeric | Yes |  |
| min_qty | numeric | Yes |  |
| reord_qty | numeric | Yes |  |
| reord_point | numeric | Yes |  |
| lead_time | numeric | Yes |  |
| std_cost_effect_date | datetime | Yes |  |
| last_date_used | datetime | Yes |  |
| last_date_ordered | datetime | Yes |  |
| stor_loc_code | char | Yes | 10 |
| matl_type | char | Yes | 1 |
| yield | numeric | Yes |  |
| yield_uom | char | Yes | 5 |
| water_cem_ratio | numeric | Yes |  |
| vol_adj_item_code | char | Yes | 12 |
| slurry_adj_item_code | char | Yes | 12 |
| batch_seq_code | char | Yes | 4 |
| dischrg_seq_code | char | Yes | 4 |
| override_terms_disc_flag | bit | Yes |  |
| disc_rate_type | char | Yes | 1 |
| disc_amt | numeric | Yes |  |
| disc_amt_uom | char | Yes | 5 |
| qc_code | char | Yes | 1 |
| cem_content | numeric | Yes |  |
| cemnt_content | numeric | Yes |  |
| contri_pct_to_cem_content | numeric | Yes |  |
| max_slump | char | Yes | 8 |
| min_slump | char | Yes | 8 |
| slump | char | Yes | 8 |
| modifier_slump | char | Yes | 8 |
| slump_uom | char | Yes | 5 |
| air_pct | numeric | Yes |  |
| lwt_qty | numeric | Yes |  |
| modified_date | datetime | Yes |  |
| order_dosage_qty | numeric | Yes |  |
| order_qty_ext_code | char | Yes | 1 |
| per_cem_wgt_divisor | numeric | Yes |  |
| loading_speed_code | char | Yes | 5 |
| item_status_code | char | Yes | 2 |
| guid | char | Yes | 36 |
| batch_matl_flag | bit | Yes |  |
| solid_matl_spec_grav | numeric | Yes |  |
| admix_effectiveness | numeric | Yes |  |
| wa24_content | numeric | Yes |  |
| assoc_prod_load_time | numeric | Yes |  |
| edx_synch_status_code | char | Yes | 1 |
| rmr_indicator_code | char | Yes | 2 |
| loading_speed_pct | numeric | Yes |  |
| curr_opt_cost | numeric | Yes |  |
| prev_opt_cost | numeric | Yes |  |
| opt_cost_effect_date | datetime | Yes |  |
| mobileticket_code | char | Yes | 2 |
| inactive_code | char | Yes | 2 |
| inactive_date | datetime | Yes |  |
| over_mixing_time_allow | numeric | Yes |  |
| order_num | char | Yes | 9 |
| version | char | Yes | 2 |
| seq_num | char | Yes | 2 |
| external_plant_code | char | Yes | 7 |
| mix_revision_num | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.imlb
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| item_code | char | No | 12 |
| loc_code | char | No | 4 |
| batch_code | char | No | 12 |
| sort_line_num | numeric | Yes |  |
| descr | char | Yes | 40 |
| short_descr | char | Yes | 16 |
| modified_date | datetime | Yes |  |
| dwnld_descr | bit | Yes |  |
| order_num | char | Yes | 9 |
| version | char | Yes | 2 |
| seq_num | char | Yes | 2 |
| external_plant_code | char | Yes | 7 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.imst
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| item_code | char | No | 12 |
| descr | char | Yes | 40 |
| short_descr | char | Yes | 16 |
| invy_flag | bit | Yes |  |
| taxble_code | numeric | Yes |  |
| tax_rate_code | numeric | Yes |  |
| usage_code | char | Yes | 4 |
| non_tax_rsn_code | char | Yes | 3 |
| item_cat | char | Yes | 6 |
| matl_type | char | Yes | 1 |
| invy_item_code | char | Yes | 12 |
| print_on_tkt_flag | bit | Yes |  |
| print_qty_on_tkt_flag | bit | Yes |  |
| order_uom | char | Yes | 5 |
| price_uom | char | Yes | 5 |
| invy_uom | char | Yes | 5 |
| purch_uom | char | Yes | 5 |
| batch_uom | char | Yes | 5 |
| rpt_uom | char | Yes | 5 |
| price_admix_flag | bit | Yes |  |
| agg_size | char | Yes | 8 |
| cem_type | char | Yes | 8 |
| days_to_strgth | numeric | Yes |  |
| max_water | numeric | Yes |  |
| water_cem_ratio | numeric | Yes |  |
| pct_air | numeric | Yes |  |
| slump | char | Yes | 8 |
| slump_uom | char | Yes | 5 |
| strgth | numeric | Yes |  |
| strgth_uom | char | Yes | 5 |
| water_hold | numeric | Yes |  |
| terms_disc_flag | bit | Yes |  |
| trade_disc_flag | bit | Yes |  |
| expir_date | datetime | Yes |  |
| serial_num_flag | bit | Yes |  |
| lot_num_flag | bit | Yes |  |
| resale_flag | bit | Yes |  |
| const_flag | bit | Yes |  |
| cust_code | char | Yes | 10 |
| proj_code | char | Yes | 12 |
| min_temp | numeric | Yes |  |
| min_temp_uom | char | Yes | 5 |
| pct_recycle | numeric | Yes |  |
| order_qty_ext_code | char | Yes | 1 |
| order_dosage_qty | numeric | Yes |  |
| order_dosage_qty_uom | char | Yes | 5 |
| price_qty_ext_code | char | Yes | 1 |
| tkt_qty_ext_code | char | Yes | 1 |
| delv_uom | char | Yes | 5 |
| per_cem_wgt_divisor | numeric | Yes |  |
| lwt_qty | numeric | Yes |  |
| lwt_qty_uom | char | Yes | 5 |
| min_cem_cont | numeric | Yes |  |
| air_pct | numeric | Yes |  |
| content_price | numeric | Yes |  |
| content_up_price | numeric | Yes |  |
| content_down_price | numeric | Yes |  |
| batch_code | char | Yes | 12 |
| pct_asphalt_recycle | numeric | Yes |  |
| asphaltic_cem_qty | numeric | Yes |  |
| asphaltic_cem_qty_uom | char | Yes | 5 |
| oil_qty | numeric | Yes |  |
| oil_qty_uom | char | Yes | 5 |
| accum_admix_amt_flag | bit | Yes |  |
| load_var_pct | numeric | Yes |  |
| qc_note | char | Yes | 255 |
| dataout_date | datetime | Yes |  |
| modified_date | datetime | Yes |  |
| min_cem_override_flag | bit | Yes |  |
| const_substitution_flag | bit | Yes |  |
| include_in_yield_flag | bit | Yes |  |
| dose_uom | char | Yes | 5 |
| dose_extension_code | numeric | Yes |  |
| dose_divisor | numeric | Yes |  |
| dose_dosage_qty | numeric | Yes |  |
| dose_delv_uom | char | Yes | 5 |
| sort_code | char | Yes | 8 |
| do_not_allow_tkting_flag | bit | Yes |  |
| accum_admix_amt_code | char | Yes | 2 |
| cement_change_code | char | Yes | 2 |
| max_slump | char | Yes | 8 |
| min_slump | char | Yes | 8 |
| modifier_slump | char | Yes | 8 |
| accum_admix_design_amt_code | char | Yes | 2 |
| max_water_uom | char | Yes | 5 |
| prebatch_flag | bit | Yes |  |
| sales_text | char | Yes | 40 |
| cart_cat | char | Yes | 6 |
| use_dosage_qty_uom_flag | bit | Yes |  |
| guid | char | Yes | 36 |
| item_status_code | char | Yes | 2 |
| agg_moisture_ref_code | char | Yes | 2 |
| modify_admix_flag | bit | Yes |  |
| material_guid | char | Yes | 36 |
| product_guid | char | Yes | 36 |
| edx_synch_status_code | char | Yes | 1 |
| max_age_of_concrete | numeric | Yes |  |
| min_load_size | numeric | Yes |  |
| include_in_sampling_code | char | Yes | 2 |
| sampling_interval | numeric | Yes |  |
| sampling_interval_uom | char | Yes | 5 |
| truck_type | char | Yes | 2 |
| max_load_size | numeric | Yes |  |
| strgth2_code | char | Yes | 8 |
| time_to_strgth2 | numeric | Yes |  |
| time_to_strgth2_uom | char | Yes | 5 |
| strgth3_code | char | Yes | 8 |
| time_to_strgth3 | numeric | Yes |  |
| time_to_strgth3_uom | char | Yes | 5 |
| job_washdown_time | numeric | Yes |  |
| inactive_code | char | Yes | 2 |
| inactive_date | datetime | Yes |  |
| advanced_ordr_req_flag | char | Yes | 2 |
| max_temp | numeric | Yes |  |
| slump_type | char | Yes | 2 |
| legacy_item_code | char | Yes | 32 |
| dot_code | char | Yes | 32 |
| air_class_id | char | Yes | 8 |
| air_class_description | char | Yes | 60 |
| slump_table_uid | numeric | Yes |  |
| slump_table_name | char | Yes | 250 |
| dosage_slump_increase | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| user_defined | varchar | Yes | -1 |

## Table: dbo.imtx
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| item_code | char | No | 12 |
| tax_auth | char | No | 4 |
| tax_loc | char | No | 8 |
| taxble_code | char | Yes | 1 |
| non_tax_rsn_code | char | Yes | 3 |
| override_rate_cur_pct | numeric | Yes |  |
| override_rate_effect_date | datetime | Yes |  |
| override_rate_prev_pct | numeric | Yes |  |
| override_tax_loc | char | Yes | 8 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.iprc
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| item_code | char | No | 12 |
| loc_code | char | No | 4 |
| price_cat | char | No | 3 |
| price | numeric | Yes |  |
| price_ext_code | char | Yes | 1 |
| effect_date | datetime | Yes |  |
| prev_price | numeric | Yes |  |
| prev_price_ext_code | char | Yes | 1 |
| modified_date | datetime | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.itrn
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| batch_date | datetime | No |  |
| batch_num | numeric | No |  |
| batch_seq | numeric | No |  |
| unique_num | numeric | No |  |
| cust_code | char | No | 10 |
| item_ref_code | char | Yes | 12 |
| trans_type | numeric | Yes |  |
| trans_date | datetime | Yes |  |
| check_num | char | Yes | 20 |
| ship_cust_code | char | Yes | 10 |
| ref_cust_code | char | Yes | 10 |
| sort_name | char | Yes | 8 |
| disc_date | datetime | Yes |  |
| due_date | datetime | Yes |  |
| ar_rsn_code | char | Yes | 3 |
| disc_taken_amt | numeric | Yes |  |
| disc_taken_tax_amt | numeric | Yes |  |
| ca_qty | numeric | Yes |  |
| ca_cstmry_qty | numeric | Yes |  |
| ca_metric_qty | numeric | Yes |  |
| cb_qty | numeric | Yes |  |
| cb_cstmry_qty | numeric | Yes |  |
| cb_metric_qty | numeric | Yes |  |
| cc_qty | numeric | Yes |  |
| cc_cstmry_qty | numeric | Yes |  |
| cc_metric_qty | numeric | Yes |  |
| cd_qty | numeric | Yes |  |
| cd_cstmry_qty | numeric | Yes |  |
| cd_metric_qty | numeric | Yes |  |
| ca_qty_uom | char | Yes | 5 |
| cb_qty_uom | char | Yes | 5 |
| cc_qty_uom | char | Yes | 5 |
| cd_qty_uom | char | Yes | 5 |
| lot_block | char | Yes | 10 |
| po | char | Yes | 24 |
| cust_job_num | char | Yes | 24 |
| proj_code | char | Yes | 12 |
| finc_chrg_amt | numeric | Yes |  |
| adj_amt | numeric | Yes |  |
| assgn_amt | numeric | Yes |  |
| pretax_amt | numeric | Yes |  |
| pmt_amt | numeric | Yes |  |
| discble_sales_amt | numeric | Yes |  |
| misc_pmt_amt | numeric | Yes |  |
| disc_allowed_amt | numeric | Yes |  |
| disc_allowed_tax_amt | numeric | Yes |  |
| retain_amt | numeric | Yes |  |
| retain_tax_amt | numeric | Yes |  |
| tax_amt | numeric | Yes |  |
| check_amt | numeric | Yes |  |
| invc_code | char | Yes | 12 |
| ar_adj_code | char | Yes | 3 |
| ref_note | char | Yes | 40 |
| ar_aging_date | datetime | Yes |  |
| invc_grouping_code | char | Yes | 1 |
| invc_sub_grouping_code | char | Yes | 1 |
| invc_det_sum_code | char | Yes | 1 |
| invc_single_mult_day_code | char | Yes | 1 |
| invc_show_min_haul_flag | bit | Yes |  |
| invc_comb_haul_flag | bit | Yes |  |
| invc_sep_by_prod_line_flag | bit | Yes |  |
| plant_code | char | Yes | 3 |
| comp_code | char | Yes | 4 |
| slsmn_empl_code | char | Yes | 12 |
| terms_code | char | Yes | 3 |
| cost_amt | numeric | Yes |  |
| post_stat | numeric | Yes |  |
| begin_cutoff_date | datetime | Yes |  |
| end_cutoff_date | datetime | Yes |  |
| disc_meth | numeric | Yes |  |
| bank_code | char | Yes | 3 |
| acct_cat_code | char | Yes | 4 |
| cred_limtn_code | char | Yes | 3 |
| cred_limtn_amt | numeric | Yes |  |
| cred_limtn_tax_amt | numeric | Yes |  |
| cred_limtn_date | datetime | Yes |  |
| prt_recpt_flag | bit | Yes |  |
| recpt_code | char | Yes | 12 |
| cross_ref_invc_code | char | Yes | 12 |
| tax_invc_code | char | Yes | 12 |
| delv_addr | char | Yes | 40 |
| exmpt_delv_amt | numeric | Yes |  |
| pmt_meth | char | Yes | 1 |
| pmt_acct_exp_date | char | Yes | 10 |
| pmt_acct_name | char | Yes | 40 |
| pmt_acct_bank_name | char | Yes | 40 |
| pmt_auth_code | char | Yes | 16 |
| invc_tkt_round_diff_amt | numeric | Yes |  |
| modified_date | datetime | Yes |  |
| dataout_date | datetime | Yes |  |
| pmt_form_code | char | Yes | 8 |
| batch_entry_id | numeric | Yes |  |
| pmt_type | char | Yes | 1 |
| ccard_cust_code | char | Yes | 10 |
| ccard_last_four | char | Yes | 4 |
| ccard_type_code | char | Yes | 2 |
| ccard_unique_id | char | Yes | 8 |
| ccard_approval_code | char | Yes | 6 |
| ccard_trans_id | numeric | Yes |  |
| ccard_paid_ind | char | Yes | 1 |
| ccard_trans_datetime | datetime | Yes |  |
| ccard_trans_amt | numeric | Yes |  |
| third_party_taxcalc_status | char | Yes | 2 |
| invoice_print_status | char | Yes | 2 |
| invc_delv_meth | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.itrn_1
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| user_name | char | No | 20 |
| unique_num | numeric | No |  |
| batch_date | datetime | Yes |  |
| batch_num | numeric | Yes |  |
| batch_seq | numeric | Yes |  |
| ship_cust_code | char | Yes | 10 |
| ref_cust_code | char | Yes | 10 |
| sort_name | char | Yes | 8 |
| item_ref_code | char | Yes | 12 |
| trans_date | datetime | Yes |  |
| trans_type | numeric | Yes |  |
| disc_date | datetime | Yes |  |
| due_date | datetime | Yes |  |
| ar_rsn_code | char | Yes | 3 |
| disc_taken_amt | numeric | Yes |  |
| disc_taken_tax_amt | numeric | Yes |  |
| ca_qty | numeric | Yes |  |
| ca_cstmry_qty | numeric | Yes |  |
| ca_metric_qty | numeric | Yes |  |
| cb_qty | numeric | Yes |  |
| cb_cstmry_qty | numeric | Yes |  |
| cb_metric_qty | numeric | Yes |  |
| cc_qty | numeric | Yes |  |
| cc_cstmry_qty | numeric | Yes |  |
| cc_metric_qty | numeric | Yes |  |
| cd_qty | numeric | Yes |  |
| cd_cstmry_qty | numeric | Yes |  |
| cd_metric_qty | numeric | Yes |  |
| ca_qty_uom | char | Yes | 5 |
| cb_qty_uom | char | Yes | 5 |
| cc_qty_uom | char | Yes | 5 |
| cd_qty_uom | char | Yes | 5 |
| lot_block | char | Yes | 10 |
| po | char | Yes | 24 |
| cust_job_num | char | Yes | 24 |
| proj_code | char | Yes | 12 |
| finc_chrg_amt | numeric | Yes |  |
| adj_amt | numeric | Yes |  |
| assgn_amt | numeric | Yes |  |
| pretax_amt | numeric | Yes |  |
| pmt_amt | numeric | Yes |  |
| discble_sales_amt | numeric | Yes |  |
| misc_pmt_amt | numeric | Yes |  |
| disc_allowed_amt | numeric | Yes |  |
| disc_allowed_tax_amt | numeric | Yes |  |
| retain_amt | numeric | Yes |  |
| retain_tax_amt | numeric | Yes |  |
| tax_amt | numeric | Yes |  |
| check_num | char | Yes | 20 |
| check_amt | numeric | Yes |  |
| invc_code | char | Yes | 12 |
| ar_adj_code | char | Yes | 3 |
| ref_note | char | Yes | 40 |
| ar_aging_date | datetime | Yes |  |
| invc_grouping_code | char | Yes | 1 |
| invc_sub_grouping_code | char | Yes | 1 |
| invc_det_sum_code | char | Yes | 1 |
| invc_single_mult_day_code | char | Yes | 1 |
| invc_show_min_haul_flag | bit | Yes |  |
| invc_comb_haul_flag | bit | Yes |  |
| invc_sep_by_prod_line_flag | bit | Yes |  |
| plant_code | char | Yes | 3 |
| comp_code | char | Yes | 4 |
| slsmn_empl_code | char | Yes | 12 |
| terms_code | char | Yes | 3 |
| cost_amt | numeric | Yes |  |
| post_stat | numeric | Yes |  |
| begin_cutoff_date | datetime | Yes |  |
| end_cutoff_date | datetime | Yes |  |
| disc_meth | numeric | Yes |  |
| bank_code | char | Yes | 3 |
| acct_cat_code | char | Yes | 4 |
| cred_limtn_code | char | Yes | 3 |
| cred_limtn_amt | numeric | Yes |  |
| cred_limtn_tax_amt | numeric | Yes |  |
| cred_limtn_date | datetime | Yes |  |
| prt_recpt_flag | bit | Yes |  |
| recpt_code | char | Yes | 12 |
| cross_ref_invc_code | char | Yes | 12 |
| tax_invc_code | char | Yes | 12 |
| invc_tkt_round_diff_amt | numeric | Yes |  |
| delv_addr | char | Yes | 40 |
| pmt_acct_exp_date | char | Yes | 10 |
| pmt_acct_name | char | Yes | 40 |
| pmt_acct_bank_name | char | Yes | 40 |
| pmt_auth_code | char | Yes | 16 |
| pmt_meth | char | Yes | 1 |
| exmpt_delv_amt | numeric | Yes |  |
| pmt_form_code | char | Yes | 8 |
| invc_delv_meth | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.ivhd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| loc_code | char | No | 4 |
| trans_date | datetime | No |  |
| doc_num | numeric | No |  |
| trans_type | numeric | Yes |  |
| comp_code | char | Yes | 4 |
| user_name | char | Yes | 20 |
| rel_date_time | datetime | Yes |  |
| post_date_time | datetime | Yes |  |
| recur_num | numeric | Yes |  |
| recur_num_days | numeric | Yes |  |
| post_stat | numeric | Yes |  |
| next_seq_num | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.ivpd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| acctng_year | numeric | No |  |
| acctng_perds | numeric | Yes |  |
| perd_begin_date_01 | datetime | Yes |  |
| perd_begin_date_02 | datetime | Yes |  |
| perd_begin_date_03 | datetime | Yes |  |
| perd_begin_date_04 | datetime | Yes |  |
| perd_begin_date_05 | datetime | Yes |  |
| perd_begin_date_06 | datetime | Yes |  |
| perd_begin_date_07 | datetime | Yes |  |
| perd_begin_date_08 | datetime | Yes |  |
| perd_begin_date_09 | datetime | Yes |  |
| perd_begin_date_10 | datetime | Yes |  |
| perd_begin_date_11 | datetime | Yes |  |
| perd_begin_date_12 | datetime | Yes |  |
| perd_begin_date_13 | datetime | Yes |  |
| perd_end_date_01 | datetime | Yes |  |
| perd_end_date_02 | datetime | Yes |  |
| perd_end_date_03 | datetime | Yes |  |
| perd_end_date_04 | datetime | Yes |  |
| perd_end_date_05 | datetime | Yes |  |
| perd_end_date_06 | datetime | Yes |  |
| perd_end_date_07 | datetime | Yes |  |
| perd_end_date_08 | datetime | Yes |  |
| perd_end_date_09 | datetime | Yes |  |
| perd_end_date_10 | datetime | Yes |  |
| perd_end_date_11 | datetime | Yes |  |
| perd_end_date_12 | datetime | Yes |  |
| perd_end_date_13 | datetime | Yes |  |
| perd_open_01 | bit | Yes |  |
| perd_open_02 | bit | Yes |  |
| perd_open_03 | bit | Yes |  |
| perd_open_04 | bit | Yes |  |
| perd_open_05 | bit | Yes |  |
| perd_open_06 | bit | Yes |  |
| perd_open_07 | bit | Yes |  |
| perd_open_08 | bit | Yes |  |
| perd_open_09 | bit | Yes |  |
| perd_open_10 | bit | Yes |  |
| perd_open_11 | bit | Yes |  |
| perd_open_12 | bit | Yes |  |
| perd_open_13 | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.licd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| unique_num | numeric | No |  |
| cust_code | char | No | 15 |
| cust_loc | char | No | 3 |
| rev_no | numeric | No |  |
| client | char | Yes | 40 |
| record_type | char | Yes | 8 |
| appl_type | char | Yes | 3 |
| truck_violation_count | numeric | Yes |  |
| truck_count | numeric | Yes |  |
| truck_date | datetime | Yes |  |
| annl_load_count | numeric | Yes |  |
| annl_tkt_count | numeric | Yes |  |
| annl_start_date | datetime | Yes |  |
| annl_violation_count | numeric | Yes |  |
| intfc_type | char | Yes | 2 |
| intfc_count | numeric | Yes |  |
| service_operation_code | char | Yes | 4 |
| temp_license_flag | bit | Yes |  |
| temp_license_date | datetime | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.lich
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 15 |
| cust_loc | char | No | 3 |
| rev_num | numeric | No |  |
| date | datetime | No |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| tkting_truck_list | varchar | Yes | -1 |
| track_truck_list | varchar | Yes | -1 |
| sched_truck_list | varchar | Yes | -1 |
| opt_truck_list | varchar | Yes | -1 |
| pump_truck_list | varchar | Yes | -1 |

## Table: dbo.licm
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 15 |
| cust_loc | char | No | 3 |
| rev_no | numeric | No |  |
| client | char | Yes | 40 |
| start_date | datetime | Yes |  |
| start_date_disp | char | Yes | 11 |
| expir_date | datetime | Yes |  |
| expir_date_disp | char | Yes | 11 |
| region_code | char | Yes | 2 |
| lic_enh_code | char | Yes | 8 |
| version_code | char | Yes | 8 |
| chksum | char | Yes | 16 |
| netw_count | char | Yes | 3 |
| netw_chksum | char | Yes | 24 |
| licd_unique_num | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| tkting_truck_list | varchar | Yes | -1 |
| track_truck_list | varchar | Yes | -1 |
| sched_truck_list | varchar | Yes | -1 |
| opt_truck_list | varchar | Yes | -1 |
| pump_truck_list | varchar | Yes | -1 |

## Table: dbo.licn
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| key_field | char | No | 1 |
| client | char | No | 40 |
| start_date | datetime | No |  |
| expir_date | datetime | No |  |
| chksum | char | No | 16 |
| netw_chksum | char | Yes | 24 |
| dba_count | numeric | Yes |  |
| ca_dist_analysis_flag | bit | Yes |  |
| ca_mrkt_analysis_flag | bit | Yes |  |
| ca_dist_mrkt_analysis_flag | bit | Yes |  |
| ca_quote_analysis_flag | bit | Yes |  |
| ca_qa_analysis_flag | bit | Yes |  |
| cc_dist_analysis_flag | bit | Yes |  |
| cc_mrkt_analysis_flag | bit | Yes |  |
| cc_dist_mrkt_analysis_flag | bit | Yes |  |
| cc_quote_analysis_flag | bit | Yes |  |
| cc_qa_analysis_flag | bit | Yes |  |
| ccard_trans_count | numeric | Yes |  |
| ccard_trans_date | datetime | Yes |  |
| ccard_annl_trans_count | numeric | Yes |  |
| edx_tkting_annl_tkt_count | numeric | Yes |  |
| edx_tkting_annl_start_date | datetime | Yes |  |
| edx_tkting_tkt_count | numeric | Yes |  |
| service_operation_11 | char | Yes | 2 |
| service_operation_12 | char | Yes | 2 |
| service_operation_13 | char | Yes | 2 |
| service_operation_14 | char | Yes | 2 |
| service_operation_15 | char | Yes | 2 |
| service_operation_16 | char | Yes | 2 |
| service_operation_17 | char | Yes | 2 |
| service_operation_18 | char | Yes | 2 |
| service_operation_19 | char | Yes | 2 |
| service_operation_20 | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| tkting_truck_list | varchar | Yes | -1 |
| track_truck_list | varchar | Yes | -1 |
| sched_truck_list | varchar | Yes | -1 |
| appl_type_01 | char | Yes | 2 |
| appl_type_02 | char | Yes | 2 |
| appl_type_03 | char | Yes | 2 |
| appl_type_04 | char | Yes | 2 |
| appl_type_05 | char | Yes | 2 |
| appl_type_06 | char | Yes | 2 |
| appl_type_07 | char | Yes | 2 |
| appl_type_08 | char | Yes | 2 |
| appl_type_09 | char | Yes | 2 |
| appl_type_10 | char | Yes | 2 |
| appl_type_11 | char | Yes | 2 |
| appl_type_12 | char | Yes | 2 |
| appl_type_13 | char | Yes | 2 |
| appl_type_14 | char | Yes | 2 |
| appl_type_15 | char | Yes | 2 |
| appl_type_16 | char | Yes | 2 |
| appl_type_17 | char | Yes | 2 |
| appl_type_18 | char | Yes | 2 |
| appl_type_19 | char | Yes | 2 |
| appl_type_20 | char | Yes | 2 |
| appl_type_21 | char | Yes | 2 |
| appl_type_22 | char | Yes | 2 |
| appl_type_23 | char | Yes | 2 |
| appl_type_24 | char | Yes | 2 |
| appl_type_25 | char | Yes | 2 |
| appl_type_26 | char | Yes | 2 |
| appl_type_27 | char | Yes | 2 |
| appl_type_28 | char | Yes | 2 |
| appl_type_29 | char | Yes | 2 |
| appl_type_30 | char | Yes | 2 |
| appl_type_31 | char | Yes | 2 |
| appl_type_32 | char | Yes | 2 |
| appl_type_33 | char | Yes | 2 |
| appl_type_34 | char | Yes | 2 |
| appl_type_35 | char | Yes | 2 |
| appl_type_36 | char | Yes | 2 |
| appl_type_37 | char | Yes | 2 |
| appl_type_38 | char | Yes | 2 |
| appl_type_39 | char | Yes | 2 |
| appl_type_40 | char | Yes | 2 |
| appl_type_41 | char | Yes | 2 |
| appl_type_42 | char | Yes | 2 |
| appl_type_43 | char | Yes | 2 |
| appl_type_44 | char | Yes | 2 |
| appl_type_45 | char | Yes | 2 |
| appl_type_46 | char | Yes | 2 |
| appl_type_47 | char | Yes | 2 |
| appl_type_48 | char | Yes | 2 |
| appl_type_49 | char | Yes | 2 |
| appl_type_50 | char | Yes | 2 |
| appl_type_51 | char | Yes | 2 |
| appl_type_52 | char | Yes | 2 |
| appl_type_53 | char | Yes | 2 |
| appl_type_54 | char | Yes | 2 |
| appl_type_55 | char | Yes | 2 |
| appl_type_56 | char | Yes | 2 |
| appl_type_57 | char | Yes | 2 |
| appl_type_58 | char | Yes | 2 |
| appl_type_59 | char | Yes | 2 |
| appl_type_60 | char | Yes | 2 |
| service_operation_1 | char | Yes | 2 |
| service_operation_2 | char | Yes | 2 |
| service_operation_3 | char | Yes | 2 |
| service_operation_4 | char | Yes | 2 |
| service_operation_5 | char | Yes | 2 |
| service_operation_6 | char | Yes | 2 |
| service_operation_7 | char | Yes | 2 |
| service_operation_8 | char | Yes | 2 |
| service_operation_9 | char | Yes | 2 |
| service_operation_10 | char | Yes | 2 |
| tkting_truck_count | numeric | Yes |  |
| tkting_truck_date | datetime | Yes |  |
| tkting_truck_violation_count | numeric | Yes |  |
| track_truck_count | numeric | Yes |  |
| track_truck_date | datetime | Yes |  |
| track_truck_violation_count | numeric | Yes |  |
| sched_truck_count | numeric | Yes |  |
| sched_truck_date | datetime | Yes |  |
| sched_truck_violation_count | numeric | Yes |  |
| prep_truck_count | numeric | Yes |  |
| prep_truck_violation_count | numeric | Yes |  |
| invc_truck_count | numeric | Yes |  |
| invc_truck_violation_count | numeric | Yes |  |
| ca_tkting_annl_load_count | numeric | Yes |  |
| ca_tkting_annl_tkt_count | numeric | Yes |  |
| ca_tkting_annl_start_date | datetime | Yes |  |
| ca_tkting_annl_violation_count | numeric | Yes |  |
| ca_tkting_annl_violation_date | datetime | Yes |  |
| cd_tkting_annl_load_count | numeric | Yes |  |
| cd_tkting_annl_tkt_count | numeric | Yes |  |
| cd_tkting_annl_start_date | datetime | Yes |  |
| cd_tkting_annl_violation_count | numeric | Yes |  |
| cd_tkting_annl_violation_date | datetime | Yes |  |
| batch_intfc_type_01 | char | Yes | 2 |
| batch_intfc_type_02 | char | Yes | 2 |
| batch_intfc_type_03 | char | Yes | 2 |
| batch_intfc_type_04 | char | Yes | 2 |
| batch_intfc_count_01 | numeric | Yes |  |
| batch_intfc_count_02 | numeric | Yes |  |
| batch_intfc_count_03 | numeric | Yes |  |
| batch_intfc_count_04 | numeric | Yes |  |
| sig_intfc_type_01 | char | Yes | 2 |
| sig_intfc_type_02 | char | Yes | 2 |
| sig_intfc_type_03 | char | Yes | 2 |
| sig_intfc_type_04 | char | Yes | 2 |
| sig_intfc_count_01 | numeric | Yes |  |
| sig_intfc_count_02 | numeric | Yes |  |
| sig_intfc_count_03 | numeric | Yes |  |
| sig_intfc_count_04 | numeric | Yes |  |
| load_intfc_type_01 | char | Yes | 2 |
| load_intfc_type_02 | char | Yes | 2 |
| load_intfc_type_03 | char | Yes | 2 |
| load_intfc_type_04 | char | Yes | 2 |
| load_intfc_count_01 | numeric | Yes |  |
| load_intfc_count_02 | numeric | Yes |  |
| load_intfc_count_03 | numeric | Yes |  |
| load_intfc_count_04 | numeric | Yes |  |
| scale_intfc_count | numeric | Yes |  |
| hardlock_flag | bit | Yes |  |
| lic_enh_code | char | Yes | 8 |
| region_code | char | Yes | 2 |
| version_code | char | Yes | 8 |
| uniface_sek_code | char | Yes | 16 |

## Table: dbo.lns2
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| unique_num | char | No | 20 |
| state_code | char | Yes | 2 |
| lien_loc_req_code | char | Yes | 1 |
| auto_create_flag | bit | Yes |  |
| lien_master_name | char | Yes | 40 |
| lien_date_code | char | Yes | 32 |
| lien_event_code | char | Yes | 2 |
| pre_lien_date_code | char | Yes | 32 |
| pre_lien_event_code | char | Yes | 2 |
| event_label_ex | char | Yes | 30 |
| event_short_ex | char | Yes | 6 |
| event_status_ex | char | Yes | 2 |
| event_docf_ex | char | Yes | 8 |
| event_label_im | char | Yes | 30 |
| event_short_im | char | Yes | 6 |
| event_status_im | char | Yes | 2 |
| event_docf_im | char | Yes | 8 |
| event_label_ac | char | Yes | 30 |
| event_short_ac | char | Yes | 6 |
| event_status_ac | char | Yes | 2 |
| event_docf_ac | char | Yes | 8 |
| lien_status_ex | char | Yes | 6 |
| lien_status_im | char | Yes | 6 |
| lien_status_ac | char | Yes | 6 |
| lien_pct_max | numeric | Yes |  |
| dflt_lien_multi_code | char | Yes | 1 |
| dflt_lien_loc_req_code | char | Yes | 1 |
| dflt_lien_ext_flag | bit | Yes |  |
| next_cert_mail_num | char | Yes | 20 |
| cert_mail_num_prefix | char | Yes | 20 |
| lien_by_cal_month_flag | bit | Yes |  |
| event_print_cust_n1_flag | bit | Yes |  |
| event_print_cust_n2_flag | bit | Yes |  |
| event_print_cust_n3_flag | bit | Yes |  |
| event_print_cust_n4_flag | bit | Yes |  |
| event_print_cust_n5_flag | bit | Yes |  |
| event_print_cust_n6_flag | bit | Yes |  |
| event_print_cust_n7_flag | bit | Yes |  |
| event_print_cust_n8_flag | bit | Yes |  |
| event_print_cust_n9_flag | bit | Yes |  |
| event_print_owner_n1_flag | bit | Yes |  |
| event_print_owner_n2_flag | bit | Yes |  |
| event_print_owner_n3_flag | bit | Yes |  |
| event_print_owner_n4_flag | bit | Yes |  |
| event_print_owner_n5_flag | bit | Yes |  |
| event_print_owner_n6_flag | bit | Yes |  |
| event_print_owner_n7_flag | bit | Yes |  |
| event_print_owner_n8_flag | bit | Yes |  |
| event_print_owner_n9_flag | bit | Yes |  |
| event_print_lndr_n1_flag | bit | Yes |  |
| event_print_lndr_n2_flag | bit | Yes |  |
| event_print_lndr_n3_flag | bit | Yes |  |
| event_print_lndr_n4_flag | bit | Yes |  |
| event_print_lndr_n5_flag | bit | Yes |  |
| event_print_lndr_n6_flag | bit | Yes |  |
| event_print_lndr_n7_flag | bit | Yes |  |
| event_print_lndr_n8_flag | bit | Yes |  |
| event_print_lndr_n9_flag | bit | Yes |  |
| event_print_cntr_n1_flag | bit | Yes |  |
| event_print_cntr_n2_flag | bit | Yes |  |
| event_print_cntr_n3_flag | bit | Yes |  |
| event_print_cntr_n4_flag | bit | Yes |  |
| event_print_cntr_n5_flag | bit | Yes |  |
| event_print_cntr_n6_flag | bit | Yes |  |
| event_print_cntr_n7_flag | bit | Yes |  |
| event_print_cntr_n8_flag | bit | Yes |  |
| event_print_cntr_n9_flag | bit | Yes |  |
| event_print_sub_cntr_n1_flag | bit | Yes |  |
| event_print_sub_cntr_n2_flag | bit | Yes |  |
| event_print_sub_cntr_n3_flag | bit | Yes |  |
| event_print_sub_cntr_n4_flag | bit | Yes |  |
| event_print_sub_cntr_n5_flag | bit | Yes |  |
| event_print_sub_cntr_n6_flag | bit | Yes |  |
| event_print_sub_cntr_n7_flag | bit | Yes |  |
| event_print_sub_cntr_n8_flag | bit | Yes |  |
| event_print_sub_cntr_n9_flag | bit | Yes |  |
| event_print_trst_n1_flag | bit | Yes |  |
| event_print_trst_n2_flag | bit | Yes |  |
| event_print_trst_n3_flag | bit | Yes |  |
| event_print_trst_n4_flag | bit | Yes |  |
| event_print_trst_n5_flag | bit | Yes |  |
| event_print_trst_n6_flag | bit | Yes |  |
| event_print_trst_n7_flag | bit | Yes |  |
| event_print_trst_n8_flag | bit | Yes |  |
| event_print_trst_n9_flag | bit | Yes |  |
| lien_loc_id_by_cal_month | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| form_req_list | varchar | Yes | -1 |

## Table: dbo.lnsy
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| unique_num | numeric | No |  |
| next_lien_loc_code | char | Yes | 20 |
| event_label_n1 | char | Yes | 30 |
| event_short_n1 | char | Yes | 6 |
| event_status_n1 | char | Yes | 2 |
| event_docf_n1 | char | Yes | 8 |
| event_label_n2 | char | Yes | 30 |
| event_short_n2 | char | Yes | 6 |
| event_status_n2 | char | Yes | 2 |
| event_docf_n2 | char | Yes | 8 |
| event_label_n3 | char | Yes | 30 |
| event_short_n3 | char | Yes | 6 |
| event_status_n3 | char | Yes | 2 |
| event_docf_n3 | char | Yes | 8 |
| event_label_n4 | char | Yes | 30 |
| event_short_n4 | char | Yes | 6 |
| event_status_n4 | char | Yes | 2 |
| event_docf_n4 | char | Yes | 8 |
| event_status_n5 | char | Yes | 2 |
| event_label_n5 | char | Yes | 30 |
| event_short_n5 | char | Yes | 6 |
| event_docf_n5 | char | Yes | 8 |
| event_label_n6 | char | Yes | 30 |
| event_short_n6 | char | Yes | 6 |
| event_status_n6 | char | Yes | 2 |
| event_docf_n6 | char | Yes | 8 |
| event_label_n7 | char | Yes | 30 |
| event_short_n7 | char | Yes | 6 |
| event_status_n7 | char | Yes | 2 |
| event_docf_n7 | char | Yes | 8 |
| event_label_n8 | char | Yes | 30 |
| event_short_n8 | char | Yes | 6 |
| event_status_n8 | char | Yes | 2 |
| event_docf_n8 | char | Yes | 8 |
| event_label_n9 | char | Yes | 30 |
| event_short_n9 | char | Yes | 6 |
| event_status_n9 | char | Yes | 2 |
| event_docf_n9 | char | Yes | 8 |
| event_label_r1 | char | Yes | 30 |
| event_short_r1 | char | Yes | 6 |
| event_status_r1 | char | Yes | 2 |
| event_docf_r1 | char | Yes | 8 |
| event_type_r1 | char | Yes | 4 |
| event_label_r2 | char | Yes | 30 |
| event_short_r2 | char | Yes | 30 |
| event_status_r2 | char | Yes | 2 |
| event_docf_r2 | char | Yes | 8 |
| event_type_r2 | char | Yes | 4 |
| event_label_r3 | char | Yes | 30 |
| event_short_r3 | char | Yes | 6 |
| event_status_r3 | char | Yes | 2 |
| event_docf_r3 | char | Yes | 8 |
| event_type_r3 | char | Yes | 4 |
| event_label_r4 | char | Yes | 30 |
| event_short_r4 | char | Yes | 6 |
| event_status_r4 | char | Yes | 2 |
| event_docf_r4 | char | Yes | 8 |
| event_type_r4 | char | Yes | 4 |
| event_label_r5 | char | Yes | 30 |
| event_short_r5 | char | Yes | 6 |
| event_status_r5 | char | Yes | 2 |
| event_docf_r5 | char | Yes | 8 |
| event_type_r5 | char | Yes | 4 |
| event_label_r6 | char | Yes | 30 |
| event_short_r6 | char | Yes | 6 |
| event_status_r6 | char | Yes | 2 |
| event_docf_r6 | char | Yes | 8 |
| event_type_r6 | char | Yes | 4 |
| event_label_r7 | char | Yes | 30 |
| event_short_r7 | char | Yes | 6 |
| event_status_r7 | char | Yes | 2 |
| event_docf_r7 | char | Yes | 8 |
| event_type_r7 | char | Yes | 4 |
| event_label_r8 | char | Yes | 30 |
| event_short_r8 | char | Yes | 6 |
| event_status_r8 | char | Yes | 2 |
| event_docf_r8 | char | Yes | 8 |
| event_type_r8 | char | Yes | 4 |
| event_label_r9 | char | Yes | 30 |
| event_short_r9 | char | Yes | 6 |
| event_status_r9 | char | Yes | 2 |
| event_docf_r9 | char | Yes | 8 |
| event_type_r9 | char | Yes | 4 |
| event_label_cr | char | Yes | 30 |
| event_short_cr | char | Yes | 6 |
| event_status_cr | char | Yes | 2 |
| event_docf_cr | char | Yes | 8 |
| event_label_ex | char | Yes | 30 |
| event_short_ex | char | Yes | 6 |
| event_status_ex | char | Yes | 2 |
| event_docf_ex | char | Yes | 8 |
| event_label_nx | char | Yes | 30 |
| event_short_nx | char | Yes | 6 |
| event_status_nx | char | Yes | 2 |
| event_docf_nx | char | Yes | 8 |
| event_label_ca | char | Yes | 30 |
| event_short_ca | char | Yes | 6 |
| event_status_ca | char | Yes | 2 |
| event_docf_ca | char | Yes | 8 |
| event_label_jc | char | Yes | 30 |
| event_short_jc | char | Yes | 6 |
| event_status_jc | char | Yes | 2 |
| event_docf_jc | char | Yes | 8 |
| event_label_cl | char | Yes | 30 |
| event_short_cl | char | Yes | 6 |
| event_status_cl | char | Yes | 2 |
| event_docf_cl | char | Yes | 8 |
| event_label_na | char | Yes | 30 |
| event_short_na | char | Yes | 6 |
| event_status_na | char | Yes | 2 |
| event_docf_na | char | Yes | 8 |
| event_label_op | char | Yes | 30 |
| event_short_op | char | Yes | 6 |
| event_status_op | char | Yes | 2 |
| event_docf_op | char | Yes | 8 |
| event_label_st | char | Yes | 30 |
| event_short_st | char | Yes | 6 |
| event_status_st | char | Yes | 2 |
| event_docf_st | char | Yes | 8 |
| event_label_ln | char | Yes | 30 |
| event_short_ln | char | Yes | 6 |
| event_status_ln | char | Yes | 2 |
| event_docf_ln | char | Yes | 8 |
| event_label_u1 | char | Yes | 30 |
| event_short_u1 | char | Yes | 6 |
| event_status_u1 | char | Yes | 2 |
| event_docf_u1 | char | Yes | 8 |
| event_label_u2 | char | Yes | 30 |
| event_short_u2 | char | Yes | 30 |
| event_status_u2 | char | Yes | 2 |
| event_docf_u2 | char | Yes | 8 |
| event_label_u3 | char | Yes | 30 |
| event_short_u3 | char | Yes | 6 |
| event_status_u3 | char | Yes | 2 |
| event_docf_u3 | char | Yes | 8 |
| lien_status_no | char | Yes | 30 |
| lien_status_cr | char | Yes | 6 |
| lien_status_jc | char | Yes | 6 |
| lien_status_st | char | Yes | 6 |
| lien_status_na | char | Yes | 6 |
| lien_status_cl | char | Yes | 6 |
| lien_status_op | char | Yes | 6 |
| lien_status_ln | char | Yes | 6 |
| lien_status_pr | char | Yes | 6 |
| lien_status_s1 | char | Yes | 6 |
| lien_status_s2 | char | Yes | 6 |
| lien_status_s3 | char | Yes | 6 |
| cntr_name_flag | bit | Yes |  |
| cntr_addr_line_1_flag | bit | Yes |  |
| cntr_addr_line_2_flag | bit | Yes |  |
| cntr_addr_city_flag | bit | Yes |  |
| cntr_addr_state_flag | bit | Yes |  |
| cntr_addr_postcd_flag | bit | Yes |  |
| cntr_contct_name_flag | bit | Yes |  |
| cntr_phone_num_1_flag | bit | Yes |  |
| cntr_phone_num_2_flag | bit | Yes |  |
| cntr_phone_num_3_flag | bit | Yes |  |
| cntr_phone_num_4_flag | bit | Yes |  |
| owner_name_flag | bit | Yes |  |
| owner_addr_line_1_flag | bit | Yes |  |
| owner_addr_line_2_flag | bit | Yes |  |
| owner_addr_city_flag | bit | Yes |  |
| owner_addr_state_flag | bit | Yes |  |
| owner_addr_postcd_flag | bit | Yes |  |
| owner_contct_name_flag | bit | Yes |  |
| owner_phone_num_1_flag | bit | Yes |  |
| owner_phone_num_2_flag | bit | Yes |  |
| owner_phone_num_4_flag | bit | Yes |  |
| owner_phone_num_3_flag | bit | Yes |  |
| lndr_name_flag | bit | Yes |  |
| lndr_addr_line_1_flag | bit | Yes |  |
| lndr_addr_line_2_flag | bit | Yes |  |
| lndr_addr_city_flag | bit | Yes |  |
| lndr_addr_state_flag | bit | Yes |  |
| lndr_addr_postcd_flag | bit | Yes |  |
| lndr_contct_name_flag | bit | Yes |  |
| lndr_phone_num_1_flag | bit | Yes |  |
| lndr_phone_num_2_flag | bit | Yes |  |
| lndr_phone_num_3_flag | bit | Yes |  |
| lndr_phone_num_4_flag | bit | Yes |  |
| trst_name_flag | bit | Yes |  |
| trst_addr_line_1_flag | bit | Yes |  |
| trst_addr_line_2_flag | bit | Yes |  |
| trst_addr_city_flag | bit | Yes |  |
| trst_addr_state_flag | bit | Yes |  |
| trst_addr_postcd_flag | bit | Yes |  |
| trst_contct_name_flag | bit | Yes |  |
| trst_phone_num_1_flag | bit | Yes |  |
| trst_phone_num_2_flag | bit | Yes |  |
| trst_phone_num_3_flag | bit | Yes |  |
| trst_phone_num_4_flag | bit | Yes |  |
| lnhd_owner_cmplt_flag | bit | Yes |  |
| lnhd_lndr_cmplt_flag | bit | Yes |  |
| lnhd_trst_cmplt_flag | bit | Yes |  |
| lnhd_cntr_cmplt_flag | bit | Yes |  |
| lnhd_sub_cntr_cmplt_flag | bit | Yes |  |
| lnhd_lot_block_flag | bit | Yes |  |
| lnhd_cust_code_flag | bit | Yes |  |
| lnhd_proj_code_flag | bit | Yes |  |
| lnhd_comp_code_flag | bit | Yes |  |
| lnhd_private_public_code_flag | bit | Yes |  |
| lnhd_min_lien_amt_flag | bit | Yes |  |
| lnhd_est_lien_amt_flag | bit | Yes |  |
| lnhd_owner_code_flag | bit | Yes |  |
| lnhd_delv_addr_flag | bit | Yes |  |
| lnhd_lndr_code_flag | bit | Yes |  |
| lnhd_trst_code_flag | bit | Yes |  |
| lnhd_cntr_code_flag | bit | Yes |  |
| lnhd_sub_cntr_code_flag | bit | Yes |  |
| lnhd_descr_flag | bit | Yes |  |
| lnhd_addr_line_1_flag | bit | Yes |  |
| lnhd_addr_line_2_flag | bit | Yes |  |
| lnhd_addr_city_flag | bit | Yes |  |
| lnhd_addr_count_flag | bit | Yes |  |
| lnhd_addr_county_flag | bit | Yes |  |
| lnhd_addr_state_flag | bit | Yes |  |
| lnhd_addr_postcd_flag | bit | Yes |  |
| days_pre_not | numeric | Yes |  |
| days_rpt_pre_not | numeric | Yes |  |
| days_lien_not | numeric | Yes |  |
| days_rpt_lien_not | numeric | Yes |  |
| days_lien_cmplt_not | numeric | Yes |  |
| days_rpt_lien_cmplt_not | numeric | Yes |  |
| state_code | char | Yes | 2 |
| lnhd_map_page_flag | bit | Yes |  |
| lnhd_zone_code_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| reserved | varchar | Yes | -1 |

## Table: dbo.locn
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| loc_code | char | No | 4 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| addr_line_1 | char | Yes | 40 |
| addr_line_2 | char | Yes | 40 |
| addr_city | char | Yes | 40 |
| addr_state | char | Yes | 10 |
| addr_cntry | char | Yes | 3 |
| addr_postcd | char | Yes | 10 |
| phone_num_1 | char | Yes | 14 |
| phone_num_2 | char | Yes | 14 |
| comp_code | char | Yes | 4 |
| auto_post_xfer_recpt_flag | bit | Yes |  |
| maintain_invy_flag | bit | Yes |  |
| utc_time_zone_offset | char | Yes | 6 |
| daylight_savings_start_date | datetime | Yes |  |
| daylight_savings_end_date | datetime | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.mapd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| map_page | char | No | 8 |
| plant_code | char | No | 3 |
| distance | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.mapp
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| period_code | numeric | No |  |
| from_time | datetime | Yes |  |
| thru_time | datetime | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.maps
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| map_page | char | No | 8 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| map_upper_left_long | char | Yes | 9 |
| map_upper_left_lat | char | Yes | 9 |
| map_lower_right_long | char | Yes | 9 |
| map_lower_right_lat | char | Yes | 9 |
| map_radius | numeric | Yes |  |
| max_load_size | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.mapt
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| map_page | char | No | 8 |
| from_date | datetime | No |  |
| thru_date | datetime | No |  |
| plant_code | char | No | 3 |
| period_code | numeric | No |  |
| trvl_time | numeric | Yes |  |
| loads | numeric | Yes |  |
| tot_to_job_trvl_time | numeric | Yes |  |
| tot_to_job_loads | numeric | Yes |  |
| tot_to_job_orig_trvl_time | numeric | Yes |  |
| tot_from_plant_trvl_time | numeric | Yes |  |
| tot_from_plant_loads | numeric | Yes |  |
| tot_from_plant_orig_trvl_time | numeric | Yes |  |
| tot_to_plant_trvl_time | numeric | Yes |  |
| tot_to_plant_loads | numeric | Yes |  |
| tot_to_plant_orig_trvl_time | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.mapz
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| map_page | char | No | 8 |
| zone_code | char | No | 8 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.mchc
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| min_load_chrg_table_id | char | No | 3 |
| comp_code | char | No | 4 |
| plant_code | char | No | 3 |
| prod_code | char | Yes | 12 |
| min_qty | numeric | Yes |  |
| min_loads | numeric | Yes |  |
| num_free_loads | numeric | Yes |  |
| price_uom | char | Yes | 5 |
| incl_min_load_chrg_code | char | Yes | 2 |
| calc_meth_code | char | Yes | 2 |
| rate_meth_code | char | Yes | 2 |
| bas_qty_code | char | Yes | 2 |
| min_load_qty_code | char | Yes | 2 |
| cart_code | char | Yes | 3 |
| base_qty | numeric | Yes |  |
| per_unit_rate | numeric | Yes |  |
| zero_amount_print_code | char | Yes | 2 |
| exempt_all_delv_qty | numeric | Yes |  |
| exempt_all_load_count | numeric | Yes |  |
| exempt_based_on_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.mchg
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| min_load_chrg_table_id | char | No | 3 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| prod_code | char | Yes | 12 |
| min_qty | numeric | Yes |  |
| min_loads | numeric | Yes |  |
| num_free_loads | numeric | Yes |  |
| price_uom | char | Yes | 5 |
| load_size_01 | numeric | Yes |  |
| price_per_qty_01 | numeric | Yes |  |
| load_size_02 | numeric | Yes |  |
| price_per_qty_02 | numeric | Yes |  |
| load_size_03 | numeric | Yes |  |
| price_per_qty_03 | numeric | Yes |  |
| load_size_04 | numeric | Yes |  |
| price_per_qty_04 | numeric | Yes |  |
| load_size_05 | numeric | Yes |  |
| price_per_qty_05 | numeric | Yes |  |
| load_size_06 | numeric | Yes |  |
| price_per_qty_06 | numeric | Yes |  |
| load_size_07 | numeric | Yes |  |
| price_per_qty_07 | numeric | Yes |  |
| load_size_08 | numeric | Yes |  |
| price_per_qty_08 | numeric | Yes |  |
| load_size_09 | numeric | Yes |  |
| price_per_qty_09 | numeric | Yes |  |
| load_size_10 | numeric | Yes |  |
| price_per_qty_10 | numeric | Yes |  |
| load_size_11 | numeric | Yes |  |
| price_per_qty_11 | numeric | Yes |  |
| load_size_12 | numeric | Yes |  |
| price_per_qty_12 | numeric | Yes |  |
| load_size_13 | numeric | Yes |  |
| price_per_qty_13 | numeric | Yes |  |
| load_size_14 | numeric | Yes |  |
| price_per_qty_14 | numeric | Yes |  |
| load_size_15 | numeric | Yes |  |
| price_per_qty_15 | numeric | Yes |  |
| load_size_16 | numeric | Yes |  |
| price_per_qty_16 | numeric | Yes |  |
| load_size_17 | numeric | Yes |  |
| price_per_qty_17 | numeric | Yes |  |
| load_size_18 | numeric | Yes |  |
| price_per_qty_18 | numeric | Yes |  |
| load_size_19 | numeric | Yes |  |
| price_per_qty_19 | numeric | Yes |  |
| load_size_20 | numeric | Yes |  |
| price_per_qty_20 | numeric | Yes |  |
| load_size_21 | numeric | Yes |  |
| price_per_qty_21 | numeric | Yes |  |
| load_size_22 | numeric | Yes |  |
| price_per_qty_22 | numeric | Yes |  |
| load_size_23 | numeric | Yes |  |
| price_per_qty_23 | numeric | Yes |  |
| load_size_24 | numeric | Yes |  |
| price_per_qty_24 | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.mchr
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| min_load_chrg_table_id | char | No | 3 |
| comp_code | char | No | 4 |
| plant_code | char | No | 3 |
| unique_num | numeric | No |  |
| load_size | numeric | Yes |  |
| price_per_qty | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.mtxt
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| msg_code | char | No | 4 |
| msg_text | char | Yes | 200 |
| msg_type | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.nins
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| invc_seq | char | No | 3 |
| invc_code | char | No | 12 |
| invc_run_seq | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.ninv
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| invc_seq | char | No | 3 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| begin_invc_code | numeric | Yes |  |
| next_invc_code | numeric | Yes |  |
| end_invc_code | numeric | Yes |  |
| mask | char | Yes | 12 |
| prefix | char | Yes | 12 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.nord
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_seq | char | No | 3 |
| descr | char | Yes | 40 |
| short_descr | char | Yes | 8 |
| begin_order_code | char | Yes | 12 |
| next_order_code | char | Yes | 12 |
| end_order_code | char | Yes | 12 |
| perptl_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.nors
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_seq | char | No | 3 |
| order_date | datetime | No |  |
| next_order_code | char | Yes | 12 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.ntkt
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| tkt_seq | char | No | 3 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| begin_tkt_code | char | Yes | 8 |
| next_tkt_code | char | Yes | 8 |
| end_tkt_code | char | Yes | 8 |
| perptl_flag | bit | Yes |  |
| external_source_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.nunq
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| key_field | char | No | 1 |
| next_unique_num | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.olap
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| prod_descr | char | No | 40 |
| order_date | datetime | No |  |
| order_code | char | No | 12 |
| order_intrnl_line_num | numeric | No |  |
| assoc_prod_intrnl_line_num | numeric | No |  |
| sort_line_num | numeric | Yes |  |
| prod_code | char | Yes | 12 |
| short_prod_descr | char | Yes | 16 |
| prod_cat | char | Yes | 6 |
| price | numeric | Yes |  |
| cstmry_price | numeric | Yes |  |
| metric_price | numeric | Yes |  |
| price_uom | char | Yes | 5 |
| cstmry_price_uom | char | Yes | 5 |
| metric_price_uom | char | Yes | 5 |
| price_derived_from_code | char | Yes | 2 |
| price_ext_code | char | Yes | 1 |
| price_qty | numeric | Yes |  |
| order_qty_ext_code | char | Yes | 1 |
| order_dosage_qty | numeric | Yes |  |
| cstmry_order_dosage_qty | numeric | Yes |  |
| metric_order_dosage_qty | numeric | Yes |  |
| order_dosage_qty_uom | char | Yes | 5 |
| cstmry_order_dosage_qty_uom | char | Yes | 5 |
| metric_order_dosage_qty_uom | char | Yes | 5 |
| price_qty_ext_code | char | Yes | 1 |
| tkt_qty_ext_code | char | Yes | 1 |
| per_cem_wgt_divisor | numeric | Yes |  |
| order_qty | numeric | Yes |  |
| cstmry_order_qty | numeric | Yes |  |
| metric_order_qty | numeric | Yes |  |
| order_qty_uom | char | Yes | 5 |
| cstmry_order_qty_uom | char | Yes | 5 |
| metric_order_qty_uom | char | Yes | 5 |
| orig_order_qty | numeric | Yes |  |
| cstmry_orig_order_qty | numeric | Yes |  |
| metric_orig_order_qty | numeric | Yes |  |
| trim_pct | numeric | Yes |  |
| delv_qty | numeric | Yes |  |
| cstmry_delv_qty | numeric | Yes |  |
| metric_delv_qty | numeric | Yes |  |
| delv_qty_uom | char | Yes | 5 |
| cstmry_delv_qty_uom | char | Yes | 5 |
| metric_delv_qty_uom | char | Yes | 5 |
| taxble_code | numeric | Yes |  |
| non_tax_rsn_code | char | Yes | 3 |
| quote_code | char | Yes | 15 |
| sep_invc_flag | bit | Yes |  |
| moved_order_date | datetime | Yes |  |
| moved_to_order_code | char | Yes | 12 |
| moved_from_order_code | char | Yes | 12 |
| invy_adjust_code | char | Yes | 1 |
| sales_anl_adjust_code | char | Yes | 1 |
| cust_intrnl_line_num | numeric | Yes |  |
| proj_intrnl_line_num | numeric | Yes |  |
| quote_rev_num | char | Yes | 3 |
| usage_code | char | Yes | 4 |
| auth_user_name | char | Yes | 20 |
| load_specific_flag | bit | Yes |  |
| loads_to_use | char | Yes | 40 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.ordl
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_date | datetime | No |  |
| order_code | char | No | 12 |
| order_intrnl_line_num | numeric | No |  |
| sort_line_num | numeric | Yes |  |
| prod_code | char | Yes | 12 |
| prod_descr | char | Yes | 40 |
| short_prod_descr | char | Yes | 16 |
| prod_cat | char | Yes | 6 |
| price | numeric | Yes |  |
| cstmry_price | numeric | Yes |  |
| metric_price | numeric | Yes |  |
| price_uom | char | Yes | 5 |
| cstmry_price_uom | char | Yes | 5 |
| metric_price_uom | char | Yes | 5 |
| price_derived_from_code | char | Yes | 2 |
| price_ext_code | char | Yes | 1 |
| price_qty | numeric | Yes |  |
| delv_price_flag | bit | Yes |  |
| dflt_load_qty | numeric | Yes |  |
| cstmry_dflt_load_qty | numeric | Yes |  |
| metric_dflt_load_qty | numeric | Yes |  |
| dflt_load_qty_uom | char | Yes | 5 |
| order_qty_ext_code | char | Yes | 1 |
| order_dosage_qty | numeric | Yes |  |
| cstmry_order_dosage_qty | numeric | Yes |  |
| metric_order_dosage_qty | numeric | Yes |  |
| order_dosage_qty_uom | char | Yes | 5 |
| cstmry_order_dosage_qty_uom | char | Yes | 5 |
| metric_order_dosage_qty_uom | char | Yes | 5 |
| price_qty_ext_code | char | Yes | 1 |
| tkt_qty_ext_code | char | Yes | 1 |
| cred_price_adj_flag | bit | Yes |  |
| cred_cost_adj_flag | bit | Yes |  |
| order_qty | numeric | Yes |  |
| cstmry_order_qty | numeric | Yes |  |
| metric_order_qty | numeric | Yes |  |
| order_qty_uom | char | Yes | 5 |
| cstmry_order_qty_uom | char | Yes | 5 |
| metric_order_qty_uom | char | Yes | 5 |
| orig_order_qty | numeric | Yes |  |
| cstmry_orig_order_qty | numeric | Yes |  |
| metric_orig_order_qty | numeric | Yes |  |
| delv_qty | numeric | Yes |  |
| cstmry_delv_qty | numeric | Yes |  |
| metric_delv_qty | numeric | Yes |  |
| delv_qty_uom | char | Yes | 5 |
| cstmry_delv_qty_uom | char | Yes | 5 |
| metric_delv_qty_uom | char | Yes | 5 |
| delv_to_date_qty | numeric | Yes |  |
| cstmry_delv_to_date_qty | numeric | Yes |  |
| metric_delv_to_date_qty | numeric | Yes |  |
| rm_slump | char | Yes | 8 |
| rm_slump_uom | char | Yes | 5 |
| rm_mix_flag | bit | Yes |  |
| comment_text | char | Yes | 40 |
| usage_code | char | Yes | 4 |
| taxble_code | numeric | Yes |  |
| non_tax_rsn_code | char | Yes | 3 |
| invc_flag | bit | Yes |  |
| sep_invc_flag | bit | Yes |  |
| remove_rsn_code | char | Yes | 3 |
| proj_line_num | numeric | Yes |  |
| cust_line_num | numeric | Yes |  |
| curr_load_num | numeric | Yes |  |
| quote_code | char | Yes | 15 |
| am_min_temp | numeric | Yes |  |
| moved_order_date | datetime | Yes |  |
| moved_to_order_code | char | Yes | 12 |
| moved_from_order_code | char | Yes | 12 |
| invy_adjust_code | char | Yes | 1 |
| sales_anl_adjust_code | char | Yes | 1 |
| mix_design_user_name | char | Yes | 20 |
| mix_design_update_date | datetime | Yes |  |
| qc_approvl_flag | bit | Yes |  |
| qc_approvl_date | datetime | Yes |  |
| batch_code | char | Yes | 12 |
| chrg_cart_code | char | Yes | 3 |
| cart_rate_amt | numeric | Yes |  |
| quote_rev_num | char | Yes | 3 |
| type_price | char | Yes | 1 |
| matl_price | numeric | Yes |  |
| mix_sent_to_lab_status | char | Yes | 2 |
| lab_transfer_date | datetime | Yes |  |
| auth_user_name | char | Yes | 20 |
| linked_prod_seq_num | numeric | Yes |  |
| linked_prod_time_gap | numeric | Yes |  |
| cart_cat | char | Yes | 6 |
| additional_samples | numeric | Yes |  |
| apply_to_contract | bit | Yes |  |
| contracted_samples | numeric | Yes |  |
| exclude_from_sample_sched_rpt | bit | Yes |  |
| total_samples_to_take | numeric | Yes |  |
| pct_hydrate | numeric | Yes |  |
| pumped_indicator_code | char | Yes | 2 |
| writeoff_qty | numeric | Yes |  |
| writeoff_first_load_flag | bit | Yes |  |
| record_origin_code | char | Yes | 2 |
| other_form_chng_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| cart_plant_codes | varchar | Yes | -1 |
| cart_truck_types | varchar | Yes | -1 |
| cart_rates | varchar | Yes | -1 |
| sur_codes | varchar | Yes | -1 |
| sur_rate_amts | varchar | Yes | -1 |
| apply_sur_rate_hler_flags | varchar | Yes | -1 |
| sundry_chrg_table_ids | varchar | Yes | -1 |
| sundry_chrg_sep_invc_flags | varchar | Yes | -1 |
| apply_sundry_chrg_flags | varchar | Yes | -1 |
| lot_num_list | varchar | Yes | -1 |

## Table: dbo.ordr
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_date | datetime | No |  |
| order_code | char | No | 12 |
| order_type | char | Yes | 1 |
| prod_line_code | char | Yes | 2 |
| stat | char | Yes | 1 |
| cust_code | char | Yes | 10 |
| ship_cust_code | char | Yes | 10 |
| ref_cust_code | char | Yes | 10 |
| cust_name | char | Yes | 40 |
| cust_sort_name | char | Yes | 8 |
| proj_code | char | Yes | 12 |
| zone_code | char | Yes | 8 |
| lot_block | char | Yes | 10 |
| cust_job_num | char | Yes | 24 |
| po | char | Yes | 24 |
| taken_by_empl_code | char | Yes | 12 |
| taken_on_phone_line_num | numeric | Yes |  |
| order_by_name | char | Yes | 40 |
| order_by_phone_num | char | Yes | 14 |
| apply_min_load_chrg_flag | bit | Yes |  |
| apply_zone_chrg_flag | bit | Yes |  |
| apply_excess_unld_chrg_flag | bit | Yes |  |
| apply_season_chrg_flag | bit | Yes |  |
| apply_min_haul_pay_flag | bit | Yes |  |
| rm_print_mix_wgts_flag | bit | Yes |  |
| price_plant_code | char | Yes | 3 |
| price_plant_loc_code | char | Yes | 4 |
| comp_code | char | Yes | 4 |
| hler_code | char | Yes | 8 |
| min_load_chrg_table_id | char | Yes | 3 |
| excess_unld_chrg_table_id | char | Yes | 3 |
| season_chrg_table_id | char | Yes | 3 |
| min_load_sep_invc_flag | bit | Yes |  |
| excess_unld_sep_invc_flag | bit | Yes |  |
| season_sep_invc_flag | bit | Yes |  |
| sales_anl_code | char | Yes | 3 |
| slsmn_empl_code | char | Yes | 12 |
| taxble_code | numeric | Yes |  |
| tax_code | char | Yes | 3 |
| non_tax_rsn_code | char | Yes | 3 |
| susp_rsn_code | char | Yes | 3 |
| susp_user_name | char | Yes | 20 |
| susp_date_time | datetime | Yes |  |
| susp_cancel_date_time | datetime | Yes |  |
| susp_cancel_user_name | char | Yes | 20 |
| remove_rsn_code | char | Yes | 3 |
| memo_rsn_code | char | Yes | 3 |
| pkt_num | char | Yes | 3 |
| track_order_color | numeric | Yes |  |
| intrnl_line_num | numeric | Yes |  |
| curr_load_num | numeric | Yes |  |
| cod_order_amt | numeric | Yes |  |
| invc_code | char | Yes | 12 |
| setup_date | datetime | Yes |  |
| quote_code | char | Yes | 15 |
| map_page | char | Yes | 8 |
| cred_over_user_name | char | Yes | 20 |
| cred_over_auth_code | char | Yes | 12 |
| cred_limtn_code | char | Yes | 3 |
| est_order_amt | numeric | Yes |  |
| delv_meth_code | char | Yes | 2 |
| expir_date | datetime | Yes |  |
| exceed_qty_flag | bit | Yes |  |
| clear_daily_flag | bit | Yes |  |
| cart_code | char | Yes | 3 |
| cart_rate_amt | numeric | Yes |  |
| apply_cart_rate_hler_flag | bit | Yes |  |
| apply_min_haul_flag | bit | Yes |  |
| map_long | char | Yes | 9 |
| map_lat | char | Yes | 9 |
| map_radius | numeric | Yes |  |
| alt_scale_printer_flag | bit | Yes |  |
| metric_cstmry_code | char | Yes | 1 |
| invy_adjust_code | char | Yes | 1 |
| sales_anl_adjust_code | char | Yes | 1 |
| mix_design_user_name | char | Yes | 20 |
| mix_design_update_date | datetime | Yes |  |
| qc_approvl_flag | bit | Yes |  |
| qc_approvl_date | datetime | Yes |  |
| job_phase | char | Yes | 12 |
| start_time | datetime | Yes |  |
| scale_use_order_flag | bit | Yes |  |
| job_code | char | Yes | 16 |
| phase_code | char | Yes | 16 |
| ship_to_plant_code | char | Yes | 3 |
| pmt_acct_bank_name | char | Yes | 40 |
| pmt_acct_check_num | char | Yes | 20 |
| pmt_acct_exp_date | char | Yes | 10 |
| pmt_acct_name | char | Yes | 40 |
| pmt_amt | numeric | Yes |  |
| pmt_auth_code | char | Yes | 16 |
| pmt_meth | char | Yes | 1 |
| pmt_check_num | char | Yes | 12 |
| pmt_acct_num | char | Yes | 20 |
| ship_addr_line | char | Yes | 40 |
| ship_city | char | Yes | 40 |
| ship_state | char | Yes | 10 |
| ship_cntry | char | Yes | 3 |
| ship_postcd | char | Yes | 10 |
| pay_cart_code | char | Yes | 3 |
| pay_cart_rate_amt | numeric | Yes |  |
| priority | numeric | Yes |  |
| quote_rev_num | char | Yes | 3 |
| modified_date | datetime | Yes |  |
| dataout_date | datetime | Yes |  |
| copy_from_order_code | char | Yes | 12 |
| copy_from_order_date | datetime | Yes |  |
| time_analysis_flag | bit | Yes |  |
| pmt_form_code | char | Yes | 8 |
| map_updt_ordr_coord_flag | bit | Yes |  |
| map_truck_poll_type | numeric | Yes |  |
| first_truck_polled_flag | bit | Yes |  |
| cred_debit_memo_comment | char | Yes | 40 |
| tax_exempt_profile_code | char | Yes | 3 |
| pbl_zone_code | char | Yes | 8 |
| ccard_last_four | char | Yes | 4 |
| ccard_type_code | char | Yes | 2 |
| ccard_unique_id | char | Yes | 8 |
| ccard_approval_code | char | Yes | 6 |
| ccard_trans_id | numeric | Yes |  |
| ccard_paid_ind | char | Yes | 1 |
| ccard_trans_datetime | datetime | Yes |  |
| ccard_order_amt | numeric | Yes |  |
| ccard_trans_amt | numeric | Yes |  |
| ccard_trans_voided | char | Yes | 1 |
| setup_time | datetime | Yes |  |
| contact_code | char | Yes | 8 |
| air_trim_pct | numeric | Yes |  |
| third_party_cred_upd_stat_code | char | Yes | 2 |
| time_offset_available | bit | Yes |  |
| third_party_taxareaid | char | Yes | 10 |
| third_party_taxareaid_status | char | Yes | 100 |
| third_party_tax_conf_indicator | numeric | Yes |  |
| taxble_susp_rsn_code | char | Yes | 3 |
| taxble_susp_date_time | datetime | Yes |  |
| taxble_susp_user_name | char | Yes | 20 |
| taxble_susp_cancel_date_time | datetime | Yes |  |
| taxble_susp_cancel_user_name | char | Yes | 20 |
| approved_order_amt | numeric | Yes |  |
| sampling_lab_code | char | Yes | 10 |
| import_date | datetime | Yes |  |
| local_order_flag | bit | Yes |  |
| ship_addr_line_num | char | Yes | 10 |
| ship_addr_line_name | char | Yes | 30 |
| ship_addr_city_code | char | Yes | 10 |
| nbrhood | char | Yes | 40 |
| pump_insp_req_code | char | Yes | 2 |
| pump_insp_empl_code | char | Yes | 12 |
| pump_insp_stat_code | char | Yes | 2 |
| fiscal_note_ss_natop_code | numeric | Yes |  |
| fiscal_note_ds_natop_code | numeric | Yes |  |
| guid | char | Yes | 36 |
| request_status | char | Yes | 2 |
| order_copy_type_code | char | Yes | 2 |
| state_job_code | char | Yes | 32 |
| tax_ref_postcd | char | Yes | 10 |
| third_party_override_cart_flag | bit | Yes |  |
| notf_email_addr | char | Yes | 256 |
| email_addr_mobile | char | Yes | 256 |
| mobileticket_code | char | Yes | 2 |
| transaction_id | char | Yes | 36 |
| site_name | char | Yes | 40 |
| site_phone_num | char | Yes | 14 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| delv_addr | varchar | Yes | -1 |
| instr | varchar | Yes | -1 |
| user_defined | varchar | Yes | -1 |
| sur_codes | varchar | Yes | -1 |
| sur_rate_amts | varchar | Yes | -1 |
| apply_sur_rate_hler_flags | varchar | Yes | -1 |
| sundry_chrg_table_ids | varchar | Yes | -1 |
| apply_sundry_chrg_flags | varchar | Yes | -1 |
| sundry_chrg_sep_invc_flags | varchar | Yes | -1 |
| sundry_chrg_comb_meth_code | varchar | Yes | -1 |
| sundry_chrg_override_rates | varchar | Yes | -1 |
| order_msgs | varchar | Yes | -1 |
| apply_pump_unld_chrg_flag | varchar | Yes | -1 |
| pump_unld_chrg_table_id | varchar | Yes | -1 |
| apply_pump_sundry_chrg_flags | varchar | Yes | -1 |
| pump_sundry_chrg_table_ids | varchar | Yes | -1 |
| pump_sundry_chrg_over_rates | varchar | Yes | -1 |

## Table: dbo.pchc
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| sundry_chrg_table_id | char | No | 3 |
| comp_code | char | No | 4 |
| plant_code | char | No | 3 |
| prod_code | char | Yes | 12 |
| chrg_type | char | Yes | 2 |
| target_uom | char | Yes | 5 |
| time_to_use | char | Yes | 1 |
| first_load_flag | bit | Yes |  |
| auto_chrg_flag | bit | Yes |  |
| ca_apply_auto_chrg_flag | bit | Yes |  |
| cb_apply_auto_chrg_flag | bit | Yes |  |
| cc_apply_auto_chrg_flag | bit | Yes |  |
| cd_apply_auto_chrg_flag | bit | Yes |  |
| from_date | datetime | Yes |  |
| thru_date | datetime | Yes |  |
| comb_matl_price_code | char | Yes | 2 |
| apply_min_chrg_item | char | Yes | 4 |
| delv_meth_code | char | Yes | 2 |
| apply_to_pump_type | char | Yes | 1 |
| chrg_type_apply_code | char | Yes | 1 |
| allow_zero_price_in_tkt_code | bit | Yes |  |
| qty_based_on_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| apply_item_cat | varchar | Yes | 2000 |

## Table: dbo.pchg
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| sundry_chrg_table_id | char | No | 3 |
| descr | char | Yes | 40 |
| short_descr | char | Yes | 8 |
| prod_code | char | Yes | 12 |
| chrg_type | char | Yes | 2 |
| target_uom | char | Yes | 5 |
| time_to_use | char | Yes | 1 |
| first_load_flag | bit | Yes |  |
| auto_chrg_flag | bit | Yes |  |
| ca_apply_auto_chrg_flag | bit | Yes |  |
| cb_apply_auto_chrg_flag | bit | Yes |  |
| cc_apply_auto_chrg_flag | bit | Yes |  |
| cd_apply_auto_chrg_flag | bit | Yes |  |
| from_date | datetime | Yes |  |
| thru_date | datetime | Yes |  |
| comb_matl_price_code | char | Yes | 2 |
| apply_min_chrg_item_code | char | Yes | 4 |
| delv_meth_code | char | Yes | 2 |
| apply_to_pump_flag | bit | Yes |  |
| sep_invc_flag | bit | Yes |  |
| apply_to_zone_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| apply_item_cat | varchar | Yes | 2000 |

## Table: dbo.pchl
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| sundry_chrg_table_id | char | No | 3 |
| comp_code | char | No | 4 |
| plant_code | char | No | 3 |
| unique_num | numeric | No |  |
| begin_time | datetime | Yes |  |
| end_time | datetime | Yes |  |
| day_1_flag | bit | Yes |  |
| day_2_flag | bit | Yes |  |
| day_3_flag | bit | Yes |  |
| day_4_flag | bit | Yes |  |
| day_5_flag | bit | Yes |  |
| day_6_flag | bit | Yes |  |
| day_7_flag | bit | Yes |  |
| curr_chrg | numeric | Yes |  |
| curr_pct | numeric | Yes |  |
| prev_chrg | numeric | Yes |  |
| prev_pct | numeric | Yes |  |
| effect_date | datetime | Yes |  |
| item_code | char | Yes | 12 |
| item_cat | char | Yes | 6 |
| intrnl_line_num | numeric | Yes |  |
| sundry_line_type | char | Yes | 1 |
| prod_code | char | Yes | 12 |
| prod_cat | char | Yes | 6 |
| tkt_prod_code | char | Yes | 12 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.pcon
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| proj_code | char | No | 12 |
| contct_code | char | No | 12 |
| unique_num | numeric | No |  |
| contct_type | char | Yes | 2 |
| primary_flag | bit | Yes |  |
| mob_tkt_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.plap
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| proj_code | char | No | 12 |
| intrnl_line_num | numeric | No |  |
| assoc_prod_code | char | No | 12 |
| sort_line_num | numeric | Yes |  |
| prod_descr | char | Yes | 40 |
| short_prod_descr | char | Yes | 16 |
| price | numeric | Yes |  |
| price_uom | char | Yes | 5 |
| price_ext_code | char | Yes | 1 |
| price_expir_date | datetime | Yes |  |
| effect_date | datetime | Yes |  |
| prev_price | numeric | Yes |  |
| prev_price_ext_code | char | Yes | 1 |
| est_qty | numeric | Yes |  |
| dflt_load_qty | numeric | Yes |  |
| price_in_mix_price_flag | bit | Yes |  |
| quote_code | char | Yes | 15 |
| allow_price_adjust_flag | bit | Yes |  |
| order_qty_uom | char | Yes | 5 |
| order_qty_ext_code | char | Yes | 1 |
| order_dosage_qty | numeric | Yes |  |
| order_dosage_qty_uom | char | Yes | 5 |
| delv_qty_uom | char | Yes | 5 |
| price_qty_ext_code | char | Yes | 1 |
| tkt_qty_ext_code | char | Yes | 1 |
| per_cem_wgt_divisor | numeric | Yes |  |
| sep_invc_flag | bit | Yes |  |
| quote_rev_num | char | Yes | 3 |
| job_quote_unique_line_num | numeric | Yes |  |
| modified_date | datetime | Yes |  |
| auth_user_name | char | Yes | 20 |
| price_status | char | Yes | 2 |
| unique_line_num | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.plno
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| plant_code | char | No | 3 |
| generic_bigger_masks_flag | bit | Yes |  |
| next_journey_seq | char | Yes | 3 |
| fuel_station_flag | char | Yes | 2 |
| delayed_ticket_flag | bit | Yes |  |
| delayed_mgr_num | numeric | Yes |  |
| delayed_port_num | numeric | Yes |  |
| delayed_sel_addr | numeric | Yes |  |
| delayed_doc_format_code | char | Yes | 8 |
| delayed_doc_format_group_code | char | Yes | 8 |
| delayed_auto_dial_flag | bit | Yes |  |
| delayed_modem_phone_num | char | Yes | 14 |
| delayed_modem_code | char | Yes | 8 |
| delayed_port_setup | char | Yes | 40 |
| delayed_ticket_copies | numeric | Yes |  |
| delayed_port_url | varchar | Yes | 200 |
| hard_truck_max_distance | numeric | Yes |  |
| next_integrated_tkt_seq | char | Yes | 3 |
| truck_trvl_time_multi | numeric | Yes |  |
| max_dumped_concrete_per_day | numeric | Yes |  |
| max_dumped_concrete_per_load | numeric | Yes |  |
| batch_doc_fmt_code | char | Yes | 8 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.plnt
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| plant_code | char | No | 3 |
| addr_line_1 | char | Yes | 40 |
| addr_line_2 | char | Yes | 40 |
| addr_line_3 | char | Yes | 40 |
| air_trim_pct | numeric | Yes |  |
| max_batch_size | numeric | Yes |  |
| max_batch_size_uom | char | Yes | 5 |
| calcm_trim_pct | numeric | Yes |  |
| comp_code | char | Yes | 4 |
| tkting_dev_type | numeric | Yes |  |
| tkting_mgr_num | numeric | Yes |  |
| tkting_port_num | numeric | Yes |  |
| tkting_sel_addr | numeric | Yes |  |
| tkting_doc_fmt_code | char | Yes | 8 |
| tkting_auto_dial_flag | bit | Yes |  |
| tkting_modem_phone_num | char | Yes | 14 |
| tkting_modem_code | char | Yes | 8 |
| tkting_tcp_ip_listen_port | numeric | Yes |  |
| disptch_copy_flag | bit | Yes |  |
| disptch_mgr_num | numeric | Yes |  |
| disptch_port_num | numeric | Yes |  |
| disptch_sel_addr | numeric | Yes |  |
| disptch_doc_fmt_code | char | Yes | 8 |
| disptch_auto_dial_flag | bit | Yes |  |
| disptch_modem_phone_num | char | Yes | 14 |
| disptch_modem_code | char | Yes | 8 |
| rpting_flag | bit | Yes |  |
| rpting_mgr_num | numeric | Yes |  |
| rpting_port_num | numeric | Yes |  |
| rpting_sel_addr | numeric | Yes |  |
| rpting_auto_dial_flag | bit | Yes |  |
| rpting_modem_phone_num | char | Yes | 14 |
| rpting_modem_code | char | Yes | 8 |
| order_print_flag | bit | Yes |  |
| order_print_mgr_num | numeric | Yes |  |
| order_print_port_num | numeric | Yes |  |
| order_print_sel_addr | numeric | Yes |  |
| order_print_doc_fmt_code | char | Yes | 8 |
| order_print_auto_dial_flag | bit | Yes |  |
| order_print_modem_phone_num | char | Yes | 14 |
| order_print_modem_code | char | Yes | 8 |
| driv_lead_time | numeric | Yes |  |
| next_tkt_seq | char | Yes | 3 |
| next_order_seq | char | Yes | 3 |
| next_invc_seq | char | Yes | 3 |
| plant_load_time | numeric | Yes |  |
| name | char | Yes | 40 |
| phone_num | char | Yes | 14 |
| short_name | char | Yes | 8 |
| super_plast_trim_pct | numeric | Yes |  |
| tax_code | char | Yes | 3 |
| terms_code | char | Yes | 3 |
| plant_washdown_time | numeric | Yes |  |
| job_washdown_time | numeric | Yes |  |
| water_trim_pct | numeric | Yes |  |
| batch_water_uom | char | Yes | 5 |
| weigh_master_empl_code | char | Yes | 12 |
| plant_yard_time | numeric | Yes |  |
| zone_code | char | Yes | 8 |
| batch_poll_sleep_time | numeric | Yes |  |
| batch_upld_wgts_flag | bit | Yes |  |
| track_flag | bit | Yes |  |
| sched_flag | bit | Yes |  |
| dflt_num_of_trucks | numeric | Yes |  |
| dflt_cpcty | numeric | Yes |  |
| curr_cpcty | numeric | Yes |  |
| mixer_time | numeric | Yes |  |
| adj_mix_by_tkt_flag | bit | Yes |  |
| track_truck_color | numeric | Yes |  |
| loaded_column_flag | bit | Yes |  |
| trvl_time | numeric | Yes |  |
| admin_per_qty_cost | numeric | Yes |  |
| sales_per_qty_cost | numeric | Yes |  |
| disptch_per_qty_cost | numeric | Yes |  |
| plant_per_qty_cost | numeric | Yes |  |
| fixed_truck_per_qty_cost | numeric | Yes |  |
| variable_truck_per_hour_cost | numeric | Yes |  |
| annl_intrst_pct | numeric | Yes |  |
| truck_eff_factor | numeric | Yes |  |
| desired_profit_per_qty | numeric | Yes |  |
| loc_code | char | Yes | 4 |
| scale_code | char | Yes | 3 |
| target_mgr_num | numeric | Yes |  |
| map_long | char | Yes | 9 |
| map_lat | char | Yes | 9 |
| map_radius | numeric | Yes |  |
| alley_code_1 | char | Yes | 3 |
| alley_code_2 | char | Yes | 3 |
| alley_code_3 | char | Yes | 3 |
| alley_code_4 | char | Yes | 3 |
| weighed_water_flag | bit | Yes |  |
| qc_code | char | Yes | 1 |
| track_order_color | numeric | Yes |  |
| matl_trnsfr_rcpt_option | char | Yes | 1 |
| ca_plant_flag | bit | Yes |  |
| cb_plant_flag | bit | Yes |  |
| cc_plant_flag | bit | Yes |  |
| cd_plant_flag | bit | Yes |  |
| matl_trfs_rcpt_opt | char | Yes | 1 |
| norm_start_time | datetime | Yes |  |
| norm_end_time | datetime | Yes |  |
| signl_unit_code | char | Yes | 3 |
| map_page | char | Yes | 8 |
| asphalt_scale_feeds | char | Yes | 2 |
| imaging_file_location | char | Yes | 128 |
| imaging_file_format | char | Yes | 8 |
| asphalt_drop_prompt | char | Yes | 2 |
| batch_watcher_upd_flag | bit | Yes |  |
| optimize_code | char | Yes | 2 |
| tkting_doc_fmt_group_code | char | Yes | 8 |
| disptch_doc_fmt_group_code | char | Yes | 8 |
| color_dev_type | numeric | Yes |  |
| color_tcp_ip_listen_port | numeric | Yes |  |
| color_plant_water | numeric | Yes |  |
| color_plant_water_uom | char | Yes | 5 |
| color_max_batch_size | numeric | Yes |  |
| color_max_batch_size_uom | char | Yes | 5 |
| color_time | numeric | Yes |  |
| adjust_cement_with_slump_code | char | Yes | 2 |
| slump_increment | numeric | Yes |  |
| cement_change_per_increment | numeric | Yes |  |
| min_max_slump_change | numeric | Yes |  |
| warn_or_stop_code | char | Yes | 2 |
| cement_change_prod_code | char | Yes | 12 |
| download_dose_qty_code | char | Yes | 2 |
| ca_tkt_overld_truck_code | char | Yes | 2 |
| tare_weight_code | char | Yes | 2 |
| certificate_expiration_code | char | Yes | 2 |
| cc_tkt_overld_truck_code | char | Yes | 2 |
| dosage_type_qty_interface_code | char | Yes | 2 |
| enable_load_toler | char | Yes | 2 |
| load_toler_qty | numeric | Yes |  |
| load_toler_qty_uom | char | Yes | 5 |
| plant_min_load_size | numeric | Yes |  |
| plant_min_load_size_uom | char | Yes | 5 |
| color_upload_method | char | Yes | 1 |
| cust_seq | char | Yes | 3 |
| sap_tkt_print_flag | bit | Yes |  |
| batch_wgts_from_server_flag | bit | Yes |  |
| region_code | char | Yes | 3 |
| loading_speed_code | char | Yes | 5 |
| load_fee | numeric | Yes |  |
| amt_per_unit_dist | numeric | Yes |  |
| batch_status_color_code | char | Yes | 2 |
| addr_city | char | Yes | 40 |
| addr_state | char | Yes | 10 |
| addr_cntry | char | Yes | 3 |
| addr_postcd | char | Yes | 10 |
| third_party_taxareaid | char | Yes | 10 |
| third_party_poa_taxareaid | char | Yes | 10 |
| ca_tkt_underld_truck_code | char | Yes | 2 |
| schedulecom_comp_code | char | Yes | 20 |
| tkting_print_ticket_flag | bit | Yes |  |
| snrty_group_code | char | Yes | 12 |
| master_plant_option | char | Yes | 2 |
| master_plant_code | char | Yes | 3 |
| max_deadhead_mins | numeric | Yes |  |
| mix_download_batch_num | numeric | Yes |  |
| fixed_opening_cost | numeric | Yes |  |
| hourly_oper_cost | numeric | Yes |  |
| driver_callin_interval | numeric | Yes |  |
| dflt_forbid_plant | bit | Yes |  |
| rotating_snrty_count | numeric | Yes |  |
| loading_speed_code_2 | char | Yes | 5 |
| callin_seniority_meth_weekday | char | Yes | 2 |
| callin_seniority_meth_weekend | char | Yes | 2 |
| driv_login_offset_mins | numeric | Yes |  |
| post_in_yard_mins | numeric | Yes |  |
| truck_max_distance_plant | numeric | Yes |  |
| on_call_driver_delay_mins | numeric | Yes |  |
| truck_max_time_plant | numeric | Yes |  |
| day_1_start_time | datetime | Yes |  |
| day_1_end_time | datetime | Yes |  |
| day_2_start_time | datetime | Yes |  |
| day_2_end_time | datetime | Yes |  |
| day_3_start_time | datetime | Yes |  |
| day_3_end_time | datetime | Yes |  |
| day_4_start_time | datetime | Yes |  |
| day_4_end_time | datetime | Yes |  |
| day_5_start_time | datetime | Yes |  |
| day_5_end_time | datetime | Yes |  |
| day_6_start_time | datetime | Yes |  |
| day_6_end_time | datetime | Yes |  |
| day_7_start_time | datetime | Yes |  |
| day_7_end_time | datetime | Yes |  |
| pseudo_plant_sched_plant_code | char | Yes | 3 |
| num_loading_points | numeric | Yes |  |
| addr_city_code | char | Yes | 10 |
| tax_id | char | Yes | 20 |
| state_tax_id | char | Yes | 20 |
| nbrhood | char | Yes | 40 |
| govt_tkt_series_code | char | Yes | 5 |
| addl_info | char | Yes | 500 |
| update_end_load_flag | bit | Yes |  |
| environment_id | char | Yes | 2 |
| incl_traffic_infl_code | char | Yes | 2 |
| test_lab_code | char | Yes | 10 |
| next_specimen_seq | char | Yes | 3 |
| addr_line_1_num | char | Yes | 10 |
| addr_line_1_name | char | Yes | 30 |
| pump_tkt_doc_fmt_code | char | Yes | 8 |
| pump_disptch_doc_fmt_code | char | Yes | 8 |
| next_pump_tkt_seq | char | Yes | 3 |
| mobileticket_code | char | Yes | 2 |
| cancelled_tkt_window | numeric | Yes |  |
| trav_restrict_code | char | Yes | 5 |
| tkting_tcp_ip_addr | char | Yes | 50 |
| color_tcp_ip_addr | char | Yes | 50 |
| batch_upld_edx_flag | bit | Yes |  |
| tkting_copies | numeric | Yes |  |
| disptch_copies | numeric | Yes |  |
| order_copies | numeric | Yes |  |
| rpting_copies | numeric | Yes |  |
| cc_tkt_underld_truck_code | char | Yes | 2 |
| day_1_batch_start_time | datetime | Yes |  |
| day_1_batch_end_time | datetime | Yes |  |
| day_1_night_start_time | datetime | Yes |  |
| day_1_night_end_time | datetime | Yes |  |
| day_2_batch_start_time | datetime | Yes |  |
| day_2_batch_end_time | datetime | Yes |  |
| day_2_night_start_time | datetime | Yes |  |
| day_2_night_end_time | datetime | Yes |  |
| day_3_batch_start_time | datetime | Yes |  |
| day_3_batch_end_time | datetime | Yes |  |
| day_3_night_start_time | datetime | Yes |  |
| day_3_night_end_time | datetime | Yes |  |
| day_4_batch_start_time | datetime | Yes |  |
| day_4_batch_end_time | datetime | Yes |  |
| day_4_night_start_time | datetime | Yes |  |
| day_4_night_end_time | datetime | Yes |  |
| day_5_batch_start_time | datetime | Yes |  |
| day_5_batch_end_time | datetime | Yes |  |
| day_5_night_start_time | datetime | Yes |  |
| day_5_night_end_time | datetime | Yes |  |
| day_6_batch_start_time | datetime | Yes |  |
| day_6_batch_end_time | datetime | Yes |  |
| day_6_night_start_time | datetime | Yes |  |
| day_6_night_end_time | datetime | Yes |  |
| day_7_batch_start_time | datetime | Yes |  |
| day_7_batch_end_time | datetime | Yes |  |
| day_7_night_start_time | datetime | Yes |  |
| day_7_night_end_time | datetime | Yes |  |
| plant_open_flag_code | char | Yes | 1 |
| plant_batch_sync_code | char | Yes | 1 |
| ca_certificate_expiration_code | char | Yes | 2 |
| next_proj_seq | char | Yes | 3 |
| accept_dumped_concrete | char | Yes | 2 |
| dumping_speed | numeric | Yes |  |
| dump_per_qty_cost | numeric | Yes |  |
| fixed_dumping_cost | numeric | Yes |  |
| in_yard_mins_first_load | numeric | Yes |  |
| in_yard_mins_first_driv | numeric | Yes |  |
| over_mixing_time_allow | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| tkting_port_url | varchar | Yes | 200 |
| disptch_port_url | varchar | Yes | 200 |
| rpting_port_url | varchar | Yes | 200 |
| order_print_port_url | varchar | Yes | 200 |
| tkting_port_setup | varchar | Yes | 30 |
| disptch_port_setup | varchar | Yes | 30 |
| rpting_port_setup | varchar | Yes | 30 |
| order_print_port_setup | varchar | Yes | 30 |
| user_defined | varchar | Yes | 2000 |
| sap_tkt_url | varchar | Yes | 500 |

## Table: dbo.pltf
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| plant_code | char | No | 3 |
| order_date | datetime | No |  |
| num_of_trucks | numeric | Yes |  |
| dflt_cpcty | numeric | Yes |  |
| curr_cpcty | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.plto
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| plant_code | char | No | 3 |
| const_prod_code | char | No | 12 |
| sort_num | numeric | Yes |  |
| bin_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.pmet
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| pour_meth_code | char | No | 4 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| optimizer_code | char | Yes | 2 |
| unld_mins_per_unit | numeric | Yes |  |
| uom | char | Yes | 5 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.pmtf
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| pmt_form_code | char | No | 8 |
| descr | char | Yes | 40 |
| short_descr | char | Yes | 8 |
| pmt_meth | char | Yes | 1 |
| sundry_chrg_table_id | char | Yes | 3 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.pratt
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| layout | char | No | 16 |
| printer | char | Yes | 16 |
| device | char | Yes | 16 |
| pagel | char | Yes | 8 |
| pagew | char | Yes | 8 |
| leftm | char | Yes | 8 |
| rightm | char | Yes | 8 |
| top | char | Yes | 8 |
| bottom | char | Yes | 8 |
| pitch | char | Yes | 8 |
| linesp | char | Yes | 8 |
| options | varbinary | Yes | 7888 |

## Table: dbo.prcc
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| price_cat | char | No | 3 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.prcr
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| proj_code | char | No | 12 |
| comp_code | char | No | 4 |
| last_invc_amt | numeric | Yes |  |
| last_invc_date | datetime | Yes |  |
| last_check_amt | numeric | Yes |  |
| last_check_date | datetime | Yes |  |
| curr_bal_amt | numeric | Yes |  |
| curr_ret_amt | numeric | Yes |  |
| high_bal_amt | numeric | Yes |  |
| high_bal_date | datetime | Yes |  |
| cred_code | char | Yes | 3 |
| cred_chng_date | datetime | Yes |  |
| prev_cred_code | char | Yes | 3 |
| cred_limit_amt | numeric | Yes |  |
| ar_cred_empl_code | char | Yes | 12 |
| avg_pmt_days | numeric | Yes |  |
| avg_pmt_trans | numeric | Yes |  |
| booked_orders_amt | numeric | Yes |  |
| shipped_orders_amt | numeric | Yes |  |
| cred_update_date | datetime | Yes |  |
| perform_cred_update_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.priv
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| user_name | char | No | 20 |
| appl | char | No | 2 |
| form | char | No | 10 |
| priv_add | bit | Yes |  |
| priv_chng | bit | Yes |  |
| priv_inq | bit | Yes |  |
| priv_price_sup | bit | Yes |  |
| priv_cost_sup | bit | Yes |  |
| form_vpos | numeric | Yes |  |
| form_hpos | numeric | Yes |  |
| form_alt_key | numeric | Yes |  |
| field_priv | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| field_list | varchar | Yes | -1 |

## Table: dbo.prjd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| proj_code | char | No | 12 |
| plant_code | char | No | 3 |
| distance | numeric | Yes |  |
| est_trvl | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.prjo
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| proj_code | char | No | 12 |
| susp_rsn_code | char | Yes | 3 |
| ca_est_qty | numeric | Yes |  |
| cb_est_qty | numeric | Yes |  |
| cc_est_qty | numeric | Yes |  |
| cd_est_qty | numeric | Yes |  |
| ca_est_qty_uom | char | Yes | 5 |
| cb_est_qty_uom | char | Yes | 5 |
| cc_est_qty_uom | char | Yes | 5 |
| cd_est_qty_uom | char | Yes | 5 |
| lien_loc_req_code | char | Yes | 1 |
| lien_exp_flag | bit | Yes |  |
| lien_loc_multi_code | char | Yes | 1 |
| dflt_lien_loc_code | char | Yes | 10 |
| cust_job_num_req_flag | bit | Yes |  |
| cred_limit_flag | bit | Yes |  |
| cred_limit_level_code | char | Yes | 1 |
| ca_dflt_order_type | char | Yes | 2 |
| cb_dflt_order_type | char | Yes | 2 |
| cc_dflt_order_type | char | Yes | 2 |
| cd_dflt_order_type | char | Yes | 2 |
| ca_job_code | char | Yes | 16 |
| cb_job_code | char | Yes | 16 |
| cc_job_code | char | Yes | 16 |
| cd_job_code | char | Yes | 16 |
| ca_cart_rate_effect_date | datetime | Yes |  |
| cb_cart_rate_effect_date | datetime | Yes |  |
| cc_cart_rate_effect_date | datetime | Yes |  |
| cd_cart_rate_effect_date | datetime | Yes |  |
| ca_prev_cart_rate | numeric | Yes |  |
| cb_prev_cart_rate | numeric | Yes |  |
| cc_prev_cart_rate | numeric | Yes |  |
| cd_prev_cart_rate | numeric | Yes |  |
| ca_pay_cart_code | char | Yes | 3 |
| cb_pay_cart_code | char | Yes | 3 |
| cc_pay_cart_code | char | Yes | 3 |
| cd_pay_cart_code | char | Yes | 3 |
| ca_apply_min_haul_pay_flag | bit | Yes |  |
| cb_apply_min_haul_pay_flag | bit | Yes |  |
| cc_apply_min_haul_pay_flag | bit | Yes |  |
| cd_apply_min_haul_pay_flag | bit | Yes |  |
| begin_date | datetime | Yes |  |
| priority | numeric | Yes |  |
| max_mins_early | numeric | Yes |  |
| max_mins_late | numeric | Yes |  |
| quote_rev_num | char | Yes | 3 |
| modified_date | datetime | Yes |  |
| ca_allow_price_chng_flag | bit | Yes |  |
| cb_allow_price_chng_flag | bit | Yes |  |
| cc_allow_price_chng_flag | bit | Yes |  |
| cd_allow_price_chng_flag | bit | Yes |  |
| type_price | char | Yes | 1 |
| prelien_date_calc_code | char | Yes | 1 |
| cc_map_updt_proj_coord_flag | bit | Yes |  |
| cc_map_updt_ordr_coord_flag | bit | Yes |  |
| cc_map_truck_poll_type | numeric | Yes |  |
| max_tax_life_flag | bit | Yes |  |
| tax_exempt_profile_code | char | Yes | 3 |
| third_party_taxareaid | char | Yes | 10 |
| third_party_taxareaid_status | char | Yes | 100 |
| third_party_tax_conf_indicator | numeric | Yes |  |
| ca_allow_price_suppress_flag | bit | Yes |  |
| cb_allow_price_suppress_flag | bit | Yes |  |
| cc_allow_price_suppress_flag | bit | Yes |  |
| cd_allow_price_suppress_flag | bit | Yes |  |
| ca_tkt_print_doc_fmt_code | char | Yes | 8 |
| cb_tkt_print_doc_fmt_code | char | Yes | 8 |
| cc_tkt_print_doc_fmt_code | char | Yes | 8 |
| cd_tkt_print_doc_fmt_code | char | Yes | 8 |
| invc_delv_meth | char | Yes | 2 |
| invc_email_to_addr | char | Yes | 100 |
| invc_email_to_contct_code | char | Yes | 12 |
| restrict_tick_by_estqty_code | char | Yes | 2 |
| ship_addr_city_code | char | Yes | 10 |
| tax_id | char | Yes | 20 |
| state_tax_id | char | Yes | 20 |
| nbrhood | char | Yes | 40 |
| ship_addr_line_1_num | char | Yes | 10 |
| ship_addr_line_1_name | char | Yes | 30 |
| cc_pump_insp_req_code | char | Yes | 2 |
| pump_unld_chrg_sep_invc_flag | bit | Yes |  |
| post_in_yard_mins | numeric | Yes |  |
| pump_split_tkt_invc_code | char | Yes | 2 |
| send_proj_stmt | char | Yes | 2 |
| stmt_delv_meth | char | Yes | 2 |
| stmt_email_to_addr | char | Yes | 100 |
| stmt_email_to_contct_code | char | Yes | 12 |
| state_job_code | char | Yes | 32 |
| cc_min_load_chrg_msg_code | char | Yes | 2 |
| cc_min_load_msgs | numeric | Yes |  |
| cc_trade_disc_effect_date | datetime | Yes |  |
| cc_prev_trade_disc_amt | numeric | Yes |  |
| cc_prev_trade_disc_pct | numeric | Yes |  |
| site_name | char | Yes | 40 |
| site_phone_num | char | Yes | 14 |
| allow_auto_spread_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| pump_unld_chrg_table_id | varchar | Yes | -1 |
| pump_sundry_chrg_table_ids | varchar | Yes | -1 |

## Table: dbo.prjp
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| proj_code | char | No | 12 |
| intrnl_line_num | numeric | No |  |
| sort_line_num | numeric | Yes |  |
| prod_code | char | Yes | 12 |
| batch_code | char | Yes | 12 |
| prod_descr | char | Yes | 40 |
| est_qty | numeric | Yes |  |
| rm_slump | char | Yes | 8 |
| rm_slump_uom | char | Yes | 5 |
| usage_code | char | Yes | 4 |
| short_prod_descr | char | Yes | 16 |
| price_uom | char | Yes | 5 |
| price | numeric | Yes |  |
| price_ext_code | char | Yes | 1 |
| price_plant_code | char | Yes | 3 |
| price_expir_date | datetime | Yes |  |
| effect_date | datetime | Yes |  |
| prev_price | numeric | Yes |  |
| prev_price_ext_code | char | Yes | 1 |
| delv_price_flag | bit | Yes |  |
| dflt_load_qty | numeric | Yes |  |
| order_qty_uom | char | Yes | 5 |
| order_qty_ext_code | char | Yes | 1 |
| order_dosage_qty | numeric | Yes |  |
| order_dosage_qty_uom | char | Yes | 5 |
| delv_qty_uom | char | Yes | 5 |
| price_qty_ext_code | char | Yes | 1 |
| tkt_qty_ext_code | char | Yes | 1 |
| mix_type | char | Yes | 1 |
| item_type | char | Yes | 2 |
| quote_code | char | Yes | 15 |
| allow_price_adjust_flag | bit | Yes |  |
| sep_invc_flag | bit | Yes |  |
| override_terms_disc_flag | bit | Yes |  |
| disc_rate_type | char | Yes | 1 |
| disc_amt | numeric | Yes |  |
| disc_amt_uom | char | Yes | 5 |
| content_up_price | numeric | Yes |  |
| content_down_price | numeric | Yes |  |
| content_up_price_effect_date | datetime | Yes |  |
| content_down_price_effect_date | datetime | Yes |  |
| prev_content_up_price | numeric | Yes |  |
| prev_content_down_price | numeric | Yes |  |
| ca_chrg_cart_code | char | Yes | 3 |
| cb_chrg_cart_code | char | Yes | 3 |
| cc_chrg_cart_code | char | Yes | 3 |
| cd_chrg_cart_code | char | Yes | 3 |
| job_quote_unique_line_num | numeric | Yes |  |
| pour_meth_code | char | Yes | 4 |
| ca_truck_type | char | Yes | 2 |
| cb_truck_type | char | Yes | 2 |
| cc_truck_type | char | Yes | 2 |
| cd_truck_type | char | Yes | 2 |
| ca_chrg_cart_rate | numeric | Yes |  |
| cb_chrg_cart_rate | numeric | Yes |  |
| cc_chrg_cart_rate | numeric | Yes |  |
| cd_chrg_cart_rate | numeric | Yes |  |
| quote_rev_num | char | Yes | 3 |
| modified_date | datetime | Yes |  |
| type_price | char | Yes | 1 |
| matl_price | numeric | Yes |  |
| auto_prod_flag | bit | Yes |  |
| item_cat_price_flag | bit | Yes |  |
| auth_user_name | char | Yes | 20 |
| price_status | char | Yes | 2 |
| unique_line_num | numeric | Yes |  |
| sampling_interval | numeric | Yes |  |
| sampling_interval_uom | char | Yes | 5 |
| sampling_qty_bal_forward | numeric | Yes |  |
| sampling_count_bal_forward | numeric | Yes |  |
| max_age_of_concrete | numeric | Yes |  |
| writeoff_qty | numeric | Yes |  |
| writeoff_first_load_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| ca_sur_codes | varchar | Yes | -1 |
| cb_sur_codes | varchar | Yes | -1 |
| cc_sur_codes | varchar | Yes | -1 |
| cd_sur_codes | varchar | Yes | -1 |
| ca_sur_rates | varchar | Yes | -1 |
| cb_sur_rates | varchar | Yes | -1 |
| cc_sur_rates | varchar | Yes | -1 |
| cd_sur_rates | varchar | Yes | -1 |
| ca_sundry_chrg_table_ids | varchar | Yes | -1 |
| cb_sundry_chrg_table_ids | varchar | Yes | -1 |
| cc_sundry_chrg_table_ids | varchar | Yes | -1 |
| cd_sundry_chrg_table_ids | varchar | Yes | -1 |
| ca_sundry_chrg_sep_invc_flags | varchar | Yes | -1 |
| cb_sundry_chrg_sep_invc_flags | varchar | Yes | -1 |
| cc_sundry_chrg_sep_invc_flags | varchar | Yes | -1 |
| cd_sundry_chrg_sep_invc_flags | varchar | Yes | -1 |

## Table: dbo.proj
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| proj_code | char | No | 12 |
| proj_name | char | Yes | 40 |
| sort_name | char | Yes | 8 |
| ship_cust_code | char | Yes | 10 |
| ref_cust_code | char | Yes | 10 |
| po | char | Yes | 24 |
| cust_job_num | char | Yes | 24 |
| est_qty | numeric | Yes |  |
| est_qty_uom | char | Yes | 5 |
| est_trvl | numeric | Yes |  |
| contct_name | char | Yes | 40 |
| phone_num_1 | char | Yes | 14 |
| phone_num_2 | char | Yes | 14 |
| phone_num_3 | char | Yes | 14 |
| phone_num_4 | char | Yes | 14 |
| setup_date | datetime | Yes |  |
| expir_date | datetime | Yes |  |
| invc_name | char | Yes | 40 |
| invc_addr_line_1 | char | Yes | 40 |
| invc_addr_line_2 | char | Yes | 40 |
| invc_city | char | Yes | 40 |
| invc_state | char | Yes | 10 |
| invc_cntry | char | Yes | 3 |
| invc_postcd | char | Yes | 10 |
| stmnt_name | char | Yes | 40 |
| stmnt_addr_line_1 | char | Yes | 40 |
| stmnt_addr_line_2 | char | Yes | 40 |
| stmnt_city | char | Yes | 40 |
| stmnt_state | char | Yes | 10 |
| stmnt_cntry | char | Yes | 3 |
| stmnt_postcd | char | Yes | 10 |
| ship_name | char | Yes | 40 |
| ship_addr_line_1 | char | Yes | 40 |
| ship_addr_line_2 | char | Yes | 40 |
| ship_city | char | Yes | 40 |
| ship_state | char | Yes | 10 |
| ship_cntry | char | Yes | 3 |
| ship_postcd | char | Yes | 10 |
| ca_sales_anl_code | char | Yes | 3 |
| cb_sales_anl_code | char | Yes | 3 |
| cc_sales_anl_code | char | Yes | 3 |
| cd_sales_anl_code | char | Yes | 3 |
| ca_slsmn_empl_code | char | Yes | 12 |
| cb_slsmn_empl_code | char | Yes | 12 |
| cc_slsmn_empl_code | char | Yes | 12 |
| cd_slsmn_empl_code | char | Yes | 12 |
| tax_code | char | Yes | 3 |
| taxble_code | numeric | Yes |  |
| non_tax_rsn_code | char | Yes | 3 |
| ca_price_cat | char | Yes | 3 |
| cb_price_cat | char | Yes | 3 |
| cc_price_cat | char | Yes | 3 |
| cd_price_cat | char | Yes | 3 |
| ca_price_plant_code | char | Yes | 3 |
| cb_price_plant_code | char | Yes | 3 |
| cc_price_plant_code | char | Yes | 3 |
| cd_price_plant_code | char | Yes | 3 |
| ca_trade_disc_pct | numeric | Yes |  |
| cb_trade_disc_pct | numeric | Yes |  |
| cc_trade_disc_pct | numeric | Yes |  |
| cd_trade_disc_pct | numeric | Yes |  |
| ca_trade_disc_amt | numeric | Yes |  |
| cb_trade_disc_amt | numeric | Yes |  |
| cc_trade_disc_amt | numeric | Yes |  |
| cd_trade_disc_amt | numeric | Yes |  |
| ca_trade_disc_amt_uom | char | Yes | 5 |
| cb_trade_disc_amt_uom | char | Yes | 5 |
| cc_trade_disc_amt_uom | char | Yes | 5 |
| cd_trade_disc_amt_uom | char | Yes | 5 |
| ca_terms_code | char | Yes | 3 |
| cb_terms_code | char | Yes | 3 |
| cc_terms_code | char | Yes | 3 |
| cd_terms_code | char | Yes | 3 |
| ca_cart_code | char | Yes | 3 |
| cb_cart_code | char | Yes | 3 |
| cc_cart_code | char | Yes | 3 |
| cd_cart_code | char | Yes | 3 |
| ca_cart_rate | numeric | Yes |  |
| cb_cart_rate | numeric | Yes |  |
| cc_cart_rate | numeric | Yes |  |
| cd_cart_rate | numeric | Yes |  |
| ca_apply_min_haul_flag | bit | Yes |  |
| cb_apply_min_haul_flag | bit | Yes |  |
| cc_apply_min_haul_flag | bit | Yes |  |
| cd_apply_min_haul_flag | bit | Yes |  |
| ca_apply_zone_chrg_flag | bit | Yes |  |
| cb_apply_zone_chrg_flag | bit | Yes |  |
| cc_apply_zone_chrg_flag | bit | Yes |  |
| cd_apply_zone_chrg_flag | bit | Yes |  |
| ca_zone_code | char | Yes | 8 |
| cb_zone_code | char | Yes | 8 |
| cc_zone_code | char | Yes | 8 |
| cd_zone_code | char | Yes | 8 |
| ca_apply_min_load_chrg_flag | bit | Yes |  |
| cb_apply_min_load_chrg_flag | bit | Yes |  |
| cc_apply_min_load_chrg_flag | bit | Yes |  |
| cd_apply_min_load_chrg_flag | bit | Yes |  |
| ca_min_load_chrg_table_id | char | Yes | 3 |
| cb_min_load_chrg_table_id | char | Yes | 3 |
| cc_min_load_chrg_table_id | char | Yes | 3 |
| cd_min_load_chrg_table_id | char | Yes | 3 |
| ca_apply_excess_unld_chrg_flag | bit | Yes |  |
| cb_apply_excess_unld_chrg_flag | bit | Yes |  |
| cc_apply_excess_unld_chrg_flag | bit | Yes |  |
| cd_apply_excess_unld_chrg_flag | bit | Yes |  |
| ca_excess_unld_chrg_table_id | char | Yes | 3 |
| cb_excess_unld_chrg_table_id | char | Yes | 3 |
| cc_excess_unld_chrg_table_id | char | Yes | 3 |
| cd_excess_unld_chrg_table_id | char | Yes | 3 |
| ca_apply_season_chrg_flag | bit | Yes |  |
| cb_apply_season_chrg_flag | bit | Yes |  |
| cc_apply_season_chrg_flag | bit | Yes |  |
| cd_apply_season_chrg_flag | bit | Yes |  |
| ca_season_chrg_table_id | char | Yes | 3 |
| cb_season_chrg_table_id | char | Yes | 3 |
| cc_season_chrg_table_id | char | Yes | 3 |
| cd_season_chrg_table_id | char | Yes | 3 |
| ca_apply_sundry_chrg_flag | bit | Yes |  |
| cb_apply_sundry_chrg_flag | bit | Yes |  |
| cc_apply_sundry_chrg_flag | bit | Yes |  |
| cd_apply_sundry_chrg_flag | bit | Yes |  |
| ca_min_load_sep_invc_flag | bit | Yes |  |
| cb_min_load_sep_invc_flag | bit | Yes |  |
| cc_min_load_sep_invc_flag | bit | Yes |  |
| cd_min_load_sep_invc_flag | bit | Yes |  |
| ca_excess_unld_sep_invc_flag | bit | Yes |  |
| cb_excess_unld_sep_invc_flag | bit | Yes |  |
| cc_excess_unld_sep_invc_flag | bit | Yes |  |
| cd_excess_unld_sep_invc_flag | bit | Yes |  |
| ca_season_sep_invc_flag | bit | Yes |  |
| cb_season_sep_invc_flag | bit | Yes |  |
| cc_season_sep_invc_flag | bit | Yes |  |
| cd_season_sep_invc_flag | bit | Yes |  |
| ca_auto_sundry_sep_invc_flag | bit | Yes |  |
| cb_auto_sundry_sep_invc_flag | bit | Yes |  |
| cc_auto_sundry_sep_invc_flag | bit | Yes |  |
| cd_auto_sundry_sep_invc_flag | bit | Yes |  |
| ca_apply_cart_rate_hler_flag | bit | Yes |  |
| cb_apply_cart_rate_hler_flag | bit | Yes |  |
| cc_apply_cart_rate_hler_flag | bit | Yes |  |
| cd_apply_cart_rate_hler_flag | bit | Yes |  |
| ca_apply_sur_rate_hler_flag | bit | Yes |  |
| cb_apply_sur_rate_hler_flag | bit | Yes |  |
| cc_apply_sur_rate_hler_flag | bit | Yes |  |
| cd_apply_sur_rate_hler_flag | bit | Yes |  |
| ca_force_price_uom_flag | bit | Yes |  |
| cb_force_price_uom_flag | bit | Yes |  |
| cc_force_price_uom_flag | bit | Yes |  |
| cd_force_price_uom_flag | bit | Yes |  |
| ca_print_tkt_prices_flag | bit | Yes |  |
| cb_print_tkt_prices_flag | bit | Yes |  |
| cc_print_tkt_prices_flag | bit | Yes |  |
| cd_print_tkt_prices_flag | bit | Yes |  |
| ca_restrict_quoted_prod_flag | bit | Yes |  |
| cb_restrict_quoted_prod_flag | bit | Yes |  |
| cc_restrict_quoted_prod_flag | bit | Yes |  |
| cd_restrict_quoted_prod_flag | bit | Yes |  |
| ca_hler_code | char | Yes | 8 |
| cb_hler_code | char | Yes | 8 |
| cc_hler_code | char | Yes | 8 |
| cd_hler_code | char | Yes | 8 |
| allow_price_adjust_flag | bit | Yes |  |
| map_page | char | Yes | 8 |
| proj_type | char | Yes | 1 |
| proj_stage | char | Yes | 1 |
| ca_print_mix_wgts_flag | bit | Yes |  |
| cb_print_mix_wgts_flag | bit | Yes |  |
| cc_print_mix_wgts_flag | bit | Yes |  |
| cd_print_mix_wgts_flag | bit | Yes |  |
| ca_sched_plant_code | char | Yes | 3 |
| cb_sched_plant_code | char | Yes | 3 |
| cc_sched_plant_code | char | Yes | 3 |
| cd_sched_plant_code | char | Yes | 3 |
| ca_truck_type | char | Yes | 2 |
| cb_truck_type | char | Yes | 2 |
| cc_truck_type | char | Yes | 2 |
| cd_truck_type | char | Yes | 2 |
| ca_delv_meth_code | char | Yes | 2 |
| cb_delv_meth_code | char | Yes | 2 |
| cc_delv_meth_code | char | Yes | 2 |
| cd_delv_meth_code | char | Yes | 2 |
| ca_track_order_color | numeric | Yes |  |
| cb_track_order_color | numeric | Yes |  |
| cc_track_order_color | numeric | Yes |  |
| cd_track_order_color | numeric | Yes |  |
| cred_code | char | Yes | 3 |
| cred_chng_date | datetime | Yes |  |
| po_req_flag | bit | Yes |  |
| lot_block_flag | bit | Yes |  |
| acct_cat_code | char | Yes | 4 |
| cred_limtn_code | char | Yes | 3 |
| prepay_pct | numeric | Yes |  |
| cred_card_name | char | Yes | 40 |
| cred_card_num | char | Yes | 30 |
| cred_card_expir_date | datetime | Yes |  |
| cred_card_resp_name | char | Yes | 40 |
| invc_grouping_code | char | Yes | 1 |
| invc_sub_grouping_code | char | Yes | 1 |
| invc_det_sum_code | char | Yes | 1 |
| invc_freq_code | char | Yes | 1 |
| invc_copies | numeric | Yes |  |
| invc_single_mult_day_code | char | Yes | 1 |
| invc_comb_haul_flag | bit | Yes |  |
| invc_show_min_haul_flag | bit | Yes |  |
| invc_sep_by_prod_line_flag | bit | Yes |  |
| metric_cstmry_code | char | Yes | 1 |
| map_long | char | Yes | 9 |
| map_lat | char | Yes | 9 |
| map_radius | numeric | Yes |  |
| intrnl_line_num | numeric | Yes |  |
| quote_flag | bit | Yes |  |
| quote_code | char | Yes | 15 |
| job_id | char | Yes | 15 |
| dataout_date | datetime | Yes |  |
| sampling_lab_code | char | Yes | 10 |
| sampling_interval | numeric | Yes |  |
| sampling_interval_uom | char | Yes | 5 |
| restrict_ordr_by_estqty_code | char | Yes | 2 |
| max_load_size | numeric | Yes |  |
| mobileticket_code | char | Yes | 2 |
| trav_restrict_code | char | Yes | 5 |
| guid | char | Yes | 36 |
| project_status | char | Yes | 2 |
| edx_synch_status_code | char | Yes | 1 |
| inactive_code | char | Yes | 2 |
| inactive_date | datetime | Yes |  |
| use_for_prod_line_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| delv_addr | varchar | Yes | -1 |
| instr | varchar | Yes | -1 |
| tax_exempt_id | varchar | Yes | -1 |
| user_defined | varchar | Yes | -1 |
| ca_order_sur_codes | varchar | Yes | -1 |
| cb_order_sur_codes | varchar | Yes | -1 |
| cc_order_sur_codes | varchar | Yes | -1 |
| cd_order_sur_codes | varchar | Yes | -1 |
| ca_order_sur_rates | varchar | Yes | -1 |
| cb_order_sur_rates | varchar | Yes | -1 |
| cc_order_sur_rates | varchar | Yes | -1 |
| cd_order_sur_rates | varchar | Yes | -1 |
| ca_sundry_chrg_table_ids | varchar | Yes | -1 |
| cb_sundry_chrg_table_ids | varchar | Yes | -1 |
| cc_sundry_chrg_table_ids | varchar | Yes | -1 |
| cd_sundry_chrg_table_ids | varchar | Yes | -1 |
| ca_sundry_chrg_sep_invc_flags | varchar | Yes | -1 |
| cb_sundry_chrg_sep_invc_flags | varchar | Yes | -1 |
| cc_sundry_chrg_sep_invc_flags | varchar | Yes | -1 |
| cd_sundry_chrg_sep_invc_flags | varchar | Yes | -1 |

## Table: dbo.prsc
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| proj_code | char | No | 12 |
| intrnl_line_num | numeric | No |  |
| prod_line_code | char | No | 2 |
| sundry_chrg_table_id | char | No | 3 |
| sort_line_num | numeric | Yes |  |
| item_code | char | Yes | 12 |
| price | numeric | Yes |  |
| price_uom | char | Yes | 5 |
| price_ext_code | char | Yes | 1 |
| effect_date | datetime | Yes |  |
| prev_price | numeric | Yes |  |
| prev_price_ext_code | char | Yes | 1 |
| sep_invc_flag | bit | Yes |  |
| modified_date | datetime | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.psch
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| cust_code | char | No | 10 |
| proj_code | char | No | 12 |
| intrnl_line_num | numeric | No |  |
| sched_date | datetime | No |  |
| price_plant_code | char | No | 3 |
| job_quote_unique_line_num | numeric | Yes |  |
| item_code | char | Yes | 12 |
| qty | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.qubr
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| unique_num | numeric | No |  |
| mgr_num | numeric | Yes |  |
| batch_result_type | char | Yes | 4 |
| batch_result_data | char | Yes | 1200 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.reln
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| item_num | char | No | 12 |
| item_date | datetime | Yes |  |
| item_type | char | Yes | 1 |
| item_stat | char | Yes | 1 |
| appl_code | char | Yes | 2 |
| reported_version | char | Yes | 6 |
| target_version | char | Yes | 6 |
| actual_version | char | Yes | 6 |
| reported_by_rep | char | Yes | 3 |
| reported_by_cust | char | Yes | 8 |
| comp_by_rep | char | Yes | 3 |
| comp_by_date | datetime | Yes |  |
| csr_num | char | Yes | 12 |
| svc_bulletin_flag | bit | Yes |  |
| svc_pack_num | char | Yes | 8 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| descr | varchar | Yes | -1 |
| temp_fix_descr | varchar | Yes | -1 |
| perm_fix_descr | varchar | Yes | -1 |
| file_list | varchar | Yes | -1 |
| form_list | varchar | Yes | -1 |

## Table: dbo.rsnc
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| rsn_code | char | No | 3 |
| rsn_code_use | numeric | No |  |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| update_cart_void_code | char | Yes | 1 |
| update_invc_void_code | char | Yes | 1 |
| update_inventory_void_code | char | Yes | 1 |
| update_exec_void_code | char | Yes | 1 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.sanl
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| sales_anl_code | char | No | 3 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.schc
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| seasonal_chrg_table_id | char | No | 3 |
| comp_code | char | No | 4 |
| plant_code | char | No | 3 |
| beg_date | datetime | Yes |  |
| end_date | datetime | Yes |  |
| prod_code | char | Yes | 12 |
| price | numeric | Yes |  |
| price_uom | char | Yes | 5 |
| qty_based_on_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.schd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_date | datetime | No |  |
| order_code | char | No | 12 |
| order_intrnl_line_num | numeric | No |  |
| sched_num | numeric | No |  |
| plant_code | char | Yes | 3 |
| sched_qty | numeric | Yes |  |
| sched_hold_qty | numeric | Yes |  |
| max_qty | numeric | Yes |  |
| sched_adj_code | char | Yes | 1 |
| truck_type | char | Yes | 2 |
| delv_meth_code | char | Yes | 2 |
| load_size | numeric | Yes |  |
| start_time | datetime | Yes |  |
| end_start_time | datetime | Yes |  |
| orig_start_time | datetime | Yes |  |
| distance | numeric | Yes |  |
| distance_uom | char | Yes | 5 |
| load_time | numeric | Yes |  |
| tarp_time | numeric | Yes |  |
| trvl_time | numeric | Yes |  |
| truck_spacing_mins | numeric | Yes |  |
| unld_mins_per_load | numeric | Yes |  |
| qty_per_hour | numeric | Yes |  |
| trucks_req | numeric | Yes |  |
| rate_type | char | Yes | 1 |
| loads | numeric | Yes |  |
| job_washdown_time | numeric | Yes |  |
| last_trvl_time_1 | numeric | Yes |  |
| last_trvl_time_2 | numeric | Yes |  |
| last_trvl_time_3 | numeric | Yes |  |
| last_unld_mins_1 | numeric | Yes |  |
| last_unld_mins_2 | numeric | Yes |  |
| last_unld_mins_3 | numeric | Yes |  |
| stat | char | Yes | 1 |
| remove_rsn_code | char | Yes | 3 |
| exceed_qty_flag | bit | Yes |  |
| plant_fix_meth_code | char | Yes | 2 |
| truck_type_fix_meth_code | char | Yes | 2 |
| truck_fix_meth_code | char | Yes | 2 |
| max_load_size | numeric | Yes |  |
| max_truck_size | numeric | Yes |  |
| max_mins_early | numeric | Yes |  |
| max_mins_late | numeric | Yes |  |
| pour_meth_code | char | Yes | 4 |
| linked_sched_num | numeric | Yes |  |
| linked_sched_delay | numeric | Yes |  |
| priority | numeric | Yes |  |
| hold_last_load_flag | bit | Yes |  |
| setup_mins_per_load | numeric | Yes |  |
| comment_text | char | Yes | 8 |
| to_job_trvl_time | numeric | Yes |  |
| to_plant_trvl_time | numeric | Yes |  |
| unld_rate | numeric | Yes |  |
| to_job_trvl_override_flag | bit | Yes |  |
| to_plant_trvl_override_flag | bit | Yes |  |
| use_sched_load_size_flag | bit | Yes |  |
| exclude_from_ontm_flag | bit | Yes |  |
| job_wait_time | numeric | Yes |  |
| leading_order_code | char | Yes | 12 |
| leading_order_gap | numeric | Yes |  |
| sub_stat | char | Yes | 2 |
| use_sched_load_size_code | char | Yes | 1 |
| truck_capacity_name | char | Yes | 1 |
| remove_round_trip | bit | Yes |  |
| guid | char | Yes | 36 |
| qc_loads | numeric | Yes |  |
| qc_load_mins | numeric | Yes |  |
| qc_load_code | char | Yes | 2 |
| restrict_loads_single_plant | char | Yes | 2 |
| snrty_group_code | char | Yes | 12 |
| schd_1_as_leading_order_code | char | Yes | 2 |
| max_age_of_concrete | numeric | Yes |  |
| exclude_round_trip_delay | char | Yes | 2 |
| do_not_exceed_qty_per_hour | bit | Yes |  |
| add_post_load_time | numeric | Yes |  |
| incomplete_loads_message | char | Yes | 50 |
| pumped_indicator_code | char | Yes | 2 |
| horizontal_reach | numeric | Yes |  |
| vertical_reach | numeric | Yes |  |
| delv_time_zone | char | Yes | 6 |
| add_pre_load_time | numeric | Yes |  |
| round_trip_task_code | char | Yes | 5 |
| post_in_yard_mins | numeric | Yes |  |
| send_ticket_to_batch_system | char | Yes | 2 |
| qc_loads_jobsite | numeric | Yes |  |
| qc_load_mins_jobsite | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| sched_loads | varchar | Yes | 2000 |

## Table: dbo.schg
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| season_chrg_table_id | char | No | 3 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| begin_date | datetime | Yes |  |
| end_date | datetime | Yes |  |
| prod_code | char | Yes | 12 |
| price | numeric | Yes |  |
| price_uom | char | Yes | 5 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.schl
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_date | datetime | No |  |
| order_code | char | No | 12 |
| order_intrnl_line_num | numeric | No |  |
| sched_num | numeric | No |  |
| unique_num | numeric | No |  |
| load_num | numeric | Yes |  |
| tkt_code | char | Yes | 8 |
| truck_code | char | Yes | 10 |
| from_plant_code | char | Yes | 3 |
| to_plant_code | char | Yes | 3 |
| load_size | numeric | Yes |  |
| fixed_time_flag | bit | Yes |  |
| fixed_qty_flag | bit | Yes |  |
| remove_rsn_code | char | Yes | 3 |
| on_job_time | datetime | Yes |  |
| orig_on_job_time | datetime | Yes |  |
| to_job_trvl_time | numeric | Yes |  |
| fixed_to_job_trvl_time_code | char | Yes | 1 |
| to_plant_trvl_time | numeric | Yes |  |
| fixed_to_plant_trvl_time_code | char | Yes | 1 |
| unld_time | numeric | Yes |  |
| fixed_unld_time_code | char | Yes | 1 |
| orig_on_job_time_agree_flag | bit | Yes |  |
| cleanup_flag | bit | Yes |  |
| truck_spacing_mins | numeric | Yes |  |
| fixed_spacing_flag | bit | Yes |  |
| fixed_to_plant_flag | bit | Yes |  |
| travel_time | numeric | Yes |  |
| unload_time | numeric | Yes |  |
| travel_time_update | datetime | Yes |  |
| unload_time_update | datetime | Yes |  |
| assign_truck_code | char | Yes | 10 |
| guid | char | Yes | 36 |
| pump_end_pouring_time | datetime | Yes |  |
| from_pump_schedule_flag | bit | Yes |  |
| on_job_time_design_value | datetime | Yes |  |
| unld_time_design_value | numeric | Yes |  |
| truck_spacing_min_design_value | numeric | Yes |  |
| pump_truck_setup_time | numeric | Yes |  |
| pump_truck_uninstall_time | numeric | Yes |  |
| job_washdown_time | numeric | Yes |  |
| journey_code | char | Yes | 6 |
| journey_seq_code | numeric | Yes |  |
| journey_date | datetime | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.selp
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| form_name | char | No | 8 |
| report_name | char | No | 40 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| field_data_list | varchar | Yes | -1 |

## Table: dbo.sigu
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| signl_unit_code | char | No | 3 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| signl_unit_type | char | Yes | 2 |
| mgr_num | numeric | Yes |  |
| port_num | numeric | Yes |  |
| allow_punch_in_flag | bit | Yes |  |
| allow_punch_out_flag | bit | Yes |  |
| ack_valid_stat_flag | bit | Yes |  |
| ack_invalid_stat_flag | bit | Yes |  |
| allow_text_msg_flag | bit | Yes |  |
| attack_delay_0 | numeric | Yes |  |
| attack_delay_1 | numeric | Yes |  |
| attack_delay_2 | numeric | Yes |  |
| inform_out_msgs_code | bit | Yes |  |
| inform_out_msgs_doc_fmt_code | char | Yes | 8 |
| allow_prod_select_vsc_code | char | Yes | 2 |
| send_truck_ahead_behind_msg | char | Yes | 2 |
| alt_track_map_intf | char | Yes | 40 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| in_msgs_list | varchar | Yes | 1500 |
| out_msgs_list | varchar | Yes | 1500 |
| stat_msgs_list | varchar | Yes | 1500 |
| port_setup | varchar | Yes | 1500 |
| inform_in_msgs_list | varchar | Yes | 1500 |

## Table: dbo.slsc
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| rec_type | char | No | 2 |
| level_1_field_name | char | Yes | 30 |
| level_2_field_name | char | Yes | 30 |
| level_3_field_name | char | Yes | 30 |
| level_4_field_name | char | Yes | 30 |
| level_5_field_name | char | Yes | 30 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.slsd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_date | datetime | No |  |
| order_code | char | No | 12 |
| tkt_code | char | No | 8 |
| unique_num | numeric | No |  |
| tkt_date | datetime | Yes |  |
| prod_line_code | char | Yes | 2 |
| order_type | char | Yes | 1 |
| price_comp_code | char | Yes | 4 |
| price_plant_code | char | Yes | 3 |
| ship_comp_code | char | Yes | 4 |
| ship_plant_code | char | Yes | 3 |
| cust_code | char | Yes | 10 |
| ship_cust_code | char | Yes | 10 |
| ref_cust_code | char | Yes | 10 |
| proj_code | char | Yes | 12 |
| quote_code | char | Yes | 15 |
| zone_code | char | Yes | 8 |
| map_page | char | Yes | 8 |
| hler_code | char | Yes | 8 |
| truck_code | char | Yes | 10 |
| truck_type | char | Yes | 2 |
| driv_empl_code | char | Yes | 12 |
| delv_meth_code | char | Yes | 2 |
| delv_type | char | Yes | 1 |
| slsmn_empl_code | char | Yes | 12 |
| usage_code | char | Yes | 4 |
| sales_anl_code | char | Yes | 3 |
| acct_cat_code | char | Yes | 4 |
| lien_loc_code | char | Yes | 12 |
| delv_addr | char | Yes | 80 |
| item_code | char | Yes | 12 |
| item_type | char | Yes | 2 |
| item_cat | char | Yes | 6 |
| item_used_as_code | char | Yes | 1 |
| delv_qty | numeric | Yes |  |
| delv_qty_uom | char | Yes | 5 |
| price_qty | numeric | Yes |  |
| price_qty_uom | char | Yes | 5 |
| ext_price_amt | numeric | Yes |  |
| ext_matl_cost_amt | numeric | Yes |  |
| haul_amt | numeric | Yes |  |
| haul_cost_amt | numeric | Yes |  |
| assoc_prod_amt | numeric | Yes |  |
| assoc_prod_cost_amt | numeric | Yes |  |
| other_prod_amt | numeric | Yes |  |
| other_prod_cost_amt | numeric | Yes |  |
| fixed_delv_cost_amt | numeric | Yes |  |
| est_var_delv_cost_amt | numeric | Yes |  |
| act_var_delv_cost_amt | numeric | Yes |  |
| ovhd_cost_amt | numeric | Yes |  |
| typed_time | datetime | Yes |  |
| load_time | datetime | Yes |  |
| to_job_time | datetime | Yes |  |
| on_job_time | datetime | Yes |  |
| begin_unld_time | datetime | Yes |  |
| end_unld_time | datetime | Yes |  |
| wash_time | datetime | Yes |  |
| to_plant_time | datetime | Yes |  |
| at_plant_time | datetime | Yes |  |
| yard_mins | numeric | Yes |  |
| load_mins | numeric | Yes |  |
| to_job_mins | numeric | Yes |  |
| on_job_mins | numeric | Yes |  |
| unld_mins | numeric | Yes |  |
| wash_mins | numeric | Yes |  |
| to_plant_mins | numeric | Yes |  |
| deadhead_mins | numeric | Yes |  |
| round_trip_mins | numeric | Yes |  |
| sched_start_time | datetime | Yes |  |
| sched_orig_start_time | datetime | Yes |  |
| sched_distance | numeric | Yes |  |
| sched_distance_uom | char | Yes | 5 |
| sched_load_time | numeric | Yes |  |
| sched_job_washdown_time | numeric | Yes |  |
| sched_tarp_time | numeric | Yes |  |
| sched_trvl_time | numeric | Yes |  |
| sched_truck_spacing_mins | numeric | Yes |  |
| sched_unld_mins_per_load | numeric | Yes |  |
| sched_qty_per_hour | numeric | Yes |  |
| sched_trucks_req | numeric | Yes |  |
| sched_rate_type | char | Yes | 1 |
| truck_assgn_plant_code | char | Yes | 3 |
| driv_assgn_plant_code | char | Yes | 3 |
| plant_load_mins | numeric | Yes |  |
| pmt_meth | char | Yes | 1 |
| quote_rev_num | char | Yes | 3 |
| rtt_ordr | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.slsp
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| acctng_year | numeric | No |  |
| acctng_perds | numeric | Yes |  |
| perd_begin_date_01 | datetime | Yes |  |
| perd_begin_date_02 | datetime | Yes |  |
| perd_begin_date_03 | datetime | Yes |  |
| perd_begin_date_04 | datetime | Yes |  |
| perd_begin_date_05 | datetime | Yes |  |
| perd_begin_date_06 | datetime | Yes |  |
| perd_begin_date_07 | datetime | Yes |  |
| perd_begin_date_08 | datetime | Yes |  |
| perd_begin_date_09 | datetime | Yes |  |
| perd_begin_date_10 | datetime | Yes |  |
| perd_begin_date_11 | datetime | Yes |  |
| perd_begin_date_12 | datetime | Yes |  |
| perd_begin_date_13 | datetime | Yes |  |
| perd_end_date_01 | datetime | Yes |  |
| perd_end_date_02 | datetime | Yes |  |
| perd_end_date_03 | datetime | Yes |  |
| perd_end_date_04 | datetime | Yes |  |
| perd_end_date_05 | datetime | Yes |  |
| perd_end_date_06 | datetime | Yes |  |
| perd_end_date_07 | datetime | Yes |  |
| perd_end_date_08 | datetime | Yes |  |
| perd_end_date_09 | datetime | Yes |  |
| perd_end_date_10 | datetime | Yes |  |
| perd_end_date_11 | datetime | Yes |  |
| perd_end_date_12 | datetime | Yes |  |
| perd_end_date_13 | datetime | Yes |  |
| perd_open_01 | bit | Yes |  |
| perd_open_02 | bit | Yes |  |
| perd_open_03 | bit | Yes |  |
| perd_open_04 | bit | Yes |  |
| perd_open_05 | bit | Yes |  |
| perd_open_06 | bit | Yes |  |
| perd_open_07 | bit | Yes |  |
| perd_open_08 | bit | Yes |  |
| perd_open_09 | bit | Yes |  |
| perd_open_10 | bit | Yes |  |
| perd_open_11 | bit | Yes |  |
| perd_open_12 | bit | Yes |  |
| perd_open_13 | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.slss
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| unique_num | numeric | No |  |
| rec_type | char | No | 2 |
| date_thru | datetime | Yes |  |
| date_from | datetime | Yes |  |
| prod_line_code | char | Yes | 2 |
| order_type | char | Yes | 1 |
| price_comp_code | char | Yes | 4 |
| price_plant_code | char | Yes | 3 |
| ship_comp_code | char | Yes | 4 |
| ship_plant_code | char | Yes | 3 |
| cust_code | char | Yes | 10 |
| ship_cust_code | char | Yes | 10 |
| ref_cust_code | char | Yes | 10 |
| proj_code | char | Yes | 12 |
| quote_code | char | Yes | 15 |
| zone_code | char | Yes | 8 |
| map_page | char | Yes | 8 |
| hler_code | char | Yes | 8 |
| truck_code | char | Yes | 10 |
| truck_type | char | Yes | 2 |
| driv_empl_code | char | Yes | 12 |
| delv_meth_code | char | Yes | 2 |
| delv_type | char | Yes | 1 |
| slsmn_empl_code | char | Yes | 12 |
| usage_code | char | Yes | 4 |
| sales_anl_code | char | Yes | 3 |
| acct_cat_code | char | Yes | 4 |
| lien_loc_code | char | Yes | 12 |
| delv_addr | char | Yes | 80 |
| item_code | char | Yes | 12 |
| item_cat | char | Yes | 6 |
| item_type | char | Yes | 2 |
| item_used_as_code | char | Yes | 1 |
| loads | numeric | Yes |  |
| prim_price_qty | numeric | Yes |  |
| prim_price_qty_uom | char | Yes | 5 |
| prim_delv_qty | numeric | Yes |  |
| prim_delv_qty_uom | char | Yes | 5 |
| delv_qty | numeric | Yes |  |
| delv_qty_uom | char | Yes | 5 |
| price_qty | numeric | Yes |  |
| price_qty_uom | char | Yes | 5 |
| prim_sales_amt | numeric | Yes |  |
| prim_cost_amt | numeric | Yes |  |
| prim_assoc_prod_sales_amt | numeric | Yes |  |
| prim_assoc_prod_cost_amt | numeric | Yes |  |
| prim_haul_amt | numeric | Yes |  |
| prim_haul_cost_amt | numeric | Yes |  |
| prim_other_prod_sales_amt | numeric | Yes |  |
| prim_other_prod_cost_amt | numeric | Yes |  |
| assoc_prod_sales_amt | numeric | Yes |  |
| assoc_prod_cost_amt | numeric | Yes |  |
| haul_sales_amt | numeric | Yes |  |
| haul_cost_amt | numeric | Yes |  |
| other_prod_sales_amt | numeric | Yes |  |
| other_prod_cost_amt | numeric | Yes |  |
| fixed_delv_cost_amt | numeric | Yes |  |
| est_var_delv_cost_amt | numeric | Yes |  |
| act_var_delv_cost_amt | numeric | Yes |  |
| ovhd_cost_amt | numeric | Yes |  |
| round_trip_mins | numeric | Yes |  |
| truck_assgn_plant_code | char | Yes | 3 |
| driv_assgn_plant_code | char | Yes | 3 |
| pmt_meth | char | Yes | 1 |
| quote_rev_num | char | Yes | 3 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.slst
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| unique_num | numeric | No |  |
| rec_type | char | No | 2 |
| order_date | datetime | Yes |  |
| prod_line_code | char | Yes | 2 |
| truck_code | char | Yes | 10 |
| driv_empl_code | char | Yes | 12 |
| cust_code | char | Yes | 10 |
| ship_cust_code | char | Yes | 10 |
| ref_cust_code | char | Yes | 10 |
| proj_code | char | Yes | 12 |
| ship_plant_code | char | Yes | 3 |
| prim_order_qty | numeric | Yes |  |
| prim_order_qty_uom | char | Yes | 5 |
| prim_delv_qty | numeric | Yes |  |
| prim_delv_qty_uom | char | Yes | 5 |
| loads | numeric | Yes |  |
| yard_mins | numeric | Yes |  |
| load_mins | numeric | Yes |  |
| to_job_mins | numeric | Yes |  |
| on_job_mins | numeric | Yes |  |
| unld_mins | numeric | Yes |  |
| wash_mins | numeric | Yes |  |
| to_plant_mins | numeric | Yes |  |
| deadhead_mins | numeric | Yes |  |
| round_trip_mins | numeric | Yes |  |
| driv_clock_mins | numeric | Yes |  |
| truck_clock_mins | numeric | Yes |  |
| driv_break_mins | numeric | Yes |  |
| driv_next_tkt_mins | numeric | Yes |  |
| driv_strtup_mins | numeric | Yes |  |
| driv_shutdn_mins | numeric | Yes |  |
| truck_assgn_plant_code | char | Yes | 3 |
| driv_assgn_plant_code | char | Yes | 3 |
| plant_load_mins | numeric | Yes |  |
| job_wash_mins | numeric | Yes |  |
| rtt_ordr | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.srcd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| src_code | char | No | 2 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| force_batch_bal | bit | Yes |  |
| qty_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.stol
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_code | char | No | 12 |
| order_intrnl_line_num | numeric | No |  |
| sort_line_num | numeric | Yes |  |
| prod_code | char | Yes | 12 |
| prod_descr | char | Yes | 40 |
| short_prod_descr | char | Yes | 16 |
| prod_cat | char | Yes | 6 |
| price | numeric | Yes |  |
| cstmry_price | numeric | Yes |  |
| metric_price | numeric | Yes |  |
| price_uom | char | Yes | 5 |
| cstmry_price_uom | char | Yes | 5 |
| metric_price_uom | char | Yes | 5 |
| price_derived_from_code | char | Yes | 2 |
| price_ext_code | char | Yes | 1 |
| price_qty | numeric | Yes |  |
| delv_price_flag | bit | Yes |  |
| dflt_load_qty | numeric | Yes |  |
| cstmry_dflt_load_qty | numeric | Yes |  |
| metric_dflt_load_qty | numeric | Yes |  |
| dflt_load_qty_uom | char | Yes | 5 |
| order_qty_ext_code | char | Yes | 1 |
| order_dosage_qty | numeric | Yes |  |
| cstmry_order_dosage_qty | numeric | Yes |  |
| metric_order_dosage_qty | numeric | Yes |  |
| order_dosage_qty_uom | char | Yes | 5 |
| cstmry_order_dosage_qty_uom | char | Yes | 5 |
| metric_order_dosage_qty_uom | char | Yes | 5 |
| price_qty_ext_code | char | Yes | 1 |
| tkt_qty_ext_code | char | Yes | 1 |
| cred_price_adj_flag | bit | Yes |  |
| cred_cost_adj_flag | bit | Yes |  |
| order_qty | numeric | Yes |  |
| cstmry_order_qty | numeric | Yes |  |
| metric_order_qty | numeric | Yes |  |
| order_qty_uom | char | Yes | 5 |
| cstmry_order_qty_uom | char | Yes | 5 |
| metric_order_qty_uom | char | Yes | 5 |
| orig_order_qty | numeric | Yes |  |
| cstmry_orig_order_qty | numeric | Yes |  |
| metric_orig_order_qty | numeric | Yes |  |
| delv_qty | numeric | Yes |  |
| cstmry_delv_qty | numeric | Yes |  |
| metric_delv_qty | numeric | Yes |  |
| delv_qty_uom | char | Yes | 5 |
| cstmry_delv_qty_uom | char | Yes | 5 |
| metric_delv_qty_uom | char | Yes | 5 |
| delv_to_date_qty | numeric | Yes |  |
| cstmry_delv_to_date_qty | numeric | Yes |  |
| metric_delv_to_date_qty | numeric | Yes |  |
| rm_slump | char | Yes | 8 |
| rm_slump_uom | char | Yes | 5 |
| rm_mix_flag | bit | Yes |  |
| comment_text | char | Yes | 40 |
| usage_code | char | Yes | 4 |
| taxble_code | numeric | Yes |  |
| non_tax_rsn_code | char | Yes | 3 |
| invc_flag | bit | Yes |  |
| sep_invc_flag | bit | Yes |  |
| remove_rsn_code | char | Yes | 3 |
| proj_line_num | numeric | Yes |  |
| cust_line_num | numeric | Yes |  |
| curr_load_num | numeric | Yes |  |
| quote_code | char | Yes | 15 |
| am_min_temp | numeric | Yes |  |
| moved_order_date | datetime | Yes |  |
| moved_to_order_code | char | Yes | 12 |
| moved_from_order_code | char | Yes | 12 |
| invy_adjust_code | char | Yes | 1 |
| sales_anl_adjust_code | char | Yes | 1 |
| mix_design_user_name | char | Yes | 20 |
| mix_design_update_date | datetime | Yes |  |
| qc_approvl_flag | bit | Yes |  |
| qc_approvl_date | datetime | Yes |  |
| batch_code | char | Yes | 12 |
| chrg_cart_code | char | Yes | 3 |
| cart_rate_amt | numeric | Yes |  |
| linked_prod_seq_num | numeric | Yes |  |
| linked_prod_time_gap | numeric | Yes |  |
| cart_cat | char | Yes | 6 |
| pumped_indicator_code | char | Yes | 2 |
| quote_rev_num | char | Yes | 3 |
| record_origin_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| type_price | char | Yes | 1 |
| u_version | char | Yes | 1 |
| cart_plant_codes | varchar | Yes | -1 |
| cart_truck_types | varchar | Yes | -1 |
| cart_rates | varchar | Yes | -1 |
| sur_codes | varchar | Yes | -1 |
| sur_rate_amts | varchar | Yes | -1 |
| apply_sur_rate_hler_flags | varchar | Yes | -1 |
| sundry_chrg_table_ids | varchar | Yes | -1 |
| sundry_chrg_sep_invc_flags | varchar | Yes | -1 |
| apply_sundry_chrg_flags | varchar | Yes | -1 |
| lot_num_list | varchar | Yes | -1 |

## Table: dbo.stor
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_code | char | No | 12 |
| order_type | char | Yes | 1 |
| prod_line_code | char | Yes | 2 |
| stat | char | Yes | 1 |
| cust_code | char | Yes | 10 |
| ship_cust_code | char | Yes | 10 |
| ref_cust_code | char | Yes | 10 |
| cust_name | char | Yes | 40 |
| cust_sort_name | char | Yes | 8 |
| proj_code | char | Yes | 12 |
| zone_code | char | Yes | 8 |
| lot_block | char | Yes | 10 |
| cust_job_num | char | Yes | 24 |
| po | char | Yes | 24 |
| taken_by_empl_code | char | Yes | 12 |
| taken_on_phone_line_num | numeric | Yes |  |
| order_by_name | char | Yes | 40 |
| order_by_phone_num | char | Yes | 14 |
| apply_min_load_chrg_flag | bit | Yes |  |
| apply_zone_chrg_flag | bit | Yes |  |
| apply_excess_unld_chrg_flag | bit | Yes |  |
| apply_season_chrg_flag | bit | Yes |  |
| apply_min_haul_pay_flag | bit | Yes |  |
| rm_print_mix_wgts_flag | bit | Yes |  |
| price_plant_code | char | Yes | 3 |
| price_plant_loc_code | char | Yes | 4 |
| comp_code | char | Yes | 4 |
| hler_code | char | Yes | 8 |
| min_load_chrg_table_id | char | Yes | 3 |
| excess_unld_chrg_table_id | char | Yes | 3 |
| season_chrg_table_id | char | Yes | 3 |
| min_load_sep_invc_flag | bit | Yes |  |
| excess_unld_sep_invc_flag | bit | Yes |  |
| season_sep_invc_flag | bit | Yes |  |
| sales_anl_code | char | Yes | 3 |
| slsmn_empl_code | char | Yes | 12 |
| taxble_code | numeric | Yes |  |
| tax_code | char | Yes | 3 |
| non_tax_rsn_code | char | Yes | 3 |
| susp_rsn_code | char | Yes | 3 |
| susp_user_name | char | Yes | 20 |
| susp_date_time | datetime | Yes |  |
| susp_cancel_date_time | datetime | Yes |  |
| susp_cancel_user_name | char | Yes | 20 |
| remove_rsn_code | char | Yes | 3 |
| memo_rsn_code | char | Yes | 3 |
| pkt_num | char | Yes | 3 |
| track_order_color | numeric | Yes |  |
| intrnl_line_num | numeric | Yes |  |
| curr_load_num | numeric | Yes |  |
| cod_order_amt | numeric | Yes |  |
| invc_code | char | Yes | 12 |
| setup_date | datetime | Yes |  |
| quote_code | char | Yes | 15 |
| map_page | char | Yes | 8 |
| cred_over_user_name | char | Yes | 20 |
| cred_over_auth_code | char | Yes | 12 |
| cred_limtn_code | char | Yes | 3 |
| est_order_amt | numeric | Yes |  |
| delv_meth_code | char | Yes | 2 |
| expir_date | datetime | Yes |  |
| exceed_qty_flag | bit | Yes |  |
| clear_daily_flag | bit | Yes |  |
| cart_code | char | Yes | 3 |
| cart_rate_amt | numeric | Yes |  |
| apply_cart_rate_hler_flag | bit | Yes |  |
| apply_min_haul_flag | bit | Yes |  |
| map_long | char | Yes | 9 |
| map_lat | char | Yes | 9 |
| map_radius | numeric | Yes |  |
| alt_scale_printer_flag | bit | Yes |  |
| metric_cstmry_code | char | Yes | 1 |
| invy_adjust_code | char | Yes | 1 |
| sales_anl_adjust_code | char | Yes | 1 |
| mix_design_user_name | char | Yes | 20 |
| mix_design_update_date | datetime | Yes |  |
| qc_approvl_flag | bit | Yes |  |
| qc_approvl_date | datetime | Yes |  |
| job_phase | char | Yes | 12 |
| start_time | datetime | Yes |  |
| scale_use_order_flag | bit | Yes |  |
| job_code | char | Yes | 16 |
| phase_code | char | Yes | 16 |
| ship_to_plant_code | char | Yes | 3 |
| pmt_acct_bank_name | char | Yes | 40 |
| pmt_acct_check_num | char | Yes | 20 |
| pmt_acct_exp_date | char | Yes | 10 |
| pmt_acct_name | char | Yes | 40 |
| pmt_amt | numeric | Yes |  |
| pmt_auth_code | char | Yes | 16 |
| pmt_meth | char | Yes | 1 |
| pmt_check_num | char | Yes | 12 |
| pmt_acct_num | char | Yes | 20 |
| contact_code | char | Yes | 8 |
| ship_addr_line | char | Yes | 40 |
| ship_city | char | Yes | 40 |
| ship_state | char | Yes | 10 |
| ship_cntry | char | Yes | 3 |
| ship_postcd | char | Yes | 10 |
| pay_cart_code | char | Yes | 3 |
| pay_cart_rate_amt | numeric | Yes |  |
| quote_rev_num | char | Yes | 3 |
| priority | numeric | Yes |  |
| tax_exempt_profile_code | char | Yes | 3 |
| time_offset_available | bit | Yes |  |
| sampling_lab_code | char | Yes | 10 |
| ship_addr_line_num | char | Yes | 10 |
| ship_addr_line_name | char | Yes | 30 |
| ship_addr_city_code | char | Yes | 10 |
| modified_date | datetime | Yes |  |
| dataout_date | datetime | Yes |  |
| pmt_form_code | char | Yes | 8 |
| pbl_zone_code | char | Yes | 8 |
| map_updt_ordr_coord_flag | bit | Yes |  |
| map_truck_poll_type | numeric | Yes |  |
| first_truck_polled_flag | bit | Yes |  |
| tax_ref_postcd | char | Yes | 10 |
| notf_email_addr | char | Yes | 256 |
| email_addr_mobile | char | Yes | 256 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| delv_addr | varchar | Yes | -1 |
| instr | varchar | Yes | -1 |
| user_defined | varchar | Yes | -1 |
| sur_codes | varchar | Yes | -1 |
| sur_rate_amts | varchar | Yes | -1 |
| apply_sur_rate_hler_flags | varchar | Yes | -1 |
| sundry_chrg_table_ids | varchar | Yes | -1 |
| apply_sundry_chrg_flags | varchar | Yes | -1 |
| sundry_chrg_sep_invc_flags | varchar | Yes | -1 |
| order_msgs | varchar | Yes | -1 |
| apply_pump_unld_chrg_flag | varchar | Yes | -1 |
| pump_unld_chrg_table_id | varchar | Yes | -1 |
| apply_pump_sundry_chrg_flags | varchar | Yes | -1 |
| sundry_chrg_comb_meth_code | varchar | Yes | -1 |
| sundry_chrg_override_rates | varchar | Yes | -1 |
| pump_sundry_chrg_over_rates | varchar | Yes | -1 |

## Table: dbo.stxd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| batch_date | datetime | No |  |
| batch_num | numeric | No |  |
| batch_seq | numeric | No |  |
| trans_type | numeric | No |  |
| unique_num | numeric | No |  |
| cust_code | char | No | 10 |
| item_ref_code | char | Yes | 12 |
| sort_name | char | Yes | 8 |
| comp_code | char | Yes | 4 |
| price_plant_code | char | Yes | 3 |
| invc_code | char | Yes | 12 |
| tax_auth | char | Yes | 4 |
| tax_loc | char | Yes | 8 |
| non_tax_rsn_code | char | Yes | 3 |
| taxble_amt | numeric | Yes |  |
| non_taxble_amt | numeric | Yes |  |
| tax_amt | numeric | Yes |  |
| taxble_tax_amt | numeric | Yes |  |
| tax_on_disc_amt | numeric | Yes |  |
| tax_on_disc_taxble_amt | numeric | Yes |  |
| from_to_flag | char | Yes | 1 |
| trans_date | datetime | Yes |  |
| pmt_date | datetime | Yes |  |
| post_stat | char | Yes | 1 |
| ship_plant_code | char | Yes | 3 |
| proj_code | char | Yes | 12 |
| tax_reduction_profile_code | char | Yes | 3 |
| tax_red_percent | numeric | Yes |  |
| tax_red_amt | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.stxd_1
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| user_name | char | No | 20 |
| unique_num | numeric | No |  |
| cust_code | char | Yes | 10 |
| invc_code | char | Yes | 12 |
| item_ref_code | char | Yes | 12 |
| sort_name | char | Yes | 8 |
| comp_code | char | Yes | 4 |
| price_plant_code | char | Yes | 3 |
| tax_auth | char | Yes | 4 |
| tax_loc | char | Yes | 8 |
| non_tax_rsn_code | char | Yes | 3 |
| taxble_amt | numeric | Yes |  |
| non_taxble_amt | numeric | Yes |  |
| tax_amt | numeric | Yes |  |
| taxble_tax_amt | numeric | Yes |  |
| tax_on_disc_amt | numeric | Yes |  |
| tax_on_disc_taxble_amt | numeric | Yes |  |
| taxble_adj_amt | numeric | Yes |  |
| non_taxble_adj_amt | numeric | Yes |  |
| tax_adj_amt | numeric | Yes |  |
| from_to_flag | char | Yes | 1 |
| trans_date | datetime | Yes |  |
| batch_date | datetime | Yes |  |
| batch_num | numeric | Yes |  |
| trans_type | char | Yes | 2 |
| batch_seq | numeric | Yes |  |
| post_stat | char | Yes | 1 |
| ship_plant_code | char | Yes | 3 |
| proj_code | char | Yes | 12 |
| tax_reduction_profile_code | char | Yes | 3 |
| tax_red_percent | numeric | Yes |  |
| tax_red_amt | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.syst
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| unique_num | numeric | No |  |
| cust_code | char | No | 15 |
| cust_loc | char | No | 3 |
| rev_no | numeric | No |  |
| client | char | Yes | 40 |
| record_type | char | Yes | 8 |
| appl_type | char | Yes | 3 |
| truck_count | numeric | Yes |  |
| annl_load_count | numeric | Yes |  |
| intfc_type | char | Yes | 2 |
| intfc_count | numeric | Yes |  |
| service_operation_code | char | Yes | 4 |
| temp_license_flag | bit | Yes |  |
| temp_license_date | datetime | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.taxa
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| tax_auth | char | No | 4 |
| descr | char | No | 40 |
| prompt | char | Yes | 8 |
| tax_level | numeric | Yes |  |
| orig_dest_code | char | Yes | 1 |
| rcprcl_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.taxc
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| tax_code | char | No | 3 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.taxj
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| tax_code | char | No | 3 |
| tax_auth | char | No | 4 |
| tax_loc | char | No | 8 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.taxl
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| tax_auth | char | No | 4 |
| tax_loc | char | No | 8 |
| descr | char | No | 40 |
| exmpt_delv_flag | bit | Yes |  |
| exmpt_delv_type | char | Yes | 1 |
| exmpt_delv_rate | numeric | Yes |  |
| exmpt_delv_uom | char | Yes | 5 |
| tax_disc_flag | bit | Yes |  |
| prim_rate_curr_pct | numeric | Yes |  |
| prim_rate_effect_date | datetime | Yes |  |
| prim_rate_prev_pct | numeric | Yes |  |
| secondary_rate_curr_pct | numeric | Yes |  |
| secondary_rate_effect_date | datetime | Yes |  |
| secondary_rate_prev_pct | numeric | Yes |  |
| short_descr | char | Yes | 8 |
| exmpt_non_tax_rsn_code | char | Yes | 3 |
| max_tax_amt | numeric | Yes |  |
| max_tax_non_tax_rsn_code | char | Yes | 3 |
| max_tax_rate | numeric | Yes |  |
| override_rcprcl_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.tcnd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| condition_code | char | No | 5 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| est_mins | numeric | Yes |  |
| est_type | char | Yes | 1 |
| condition_color | numeric | Yes |  |
| condition_flag_code | char | Yes | 1 |
| condition_priority | numeric | Yes |  |
| dot_condition_flag | bit | Yes |  |
| reserved_condition_flag | bit | Yes |  |
| no_est_flag | bit | Yes |  |
| user_condition_code | char | Yes | 1 |
| msg_code | char | Yes | 3 |
| avail_for_sched_code | char | Yes | 1 |
| mandatory_flag | bit | Yes |  |
| auto_end_flag | bit | Yes |  |
| audit_flag | bit | Yes |  |
| persist_condition_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.text
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| lang | char | No | 3 |
| text_type | char | No | 1 |
| text_item | char | No | 32 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| text_line | varchar | Yes | -1 |

## Table: dbo.tick
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_date | datetime | No |  |
| order_code | char | No | 12 |
| tkt_code | char | No | 8 |
| tkt_date | datetime | Yes |  |
| apply_min_load_chrg_flag | bit | Yes |  |
| apply_zone_chrg_flag | bit | Yes |  |
| apply_excess_unld_chrg_flag | bit | Yes |  |
| apply_season_chrg_flag | bit | Yes |  |
| apply_min_haul_flag | bit | Yes |  |
| driv_empl_code | char | Yes | 12 |
| hler_code | char | Yes | 8 |
| lot_block | char | Yes | 10 |
| min_load_chrg_table_id | char | Yes | 3 |
| excess_unld_chrg_table_id | char | Yes | 3 |
| season_chrg_table_id | char | Yes | 3 |
| po | char | Yes | 24 |
| rm_print_mix_wgts_flag | bit | Yes |  |
| rm_water_added_on_job | numeric | Yes |  |
| ship_plant_code | char | Yes | 3 |
| ship_plant_loc_code | char | Yes | 4 |
| scale_code | char | Yes | 3 |
| truck_code | char | Yes | 10 |
| truck_type | char | Yes | 2 |
| delv_meth_code | char | Yes | 2 |
| weigh_master_empl_code | char | Yes | 12 |
| remove_rsn_code | char | Yes | 3 |
| cod_amt | numeric | Yes |  |
| cod_order_amt | numeric | Yes |  |
| cod_prev_order_amt | numeric | Yes |  |
| cod_cash_recvd_amt | numeric | Yes |  |
| cod_cash_recvd_text | char | Yes | 40 |
| disc_amt | numeric | Yes |  |
| disc_tax_amt | numeric | Yes |  |
| intfc_flag | bit | Yes |  |
| invc_flag | bit | Yes |  |
| invc_code | char | Yes | 12 |
| invc_date | datetime | Yes |  |
| invc_seq_num | numeric | Yes |  |
| load_num | numeric | Yes |  |
| tax_code | char | Yes | 3 |
| rm_mix_order_intrnl_line_num | numeric | Yes |  |
| sched_num | numeric | Yes |  |
| sched_load_time | datetime | Yes |  |
| susp_rsn_code | char | Yes | 3 |
| susp_user_name | char | Yes | 20 |
| susp_date_time | datetime | Yes |  |
| susp_cancel_date_time | datetime | Yes |  |
| susp_cancel_user_name | char | Yes | 20 |
| typed_time | datetime | Yes |  |
| load_time | datetime | Yes |  |
| loaded_time | datetime | Yes |  |
| to_job_time | datetime | Yes |  |
| on_job_time | datetime | Yes |  |
| begin_unld_time | datetime | Yes |  |
| begin_unld_time_print | char | Yes | 8 |
| end_unld_time | datetime | Yes |  |
| wash_time | datetime | Yes |  |
| to_plant_time | datetime | Yes |  |
| at_plant_time | datetime | Yes |  |
| distance | numeric | Yes |  |
| post_trvl_time | numeric | Yes |  |
| post_trvl_flag | bit | Yes |  |
| map_long | char | Yes | 9 |
| map_lat | char | Yes | 9 |
| map_radius | numeric | Yes |  |
| truck_intrnl_line_num | numeric | Yes |  |
| truck_tare_wgt | numeric | Yes |  |
| truck_tare_wgt_uom | char | Yes | 5 |
| truck_net_wgt | numeric | Yes |  |
| truck_gross_wgt | numeric | Yes |  |
| truck_gross_wgt_uom | char | Yes | 5 |
| prim_trlr_code | char | Yes | 10 |
| prim_trlr_intrnl_line_num | numeric | Yes |  |
| prim_trlr_tare_wgt | numeric | Yes |  |
| prim_trlr_tare_wgt_uom | char | Yes | 5 |
| prim_trlr_net_wgt | numeric | Yes |  |
| prim_trlr_net_wgt_uom | char | Yes | 5 |
| prim_trlr_gross_wgt | numeric | Yes |  |
| prim_trlr_gross_wgt_uom | char | Yes | 5 |
| truck_net_wgt_uom | char | Yes | 5 |
| scndry_trlr_code | char | Yes | 10 |
| scndry_trlr_intrnl_line_num | numeric | Yes |  |
| scndry_trlr_tare_wgt | numeric | Yes |  |
| scndry_trlr_tare_wgt_uom | char | Yes | 5 |
| scndry_trlr_net_wgt | numeric | Yes |  |
| scndry_trlr_net_wgt_uom | char | Yes | 5 |
| scndry_trlr_gross_wgt | numeric | Yes |  |
| scndry_trlr_gross_wgt_uom | char | Yes | 5 |
| man_wgt_flag | bit | Yes |  |
| wgts_meth_code | char | Yes | 1 |
| reused_order_date | datetime | Yes |  |
| reused_order_code | char | Yes | 12 |
| alley_code | char | Yes | 3 |
| truck_assgn_flag | bit | Yes |  |
| job_phase | char | Yes | 12 |
| qc_stat | char | Yes | 2 |
| job_code | char | Yes | 16 |
| phase_code | char | Yes | 16 |
| pmt_amt | numeric | Yes |  |
| ship_to_plant_code | char | Yes | 3 |
| pmt_meth | char | Yes | 1 |
| modified_date | datetime | Yes |  |
| dataout_date | datetime | Yes |  |
| tkt_code_alt | char | Yes | 8 |
| pmt_form_code | char | Yes | 8 |
| opt_dataout_date | datetime | Yes |  |
| inventory_post_stat | char | Yes | 2 |
| tkt_status | char | Yes | 1 |
| tkt_user_name | char | Yes | 20 |
| exclude_from_ontm_flag | bit | Yes |  |
| ml_load_num | numeric | Yes |  |
| batch_unit_actl_mix_load_size | numeric | Yes |  |
| batch_unit_actl_batch_code | char | Yes | 12 |
| batch_in_tolerance_flag | bit | Yes |  |
| batch_actual_truck | char | Yes | 10 |
| batch_actual_batch_time | datetime | Yes |  |
| conc_max_gross_wgt | numeric | Yes |  |
| conc_max_gross_wgt_uom | char | Yes | 5 |
| pbl_zone_code | char | Yes | 8 |
| bill_lading_code | char | Yes | 16 |
| control_num | char | Yes | 20 |
| src_code | char | Yes | 2 |
| suggested_truck_code | char | Yes | 10 |
| suggested_ticketing_time | datetime | Yes |  |
| tax_source | char | Yes | 2 |
| guid | char | Yes | 36 |
| temperature | numeric | Yes |  |
| temperature_uom | char | Yes | 5 |
| humidity | numeric | Yes |  |
| windspeed | numeric | Yes |  |
| windspeed_uom | char | Yes | 5 |
| observation_time | datetime | Yes |  |
| truck_to_plant_code | char | Yes | 3 |
| silo_id | char | Yes | 3 |
| remove_user_name | char | Yes | 20 |
| remove_date_time | datetime | Yes |  |
| suggested_ship_plant_code | char | Yes | 3 |
| auth_code | char | Yes | 40 |
| fiscal_note_ref_code | char | Yes | 60 |
| qc_load | char | Yes | 2 |
| sampled_flag | bit | Yes |  |
| cancel_rsn_code | char | Yes | 3 |
| cancel_date_time | datetime | Yes |  |
| cancel_user_name | char | Yes | 20 |
| fiscal_note_icms_rule_num | numeric | Yes |  |
| fiscal_note_icms_tax_pct | numeric | Yes |  |
| fiscal_note_icms_tax_amt | numeric | Yes |  |
| fiscal_note_freight_amt | numeric | Yes |  |
| fiscal_note_pretax_amt | numeric | Yes |  |
| fiscal_note_tax_amt | numeric | Yes |  |
| lic_num | char | Yes | 10 |
| lic_expir_date | datetime | Yes |  |
| lic_state | char | Yes | 10 |
| fiscal_note_response_stat | char | Yes | 10 |
| fiscal_note_response_message | char | Yes | 100 |
| fiscal_note_cancel_stat | char | Yes | 10 |
| fiscal_note_cancel_message | char | Yes | 100 |
| mobileticket_status | char | Yes | 2 |
| target_preload_mins | numeric | Yes |  |
| tkt_stack_failure_message | char | Yes | 100 |
| truck_seal | char | Yes | 50 |
| state_job_code | char | Yes | 32 |
| fully_mixed_time | datetime | Yes |  |
| journey_code | char | Yes | 6 |
| journey_seq_code | numeric | Yes |  |
| journey_date | datetime | Yes |  |
| disp_min_load_msg_flag | bit | Yes |  |
| min_load_chrg_zero_rsn_code | char | Yes | 3 |
| season_chrg_zero_rsn_code | char | Yes | 3 |
| unld_chrg_zero_rsn_code | char | Yes | 3 |
| min_load_chrg_zero_user_name | char | Yes | 20 |
| season_chrg_zero_user_name | char | Yes | 20 |
| unld_chrg_zero_user_name | char | Yes | 20 |
| notf_email_addr | char | Yes | 256 |
| mobileticket_code | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| delv_addr | varchar | Yes | -1 |
| instr | varchar | Yes | -1 |
| user_defined | varchar | Yes | -1 |
| apply_sundry_chrg_flags | varchar | Yes | -1 |
| apply_pump_unld_chrg_flag | varchar | Yes | -1 |
| pump_unld_chrg_table_id | varchar | Yes | -1 |
| pump_sundry_chrg_table_ids | varchar | Yes | -1 |
| apply_pump_sundry_chrg_flags | varchar | Yes | -1 |
| sundry_chrg_zero_user_name | varchar | Yes | -1 |
| sundry_chrg_zero_rsn_code | varchar | Yes | -1 |

## Table: dbo.tkst
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_date | datetime | No |  |
| order_code | char | No | 12 |
| tkt_code | char | No | 8 |
| unique_num | numeric | No |  |
| status | numeric | Yes |  |
| status_time | datetime | Yes |  |
| status_source | char | Yes | 2 |
| status_user_name | char | Yes | 20 |
| calling_component_name | char | Yes | 32 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.tktc
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_date | datetime | No |  |
| order_code | char | No | 12 |
| tkt_code | char | No | 8 |
| tkt_chrg_intrnl_line_num | numeric | No |  |
| tkt_chrg_code | char | Yes | 2 |
| sundry_chrg_table_id | char | Yes | 3 |
| unld_chrg_table_id | char | Yes | 3 |
| prod_code | char | Yes | 12 |
| prod_descr | char | Yes | 40 |
| short_prod_descr | char | Yes | 16 |
| prod_cat | char | Yes | 6 |
| price | numeric | Yes |  |
| cstmry_price | numeric | Yes |  |
| metric_price | numeric | Yes |  |
| price_uom | char | Yes | 5 |
| cstmry_price_uom | char | Yes | 5 |
| metric_price_uom | char | Yes | 5 |
| price_derived_from_code | char | Yes | 2 |
| price_ext_code | char | Yes | 1 |
| taxble_code | numeric | Yes |  |
| non_tax_rsn_code | char | Yes | 3 |
| delv_qty | numeric | Yes |  |
| cstmry_delv_qty | numeric | Yes |  |
| metric_delv_qty | numeric | Yes |  |
| delv_qty_uom | char | Yes | 5 |
| cstmry_delv_qty_uom | char | Yes | 5 |
| metric_delv_qty_uom | char | Yes | 5 |
| ext_price_amt | numeric | Yes |  |
| price_qty | numeric | Yes |  |
| cstmry_price_qty | numeric | Yes |  |
| metric_price_qty | numeric | Yes |  |
| cost | numeric | Yes |  |
| cost_uom | char | Yes | 5 |
| cstmry_cost | numeric | Yes |  |
| metric_cost | numeric | Yes |  |
| cost_ext_code | char | Yes | 1 |
| ext_matl_cost_amt | numeric | Yes |  |
| moved_order_date | datetime | Yes |  |
| moved_to_order_code | char | Yes | 12 |
| moved_from_order_code | char | Yes | 12 |
| delv_price_flag | bit | Yes |  |
| comb_meth_code | char | Yes | 1 |
| usage_code | char | Yes | 4 |
| order_intrnl_line_num | numeric | Yes |  |
| invc_round_diff_amt | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.tktl
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_date | datetime | No |  |
| order_code | char | No | 12 |
| tkt_code | char | No | 8 |
| order_intrnl_line_num | numeric | No |  |
| actl_batch_qty | numeric | Yes |  |
| cstmry_actl_batch_qty | numeric | Yes |  |
| metric_actl_batch_qty | numeric | Yes |  |
| matl_price | numeric | Yes |  |
| cstmry_matl_price | numeric | Yes |  |
| metric_matl_price | numeric | Yes |  |
| haul_price | numeric | Yes |  |
| cstmry_haul_price | numeric | Yes |  |
| metric_haul_price | numeric | Yes |  |
| delv_price | numeric | Yes |  |
| cstmry_delv_price | numeric | Yes |  |
| metric_delv_price | numeric | Yes |  |
| cost | numeric | Yes |  |
| cost_uom | char | Yes | 5 |
| cstmry_cost | numeric | Yes |  |
| metric_cost | numeric | Yes |  |
| cost_ext_code | char | Yes | 1 |
| ext_matl_cost_amt | numeric | Yes |  |
| delv_qty | numeric | Yes |  |
| cstmry_delv_qty | numeric | Yes |  |
| metric_delv_qty | numeric | Yes |  |
| delv_qty_uom | char | Yes | 5 |
| cstmry_delv_qty_uom | char | Yes | 5 |
| metric_delv_qty_uom | char | Yes | 5 |
| orig_delv_qty | numeric | Yes |  |
| cstmry_orig_delv_qty | numeric | Yes |  |
| metric_orig_delv_qty | numeric | Yes |  |
| order_delv_qty | numeric | Yes |  |
| cstmry_order_delv_qty | numeric | Yes |  |
| metric_order_delv_qty | numeric | Yes |  |
| dump_qty | numeric | Yes |  |
| cstmry_dump_qty | numeric | Yes |  |
| metric_dump_qty | numeric | Yes |  |
| pre_batched_qty | numeric | Yes |  |
| cstmry_pre_batched_qty | numeric | Yes |  |
| metric_pre_batched_qty | numeric | Yes |  |
| resold_qty | numeric | Yes |  |
| cstmry_resold_qty | numeric | Yes |  |
| metric_resold_qty | numeric | Yes |  |
| price_qty | numeric | Yes |  |
| cstmry_price_qty | numeric | Yes |  |
| metric_price_qty | numeric | Yes |  |
| tkt_qty | numeric | Yes |  |
| cstmry_tkt_qty | numeric | Yes |  |
| metric_tkt_qty | numeric | Yes |  |
| resold_tkt_code | char | Yes | 8 |
| rm_slump | char | Yes | 8 |
| rm_slump_uom | char | Yes | 5 |
| rm_mix_flag | bit | Yes |  |
| ext_price_amt | numeric | Yes |  |
| ship_plant_code | char | Yes | 3 |
| susp_rsn_code | char | Yes | 3 |
| invy_adjust_code | char | Yes | 1 |
| sales_anl_adjust_code | char | Yes | 1 |
| moved_order_date | datetime | Yes |  |
| moved_to_order_code | char | Yes | 12 |
| moved_from_order_code | char | Yes | 12 |
| reused_order_date | datetime | Yes |  |
| reused_order_code | char | Yes | 12 |
| batch_code | char | Yes | 12 |
| am_min_temp | numeric | Yes |  |
| invc_round_diff_amt | numeric | Yes |  |
| chrg_cart_code | char | Yes | 3 |
| ext_matl_price | numeric | Yes |  |
| ext_haul_price | numeric | Yes |  |
| ext_delv_price | numeric | Yes |  |
| inventory_update_qty | numeric | Yes |  |
| temperature | numeric | Yes |  |
| temperature_uom | char | Yes | 5 |
| energy_consumed | numeric | Yes |  |
| energy_consumed_uom | char | Yes | 5 |
| pct_hydrate | numeric | Yes |  |
| record_origin_code | char | Yes | 2 |
| pre_batched_water_qty | numeric | Yes |  |
| pre_batched_water_uom | char | Yes | 5 |
| pre_batched_uom | char | Yes | 5 |
| order_num | char | Yes | 9 |
| version | char | Yes | 2 |
| seq_num | char | Yes | 2 |
| external_plant_code | char | Yes | 7 |
| dump_water_qty | numeric | Yes |  |
| ext_pay_cart_amt | numeric | Yes |  |
| pay_cart_qty | numeric | Yes |  |
| pay_cart_qty_uom | char | Yes | 5 |
| pay_cart_rate_amt | numeric | Yes |  |
| min_slump | numeric | Yes |  |
| max_slump | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| lot_num_list | varchar | Yes | 2000 |

## Table: dbo.tktx
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_date | datetime | No |  |
| order_code | char | No | 12 |
| tkt_code | char | No | 8 |
| tax_auth | char | No | 4 |
| tax_loc | char | No | 8 |
| non_tax_rsn_code | char | No | 3 |
| taxble_amt | numeric | Yes |  |
| non_taxble_amt | numeric | Yes |  |
| tax_amt | numeric | Yes |  |
| taxble_tax_amt | numeric | Yes |  |
| tax_red_amt | numeric | Yes |  |
| tax_reduction_profile_code | char | Yes | 3 |
| tax_red_percent | numeric | Yes |  |
| third_party_jurisdiction_id | char | Yes | 10 |
| third_party_tax_rule_id | char | Yes | 10 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.tlac
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| prod_descr | char | No | 40 |
| order_date | datetime | No |  |
| order_code | char | No | 12 |
| tkt_code | char | No | 8 |
| order_intrnl_line_num | numeric | No |  |
| tkt_chrg_intrnl_line_num | numeric | No |  |
| tkt_chrg_code | char | Yes | 2 |
| prod_code | char | Yes | 12 |
| short_prod_descr | char | Yes | 16 |
| prod_cat | char | Yes | 6 |
| price | numeric | Yes |  |
| cstmry_price | numeric | Yes |  |
| metric_price | numeric | Yes |  |
| price_uom | char | Yes | 5 |
| cstmry_price_uom | char | Yes | 5 |
| metric_price_uom | char | Yes | 5 |
| price_derived_from_code | char | Yes | 2 |
| price_ext_code | char | Yes | 1 |
| taxble_code | numeric | Yes |  |
| non_tax_rsn_code | char | Yes | 3 |
| delv_qty | numeric | Yes |  |
| cstmry_delv_qty | numeric | Yes |  |
| metric_delv_qty | numeric | Yes |  |
| delv_qty_uom | char | Yes | 5 |
| cstmry_delv_qty_uom | char | Yes | 5 |
| metric_delv_qty_uom | char | Yes | 5 |
| ext_price_amt | numeric | Yes |  |
| price_qty | numeric | Yes |  |
| cstmry_price_qty | numeric | Yes |  |
| metric_price_qty | numeric | Yes |  |
| cost | numeric | Yes |  |
| cost_uom | char | Yes | 5 |
| cstmry_cost | numeric | Yes |  |
| metric_cost | numeric | Yes |  |
| cost_ext_code | char | Yes | 1 |
| ext_matl_cost_amt | numeric | Yes |  |
| moved_order_date | datetime | Yes |  |
| moved_to_order_code | char | Yes | 12 |
| moved_from_order_code | char | Yes | 12 |
| delv_price_flag | bit | Yes |  |
| min_haul_amt | numeric | Yes |  |
| haul_sur_flag | bit | Yes |  |
| print_sur_flag | bit | Yes |  |
| invc_show_min_haul_flag | bit | Yes |  |
| invc_round_diff_amt | numeric | Yes |  |
| usage_code | char | Yes | 4 |
| incl_pump_min_pchg_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| chrg_source_table_info | varchar | Yes | -1 |

## Table: dbo.tlap
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_date | datetime | No |  |
| order_code | char | No | 12 |
| tkt_code | char | No | 8 |
| order_intrnl_line_num | numeric | No |  |
| assoc_prod_intrnl_line_num | numeric | No |  |
| assoc_prod_sort_line_num | numeric | Yes |  |
| delv_qty | numeric | Yes |  |
| cstmry_delv_qty | numeric | Yes |  |
| metric_delv_qty | numeric | Yes |  |
| delv_qty_uom | char | Yes | 5 |
| cstmry_delv_qty_uom | char | Yes | 5 |
| metric_delv_qty_uom | char | Yes | 5 |
| orig_delv_qty | numeric | Yes |  |
| cstmry_orig_delv_qty | numeric | Yes |  |
| metric_orig_delv_qty | numeric | Yes |  |
| order_delv_qty | numeric | Yes |  |
| cstmry_order_delv_qty | numeric | Yes |  |
| metric_order_delv_qty | numeric | Yes |  |
| price_qty | numeric | Yes |  |
| cstmry_price_qty | numeric | Yes |  |
| metric_price_qty | numeric | Yes |  |
| tkt_qty | numeric | Yes |  |
| cstmry_tkt_qty | numeric | Yes |  |
| metric_tkt_qty | numeric | Yes |  |
| ext_price_amt | numeric | Yes |  |
| cost | numeric | Yes |  |
| cost_uom | char | Yes | 5 |
| cstmry_cost | numeric | Yes |  |
| metric_cost | numeric | Yes |  |
| cost_ext_code | char | Yes | 1 |
| ext_matl_cost_amt | numeric | Yes |  |
| susp_rsn_code | char | Yes | 3 |
| moved_order_date | datetime | Yes |  |
| moved_to_order_code | char | Yes | 12 |
| moved_from_order_code | char | Yes | 12 |
| batch_wgts_updt_flag | bit | Yes |  |
| invy_adjust_code | char | Yes | 1 |
| sales_anl_adjust_code | char | Yes | 1 |
| invc_round_diff_amt | numeric | Yes |  |
| trim_pct | numeric | Yes |  |
| inventory_update_qty | numeric | Yes |  |
| resold_qty | numeric | Yes |  |
| cstmry_resold_qty | numeric | Yes |  |
| metric_resold_qty | numeric | Yes |  |
| resold_tkt_code | char | Yes | 8 |
| dump_qty | numeric | Yes |  |
| cstmry_dump_qty | numeric | Yes |  |
| metric_dump_qty | numeric | Yes |  |
| entered_delv_qty | numeric | Yes |  |
| full_order_delv_qty | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.trkt
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_date | datetime | No |  |
| truck_code | char | No | 10 |
| punch_in_time_1 | datetime | Yes |  |
| punch_in_time_2 | datetime | Yes |  |
| punch_in_time_3 | datetime | Yes |  |
| punch_in_time_4 | datetime | Yes |  |
| punch_in_time_5 | datetime | Yes |  |
| punch_in_time_6 | datetime | Yes |  |
| punch_out_time_1 | datetime | Yes |  |
| punch_out_time_2 | datetime | Yes |  |
| punch_out_time_3 | datetime | Yes |  |
| punch_out_time_4 | datetime | Yes |  |
| punch_out_time_5 | datetime | Yes |  |
| punch_out_time_6 | datetime | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.trms
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| terms_code | char | No | 3 |
| descr | char | No | 40 |
| disc_amt_1 | numeric | Yes |  |
| disc_amt_2 | numeric | Yes |  |
| disc_day_1 | numeric | Yes |  |
| disc_day_2 | numeric | Yes |  |
| due_day_1 | numeric | Yes |  |
| due_day_2 | numeric | Yes |  |
| prox_start_1 | numeric | Yes |  |
| prox_start_2 | numeric | Yes |  |
| prox_end_1 | numeric | Yes |  |
| prox_end_2 | numeric | Yes |  |
| short_descr | char | Yes | 8 |
| terms_type | numeric | Yes |  |
| per_uom | char | Yes | 5 |
| exmpt_delv_flag | bit | Yes |  |
| exmpt_delv_type | char | Yes | 1 |
| exmpt_delv_rate | numeric | Yes |  |
| exmpt_delv_uom | char | Yes | 5 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.trtm
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| unique_num | numeric | No |  |
| order_date | datetime | Yes |  |
| order_code | char | Yes | 12 |
| tkt_code | char | Yes | 8 |
| truck_code | char | Yes | 10 |
| start_time | datetime | Yes |  |
| end_time | datetime | Yes |  |
| task_code | char | Yes | 5 |
| truck_clock_flag | bit | Yes |  |
| truck_productive_flag | bit | Yes |  |
| start_status | numeric | Yes |  |
| driv_empl_code | char | Yes | 12 |
| source | char | Yes | 2 |
| user_name | char | Yes | 20 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.truc
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| truck_code | char | No | 10 |
| descr | char | Yes | 40 |
| short_descr | char | Yes | 8 |
| owner_name | char | Yes | 40 |
| truck_date | datetime | Yes |  |
| hler_code | char | Yes | 8 |
| lic_num | char | Yes | 10 |
| lic_expir_date | datetime | Yes |  |
| driv_lic_num | char | Yes | 20 |
| driv_lic_expir_date | datetime | Yes |  |
| insur_name | char | Yes | 40 |
| insur_expir_date | datetime | Yes |  |
| radio_code | char | Yes | 16 |
| auto_tkt_card_code | char | Yes | 20 |
| prod_line_code | char | Yes | 2 |
| assgn_driv_empl_code | char | Yes | 12 |
| assgn_plant_code | char | Yes | 3 |
| truck_type | char | Yes | 2 |
| min_load_size | numeric | Yes |  |
| max_load_size | numeric | Yes |  |
| sched_load_size | numeric | Yes |  |
| load_size_uom | char | Yes | 5 |
| auto_signal_flag | bit | Yes |  |
| curr_driv_empl_code | char | Yes | 12 |
| curr_stat | numeric | Yes |  |
| curr_stat_time | datetime | Yes |  |
| from_plant_code | char | Yes | 3 |
| to_plant_code | char | Yes | 3 |
| last_tkt_code | char | Yes | 8 |
| last_order_date | datetime | Yes |  |
| last_order_code | char | Yes | 12 |
| last_track_truck_color | numeric | Yes |  |
| last_track_truck_flag_code | char | Yes | 1 |
| on_job_time | datetime | Yes |  |
| track_truck_color | numeric | Yes |  |
| track_truck_flag_code | char | Yes | 1 |
| signl_unit_code | char | Yes | 3 |
| signl_msg_time | datetime | Yes |  |
| signl_msg_allow_mins | numeric | Yes |  |
| signl_msg_track_truck_color | numeric | Yes |  |
| signl_msg_track_truck_flag_code | char | Yes | 1 |
| next_tkt_code | char | Yes | 8 |
| next_order_date | datetime | Yes |  |
| next_order_code | char | Yes | 12 |
| next_order_intrnl_line_num | numeric | Yes |  |
| next_net_wgt | numeric | Yes |  |
| next_delv_meth_code | char | Yes | 2 |
| next_prim_trlr_line_num | numeric | Yes |  |
| next_prim_trlr_net_wgt | numeric | Yes |  |
| next_scndry_trlr_line_num | numeric | Yes |  |
| next_scndry_trlr_net_wgt | numeric | Yes |  |
| sched_order_date | datetime | Yes |  |
| sched_order_code | char | Yes | 12 |
| sched_order_line_num | numeric | Yes |  |
| sched_order_sched_num | numeric | Yes |  |
| tare_date | datetime | Yes |  |
| tare_time | datetime | Yes |  |
| tare_wgt | numeric | Yes |  |
| tare_wgt_uom | char | Yes | 5 |
| tare_days | numeric | Yes |  |
| tare_type | char | Yes | 1 |
| tare_flag | bit | Yes |  |
| gross_date | datetime | Yes |  |
| gross_time | datetime | Yes |  |
| gross_wgt | numeric | Yes |  |
| gross_wgt_uom | char | Yes | 5 |
| prim_trlr_code | char | Yes | 10 |
| scndry_trlr_code | char | Yes | 10 |
| fob_flag | bit | Yes |  |
| map_long | char | Yes | 9 |
| map_lat | char | Yes | 9 |
| map_update_date | datetime | Yes |  |
| ret_matl_flag | bit | Yes |  |
| ret_matl_qty | numeric | Yes |  |
| truck_avail_flag | bit | Yes |  |
| start_date_time | datetime | Yes |  |
| end_date_time | datetime | Yes |  |
| rtt_flag | bit | Yes |  |
| num_drops | numeric | Yes |  |
| bin_num | char | Yes | 3 |
| drop_pct_1 | numeric | Yes |  |
| drop_pct_2 | numeric | Yes |  |
| drop_pct_3 | numeric | Yes |  |
| drop_pct_4 | numeric | Yes |  |
| drop_pct_5 | numeric | Yes |  |
| drop_pct_6 | numeric | Yes |  |
| last_order_intrnl_line_num | numeric | Yes |  |
| last_order_sched_num | numeric | Yes |  |
| track_truck_perm_color | numeric | Yes |  |
| gps_flag | bit | Yes |  |
| auto_status_flag | bit | Yes |  |
| map_velocity_knots | numeric | Yes |  |
| map_direction | numeric | Yes |  |
| state_tare_wgt | numeric | Yes |  |
| newassgn_msg_code | numeric | Yes |  |
| last_order_roster_flag | bit | Yes |  |
| conc_max_gross_wgt | numeric | Yes |  |
| track_truck_perm_flag_code | char | Yes | 1 |
| new_assgn_unique_num | numeric | Yes |  |
| certificate_expiration_date | datetime | Yes |  |
| conc_max_gross_wgt_uom | char | Yes | 5 |
| future_tick_flag | bit | Yes |  |
| alt_load_size_1 | numeric | Yes |  |
| alt_load_size_2 | numeric | Yes |  |
| alt_load_size_3 | numeric | Yes |  |
| alt_load_size_4 | numeric | Yes |  |
| guid | char | Yes | 36 |
| truck_status_code | char | Yes | 2 |
| ret_matl_qty_uom | char | Yes | 5 |
| variable_cost_per_hour | numeric | Yes |  |
| variable_cost_per_mile | numeric | Yes |  |
| inactive_flag | bit | Yes |  |
| lic_state | char | Yes | 10 |
| mobileticket_code | char | Yes | 2 |
| truck_group_code | char | Yes | 2 |
| inactive_code | char | Yes | 2 |
| inactive_date | datetime | Yes |  |
| ret_water_qty | numeric | Yes |  |
| ret_water_qty_uom | char | Yes | 5 |
| truck_fuel_pct | numeric | Yes |  |
| truck_fuel_last_received | datetime | Yes |  |
| expir_date_1 | datetime | Yes |  |
| expir_date_2 | datetime | Yes |  |
| alt_stat_code | numeric | Yes |  |
| sync_external_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| user_defined | varchar | Yes | -1 |

## Table: dbo.tsgr
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| user_name | char | No | 20 |
| config_num | numeric | No |  |
| grid_num | numeric | No |  |
| grid_type | numeric | Yes |  |
| grid_title | char | Yes | 80 |
| grid_start_row | numeric | Yes |  |
| grid_start_col | numeric | Yes |  |
| grid_width | numeric | Yes |  |
| grid_height | numeric | Yes |  |
| grid_start_hour | numeric | Yes |  |
| grid_start_trucks | numeric | Yes |  |
| grid_mins_per_col | numeric | Yes |  |
| grid_trks_per_row | numeric | Yes |  |
| grid_mins_per_line | numeric | Yes |  |
| grid_trks_per_line | numeric | Yes |  |
| grid_column_mult | numeric | Yes |  |
| grid_disply_lines | numeric | Yes |  |
| grid_report_lines | numeric | Yes |  |
| grid_report_type | numeric | Yes |  |
| grid_pre_load_flag | bit | Yes |  |
| grid_fleet_adj_flag | bit | Yes |  |
| grid_truck_avail_flag | bit | Yes |  |
| grid_truck_demand_flag | bit | Yes |  |
| grid_dynamic_fleet_flag | bit | Yes |  |
| region_code | char | Yes | 3 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| sched_plant_code | varchar | Yes | 2000 |
| sched_truck_type | varchar | Yes | 500 |
| sched_prod_line_code | varchar | Yes | 30 |

## Table: dbo.tshd
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| user_name | char | No | 20 |
| config_num | numeric | No |  |
| setup_type | numeric | Yes |  |
| switch_key_1 | char | Yes | 1 |
| switch_key_2 | char | Yes | 1 |
| switch_key_3 | char | Yes | 1 |
| switch_key_4 | char | Yes | 1 |
| track_flag | bit | Yes |  |
| roster_flag | bit | Yes |  |
| sched_count | numeric | Yes |  |
| track_disply_type | numeric | Yes |  |
| track_order_sort | numeric | Yes |  |
| track_column_4_type | numeric | Yes |  |
| track_plant_sum_lines | numeric | Yes |  |
| track_lower_middle | numeric | Yes |  |
| track_lower_right | numeric | Yes |  |
| track_cust_addr_disp | numeric | Yes |  |
| track_start_row | numeric | Yes |  |
| track_start_col | numeric | Yes |  |
| track_num_rows | numeric | Yes |  |
| track_num_order_rows | numeric | Yes |  |
| track_group_by_plant_flag | bit | Yes |  |
| track_hide_trucks_flag | bit | Yes |  |
| track_loading_trucks_flag | bit | Yes |  |
| track_load_seq_truck_flag | bit | Yes |  |
| track_order_due_time_flag | bit | Yes |  |
| track_order_type | char | Yes | 2 |
| roster_disply_type | numeric | Yes |  |
| roster_title | char | Yes | 80 |
| roster_truck_sort | numeric | Yes |  |
| roster_plant_sum_lines | numeric | Yes |  |
| roster_start_row | numeric | Yes |  |
| roster_start_col | numeric | Yes |  |
| roster_num_rows | numeric | Yes |  |
| roster_start_hour | numeric | Yes |  |
| roster_mins_per_col | numeric | Yes |  |
| roster_group_by_plant_flag | bit | Yes |  |
| mins_back_to_show_detail | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| track_plant_code | varchar | Yes | 2000 |
| track_prod_line_code | varchar | Yes | 30 |
| roster_plant_code | varchar | Yes | 2000 |
| roster_prod_line_code | varchar | Yes | 30 |

## Table: dbo.ttyp
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| truck_type | char | No | 2 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| max_load_size | numeric | Yes |  |
| min_load_size | numeric | Yes |  |
| sched_load_size | numeric | Yes |  |
| load_size_uom | char | Yes | 5 |
| unld_mins_per_load | numeric | Yes |  |
| job_washdown_time | numeric | Yes |  |
| tarp_time | numeric | Yes |  |
| start_date_time | datetime | Yes |  |
| work_date_time | datetime | Yes |  |
| empty_speed | numeric | Yes |  |
| loading_speed | numeric | Yes |  |
| daily_cost | numeric | Yes |  |
| hourly_cost | numeric | Yes |  |
| distance_empty_cost | numeric | Yes |  |
| distance_loaded_cost | numeric | Yes |  |
| overtime_cost | numeric | Yes |  |
| num_drops | numeric | Yes |  |
| percent_drop_1 | numeric | Yes |  |
| percent_drop_2 | numeric | Yes |  |
| percent_drop_3 | numeric | Yes |  |
| percent_drop_4 | numeric | Yes |  |
| percent_drop_5 | numeric | Yes |  |
| percent_drop_6 | numeric | Yes |  |
| prod_line_code | char | Yes | 2 |
| pump_truck_type | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| spc_prop | varchar | Yes | 2000 |

## Table: dbo.twgt
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| order_date | datetime | No |  |
| order_code | char | No | 12 |
| tkt_code | char | No | 8 |
| const_prod_code | char | No | 12 |
| actl_batch_qty | numeric | Yes |  |
| actl_batch_qty_uom | char | Yes | 5 |
| actl_pct_moist | numeric | Yes |  |
| target_batch_qty | numeric | Yes |  |
| target_batch_qty_uom | char | Yes | 5 |
| target_pct_moist | numeric | Yes |  |
| batch_unit_target_batch_qty | numeric | Yes |  |
| batch_unit_target_batch_qty_uom | char | Yes | 5 |
| batch_unit_target_pct_moist | numeric | Yes |  |
| batch_unit_dwnld_flag | bit | Yes |  |
| batch_wgts_updt_flag | bit | Yes |  |
| per_mix_cubic_qty | numeric | Yes |  |
| cost | numeric | Yes |  |
| cost_uom | char | Yes | 5 |
| metric_cost | numeric | Yes |  |
| cstmry_cost | numeric | Yes |  |
| cost_ext_code | char | Yes | 1 |
| ext_matl_cost_amt | numeric | Yes |  |
| min_toler | numeric | Yes |  |
| max_toler | numeric | Yes |  |
| max_tare_wgt | numeric | Yes |  |
| batch_asphalt_pct | numeric | Yes |  |
| sort_line_num | numeric | Yes |  |
| batch_watcher_upd_flag | bit | Yes |  |
| inventory_update_qty | numeric | Yes |  |
| uom_string_from_batch | char | Yes | 15 |
| interface_const_code | char | Yes | 2 |
| manual_tick_code | char | Yes | 2 |
| actl_batch_time | datetime | Yes |  |
| actl_wgts_to_lab_code | char | Yes | 2 |
| user_name | char | Yes | 20 |
| inv_batch_qty | numeric | Yes |  |
| inv_batch_qty_uom | char | Yes | 5 |
| modified_date | datetime | Yes |  |
| actual_wgts_src_code | char | Yes | 2 |
| manual_weight_entry | bit | Yes |  |
| water_trim | numeric | Yes |  |
| water_trim_uom | char | Yes | 5 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.ucfg
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| user_name | char | No | 20 |
| date_cut_off | char | Yes | 40 |
| gps_format | numeric | Yes |  |
| tlbar_help_flag | bit | Yes |  |
| ordr_pre_flag | bit | Yes |  |
| use_tlbar_flag | bit | Yes |  |
| show_sys_name_flag | bit | Yes |  |
| actvt_flag | numeric | Yes |  |
| clr_msg_frame_flag | bit | Yes |  |
| dsptch_sets_load_flag | bit | Yes |  |
| limit_agg_tkt_flag | bit | Yes |  |
| dft_ordr_file | numeric | Yes |  |
| smplfd_ordr_flag | bit | Yes |  |
| cell_height | numeric | Yes |  |
| dialog_box_type_flag | bit | Yes |  |
| caller_id_flag | char | Yes | 2 |
| tracking_type | char | Yes | 2 |
| cmdtrack | char | Yes | 2 |
| fnd_max_num | numeric | Yes |  |
| enable_new_find_code | bit | Yes |  |
| order_tree_size | char | Yes | 50 |
| dft_schdling_plant_flag | bit | Yes |  |
| strtup_snd | varchar | Yes | 460 |
| help_snd | varchar | Yes | 460 |
| shtdwn_snd | varchar | Yes | 460 |
| msg_snd | varchar | Yes | 460 |
| mail_snd | varchar | Yes | 460 |
| app_bkgrnd | varchar | Yes | 460 |
| form_bkgrnd | varchar | Yes | 460 |
| std_toolbar | varchar | Yes | 460 |
| toolbar | varchar | Yes | 460 |
| trking_frgrnd | varchar | Yes | 460 |
| schdling_frgrnd | varchar | Yes | 460 |
| trking_bkgrnd | varchar | Yes | 460 |
| schdling_bkgrnd | varchar | Yes | 460 |
| ts_font | varchar | Yes | 460 |
| form_set | varchar | Yes | 460 |
| order_pre_days_back | numeric | Yes |  |
| order_pre_disp_code | char | Yes | 1 |
| desktop_mode | char | Yes | 2 |
| ordr_pre_grid_flag | char | Yes | 20 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| prsnl_menu | varchar | Yes | -1 |

## Table: dbo.ucfield
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| u_flab | varchar | No | 32 |
| u_vlab | varchar | No | 32 |
| u_tlab | varchar | No | 32 |
| u_fseq | int | Yes |  |
| u_dtyp | varchar | Yes | 2 |
| u_indb | varchar | Yes | 1 |
| u_intf | varchar | Yes | 64 |
| u_syn | varchar | Yes | 192 |
| u_lay | varchar | Yes | 128 |
| u_desc | varchar | Yes | -1 |

## Table: dbo.uchc
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| unld_chrg_table_id | char | No | 3 |
| comp_code | char | No | 4 |
| plant_code | char | No | 3 |
| begin_stat | numeric | Yes |  |
| end_stat | numeric | Yes |  |
| allow_mins_per_load | numeric | Yes |  |
| allow_mins_per_unit | numeric | Yes |  |
| allow_mins_per_unit_uom | char | Yes | 5 |
| minimum_allow_mins_per_load | numeric | Yes |  |
| unld_chrg_incr_mins | numeric | Yes |  |
| prod_code | char | Yes | 12 |
| chrg_avg_meth | numeric | Yes |  |
| wrtoff_mins_per_chrg | numeric | Yes |  |
| add_to_tkt | numeric | Yes |  |
| unld_qty_round_code | numeric | Yes |  |
| delv_qty_round_code | numeric | Yes |  |
| price | numeric | Yes |  |
| price_uom | char | Yes | 5 |
| price_exempt_qty | numeric | Yes |  |
| price_exempt_qty_uom | char | Yes | 5 |
| charge_time_type | char | Yes | 1 |
| apply_to_pump_type | char | Yes | 1 |
| incl_pump_min_pchg_flag | bit | Yes |  |
| unld_qty_round_to | numeric | Yes |  |
| use_time_related_charges | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.uchg
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| unld_chrg_table_id | char | No | 3 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| begin_stat | numeric | Yes |  |
| end_stat | numeric | Yes |  |
| allow_mins_per_load | numeric | Yes |  |
| allow_mins_per_unit | numeric | Yes |  |
| allow_mins_per_unit_uom | char | Yes | 5 |
| minimum_allow_mins_per_load | numeric | Yes |  |
| unld_chrg_incr_mins | numeric | Yes |  |
| prod_code | char | Yes | 12 |
| chrg_avg_meth | numeric | Yes |  |
| wrtoff_mins_per_chrg | numeric | Yes |  |
| add_to_tkt | numeric | Yes |  |
| unld_qty_round_code | numeric | Yes |  |
| delv_qty_round_code | numeric | Yes |  |
| price | numeric | Yes |  |
| price_uom | char | Yes | 5 |
| apply_to_pump_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.uckey
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| u_vlab | varchar | No | 32 |
| u_tlab | varchar | No | 32 |
| u_kseq | int | No |  |
| u_ktyp | varchar | Yes | 1 |
| u_doc | varchar | Yes | -1 |

## Table: dbo.udml
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| date_time | datetime | No |  |
| user_name | char | No | 20 |
| action_code | char | No | 3 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| action | varchar | Yes | -1 |

## Table: dbo.uobj
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| ucsub | char | No | 1 |
| uclabel | char | No | 16 |
| ucvar | char | No | 16 |
| uctype | char | No | 3 |
| uclass | char | No | 8 |
| ucobject | varbinary | Yes | 7931 |
| utimestamp | datetime | Yes |  |
| ucvers | char | Yes | 1 |

## Table: dbo.uomc
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| uom | char | No | 5 |
| target_uom | char | No | 5 |
| mult_value | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.uomi
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| item_code | char | No | 12 |
| uom | char | No | 5 |
| target_uom | char | No | 5 |
| mult_value | numeric | Yes |  |
| modified_date | datetime | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.uoms
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| uom | char | No | 5 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| abbr | char | Yes | 2 |
| uom_type | numeric | Yes |  |
| predef_flag | bit | Yes |  |
| accum_flag | bit | Yes |  |
| imperial_flag | bit | Yes |  |
| system_conv_uom | char | Yes | 5 |
| iso_code | char | Yes | 3 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.updh
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| seq_num | numeric | No |  |
| old_version | char | Yes | 40 |
| new_version | char | Yes | 40 |
| success | char | Yes | 1 |
| upgrade_date | datetime | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.updt
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| name | char | No | 100 |
| install_folder | char | No | 60 |
| asn_path | char | No | 60 |
| ip_addr | char | Yes | 40 |
| last_version_run | char | Yes | 40 |
| os_version | char | Yes | 40 |
| last_login | datetime | Yes |  |
| last_phone_home | datetime | Yes |  |
| uniface_expiration_string | char | Yes | 40 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.uprt
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| printer_code | char | No | 16 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| printer_type | char | Yes | 1 |
| device_type | char | Yes | 6 |
| device_mode | char | Yes | 1 |
| device_width | numeric | Yes |  |
| device_length | numeric | Yes |  |
| plant_code | char | Yes | 3 |
| queued_flag | bit | Yes |  |
| queued_mgr_num | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| printer_url | varchar | Yes | 2000 |
| printer_init | varchar | Yes | 2000 |
| printer_close | varchar | Yes | 2000 |

## Table: dbo.uscf
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| user_name | char | No | 20 |
| form_name | char | No | 8 |
| file_name | char | No | 6 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| config_text | varchar | Yes | 2000 |

## Table: dbo.usge
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| usage_code | char | No | 4 |
| descr | char | No | 40 |
| short_descr | char | Yes | 8 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.usmg
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| key_field | char | No | 1 |
| security_method | char | Yes | 2 |
| login_mismatch_override | char | Yes | 2 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.usnm
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| user_name | char | No | 20 |
| group_flag | bit | Yes |  |
| owner_name | char | Yes | 40 |
| empl_code | char | Yes | 12 |
| pswd | char | Yes | 16 |
| group_name | char | Yes | 16 |
| life | numeric | Yes |  |
| lang | char | Yes | 3 |
| date_fmt | numeric | Yes |  |
| date_order | numeric | Yes |  |
| appl_type_01 | char | Yes | 2 |
| appl_type_02 | char | Yes | 2 |
| appl_type_03 | char | Yes | 2 |
| appl_type_04 | char | Yes | 2 |
| appl_type_05 | char | Yes | 2 |
| appl_type_06 | char | Yes | 2 |
| appl_type_07 | char | Yes | 2 |
| appl_type_08 | char | Yes | 2 |
| appl_type_09 | char | Yes | 2 |
| appl_type_10 | char | Yes | 2 |
| appl_type_11 | char | Yes | 2 |
| appl_type_12 | char | Yes | 2 |
| appl_type_13 | char | Yes | 2 |
| appl_type_14 | char | Yes | 2 |
| appl_type_15 | char | Yes | 2 |
| appl_type_16 | char | Yes | 2 |
| appl_type_17 | char | Yes | 2 |
| appl_type_18 | char | Yes | 2 |
| appl_type_19 | char | Yes | 2 |
| appl_type_20 | char | Yes | 2 |
| appl_type_21 | char | Yes | 2 |
| appl_type_22 | char | Yes | 2 |
| appl_type_23 | char | Yes | 2 |
| appl_type_24 | char | Yes | 2 |
| appl_type_25 | char | Yes | 2 |
| appl_type_26 | char | Yes | 2 |
| appl_type_27 | char | Yes | 2 |
| appl_type_28 | char | Yes | 2 |
| appl_type_29 | char | Yes | 2 |
| appl_type_30 | char | Yes | 2 |
| appl_type_31 | char | Yes | 2 |
| appl_type_32 | char | Yes | 2 |
| print_model | char | Yes | 16 |
| print_model_flag | bit | Yes |  |
| assgn_plant_code | char | Yes | 3 |
| allow_rel_cred_batch_flag | bit | Yes |  |
| allow_susp_invc_flag | bit | Yes |  |
| allow_rel_invc_flag | bit | Yes |  |
| allow_order_mix_design_flag | bit | Yes |  |
| allow_tkt_approvl_flag | bit | Yes |  |
| allow_updt_proj_order_flag | bit | Yes |  |
| allow_overhd_loadout_flag | bit | Yes |  |
| last_date_chng | datetime | Yes |  |
| last_time_chng | datetime | Yes |  |
| last_date_used | datetime | Yes |  |
| last_time_used | datetime | Yes |  |
| used_count | numeric | Yes |  |
| chng_count | numeric | Yes |  |
| gim_screen_master_edit_flag | bit | Yes |  |
| gim_screen_group_edit_flag | bit | Yes |  |
| gim_screen_user_edit_flag | bit | Yes |  |
| gim_temp_user_edit_flag | bit | Yes |  |
| gim_view_only_flag | bit | Yes |  |
| supp_min_load_chrg_disp_flag | bit | Yes |  |
| supp_season_chrg_disp_flag | bit | Yes |  |
| allow_update_to_lang_flag | bit | Yes |  |
| allow_order_quote_flag | bit | Yes |  |
| supp_price_msg_flag | bit | Yes |  |
| expand_delv_addr_flag | bit | Yes |  |
| expand_instr_flag | bit | Yes |  |
| auto_disp_oe_proj_flag | bit | Yes |  |
| auto_disp_oe_prod_flag | bit | Yes |  |
| gim_group_name | char | Yes | 16 |
| restrict_cust_by_comp | char | Yes | 4 |
| dflt_scale_code | char | Yes | 3 |
| lab_loc_code | char | Yes | 4 |
| invc_print_code | char | Yes | 1 |
| supp_item_sub_msg_code | numeric | Yes |  |
| cust_code | char | Yes | 10 |
| allow_add_cod_order_code | char | Yes | 2 |
| allow_add_truck_code | char | Yes | 1 |
| allow_change_truck_code | char | Yes | 1 |
| allow_delete_truck_code | char | Yes | 1 |
| fleet_auto_launch_flag | bit | Yes |  |
| expiration_date | datetime | Yes |  |
| allow_non_priv_plant_flag | bit | Yes |  |
| show_expir_proj_in_lookup_flag | bit | Yes |  |
| use_dot_net_printing | char | Yes | 2 |
| kpi_role_name | char | Yes | 20 |
| kpi_plants | char | Yes | 200 |
| require_quote_fields | bit | Yes |  |
| time_zone_flag | bit | Yes |  |
| region_code | char | Yes | 3 |
| allow_tkt_over_under_flag | bit | Yes |  |
| site_code | char | Yes | 3 |
| cmdtrack_guid | char | Yes | 100 |
| priv_plant_code_list | varchar | Yes | 2000 |
| allow_cred_override_auth_flag | bit | Yes |  |
| use_grid_view | char | Yes | 2 |
| opt_admin_rights | char | Yes | 2 |
| disp_ordr_chrg_msg | bit | Yes |  |
| allow_order_copy_flag | bit | Yes |  |
| bcmt_active_user_flag | bit | Yes |  |
| order_ticket_remove_code | char | Yes | 2 |
| order_ticket_reactive_code | char | Yes | 2 |
| use_non_opt_scheduling | char | Yes | 2 |
| list_items_by_plant_code | char | Yes | 2 |
| allow_unshipped_order_copy_flag | bit | Yes |  |
| allow_copy_order_reval_flag | bit | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.verp
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| appl_name | char | No | 30 |
| vers_num | char | Yes | 50 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.vers
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| key_field | char | No | 1 |
| vers_num | char | Yes | 8 |
| delv_vers_num | char | Yes | 8 |
| build_vers_num | char | Yes | 50 |
| last_db_update | datetime | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |
| uniface_license | varchar | Yes | -1 |

## Table: dbo.znpl
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| zone_code | char | No | 8 |
| plant_code | char | No | 3 |
| price_adj_amt | numeric | Yes |  |
| price_adj_amt_effect_date | datetime | Yes |  |
| prev_price_adj_amt | numeric | Yes |  |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

## Table: dbo.zone
| Column Name | Data Type | Nullable | Max Length |
|-------------|-----------|----------|------------|
| zone_code | char | No | 8 |
| descr | char | Yes | 40 |
| short_descr | char | Yes | 8 |
| sched_plant_code | char | Yes | 3 |
| tax_code | char | Yes | 3 |
| price_adj_uom | char | Yes | 5 |
| sundry_chrg_table_id | char | Yes | 3 |
| update_date | datetime | Yes |  |
| u_version | char | Yes | 1 |

===== VIEW DEFINITIONS =====

## View: dbo.yadm

```sql

CREATE VIEW [dbo].[yadm]ASSELECT DISTINCT i.item_code,i.descr AS imst_descr,i.qc_note, u.uom,u.abbr AS uoms_abbr,u.imperial_flag, l.loc_code AS iloc_loc_code,l.spec_grav FROM dbo.imst AS i INNER JOIN dbo.uoms AS u ON i.batch_uom = u.uom INNER JOIN dbo.icat AS c ON i.item_cat = c.item_cat LEFT OUTER JOIN dbo.iloc AS l ON i.item_code = l.item_code WHERE ( c.item_type IN ('06', '07', '08', '09', '10', '11', '12') AND l.loc_code IS NOT NULL and (l.inactive_code != '02' or l.inactive_code = '' or l.inactive_code is null)and  (i.inactive_code != '02' or i.inactive_code = '' or i.inactive_code is null))
```

## View: dbo.yagg

```sql

CREATE VIEW [dbo].[yagg]ASSELECT DISTINCT i.item_code,i.descr AS imst_descr,i.agg_size, i.qc_note, u.uom,u.abbr AS uoms_abbr,u.imperial_flag, l.loc_code AS iloc_loc_code,l.spec_grav FROM imst AS i INNER JOIN dbo.uoms AS u ON i.batch_uom = u.uom INNER JOIN dbo.icat AS c ON i.item_cat = c.item_cat  LEFT OUTER JOIN dbo.iloc AS l ON i.item_code = l.item_code WHERE ( c.item_type IN ('04', '24') AND l.loc_code IS NOT NULL and (i.inactive_code != '02' or i.inactive_code = '' or i.inactive_code is null) and (l.inactive_code != '02' or l.inactive_code = '' or l.inactive_code is null)  )
```

## View: dbo.yarc

```sql

CREATE VIEW dbo.yarc ASWITH base AS (SELECT job_id, table_name, CASE table_type WHEN '01' THEN 'Transactional' WHEN '02' THEN 'Audit/Log' WHEN '03' THEN 'Master' ELSE 'Error' END AS table_type, before_count, before_size, target_count copied, 0 purged, after_count, after_size, CASE WHEN source_count IS NULL OR target_count IS NULL OR error_count IS NULL OR status IS NULL THEN 'COPY KILLED' WHEN status <> '00' OR error_count > 0 OR source_count <> target_count THEN 'COPY FAILED'  WHEN source_count = target_count AND target_count = 0 AND status = '00' AND error_count = 0 THEN 'NO ROWS COPIED'  WHEN source_count = target_count AND target_count > 0 AND status = '00' AND error_count = 0 THEN 'SUCCEEDED'  ELSE 'FAILED/UNKNOWN' END AS status, isnull(DATEDIFF(SECOND,start_time,end_time),0)/60.0 AS duration, CASE WHEN isnull(before_size,0) = 0 OR isnull(before_count,0) = 0 OR isnull(source_count,0) = 0 THEN 0 ELSE before_size*(source_count/before_count) END AS processed_size  FROM arld WHERE table_type = '03'UNIONSELECT a.job_id, a.table_name, CASE a.table_type WHEN '01' THEN 'Transactional' WHEN '02' THEN 'Audit/Log' WHEN '03' THEN 'Master' ELSE 'Error' END AS table_type, a.before_count, a.before_size, a.target_count copied, b.target_count purged, b.after_count, b.after_size, CASE WHEN a.source_count IS NULL OR a.target_count IS NULL OR a.error_count IS NULL OR a.status IS NULL THEN 'COPY KILLED' WHEN b.source_count IS NULL OR b.target_count IS NULL OR b.error_count IS NULL OR b.status IS NULL THEN 'PURGE KILLED' WHEN a.status <> '00' OR a.error_count > 0 OR a.source_count <> a.target_count THEN 'COPY FAILED' WHEN b.status <> '00' OR b.error_count > 0 OR b.source_count <> b.target_count THEN 'PURGE FAILED'  WHEN a.source_count = a.target_count AND a.target_count = 0 AND a.status = '00' AND a.error_count = 0 THEN 'NO ROWS COPIED' WHEN b.source_count = b.target_count AND b.target_count = 0 AND b.status = '00' AND b.error_count = 0 THEN 'NOT PURGED'  WHEN a.source_count = a.target_count AND a.source_count > 0 AND a.status = '00' AND a.error_count = 0 AND  b.source_count = b.target_count AND b.source_count > 0 AND b.status = '00' AND b.error_count = 0 THEN 'SUCCEEDED' ELSE 'FAILED/UNKNOWN' END AS status, isnull(DATEDIFF(SECOND,a.start_time,a.end_time),0)/60.0+isnull(DATEDIFF(SECOND,b.start_time,b.end_time),0)/60.0 AS duration, CASE WHEN isnull(a.before_size,0) = 0 OR isnull(a.before_count,0) = 0 OR isnull(a.source_count,0) = 0 THEN 0  WHEN isnull(a.before_size,0) > 0 AND isnull(a.before_count,0) > 0 AND isnull(a.source_count,0) > 0 AND isnull(b.after_size,0) = 0 AND isnull(b.target_count,0) = 0 THEN a.before_size*(a.source_count/a.before_count) WHEN isnull(a.before_size,0) > 0 AND isnull(a.before_count,0) > 0 AND isnull(a.source_count,0) > 0 AND isnull(b.after_size,0) > 0 THEN a.before_size*(a.source_count/a.before_count)+(a.before_size-b.after_size) WHEN isnull(a.before_size,0) > 0 AND isnull(a.before_count,0) > 0 AND isnull(a.source_count,0) > 0 AND isnull(b.after_size,0) = 0 AND isnull(b.target_count,0) > 0 THEN a.before_size*(a.source_count/a.before_count)+a.before_size*(b.target_count/a.before_count) ELSE -1 END AS processed_size  FROM arld a inner join arld b ON a.job_id = b.job_id AND a.table_name = b.table_name AND a.table_type = b.table_type AND CAST(a.stage AS INT)+1 = CAST(b.stage AS INT) AND a.table_type <>'03' AND b.table_type <>'03' AND a.stage = '01' AND b.stage = '02'UNIONSELECT job_id, table_name, CASE table_type WHEN '01' THEN 'Transactional' WHEN '02' THEN 'Audit/Log' WHEN '03' THEN 'Master' ELSE 'Error' END AS table_type, before_count, before_size, target_count copied, 0 purged, before_count after_count, before_size after_size, CASE WHEN source_count IS NULL OR target_count IS NULL OR error_count IS NULL OR status IS NULL THEN 'COPY KILLED' WHEN status <> '00' OR error_count > 0 OR source_count <> target_count THEN 'COPY FAILED'  WHEN source_count = target_count AND target_count = 0 AND status = '00' AND error_count = 0 THEN 'NO ROWS COPIED'  WHEN source_count = target_count AND target_count > 0 AND status = '00' AND error_count = 0 THEN 'NOT PURGED'  ELSE 'FAILED/UNKNOWN' END AS status, isnull(DATEDIFF(SECOND,start_time,end_time),0)/60.0 AS duration, CASE WHEN isnull(before_size,0) = 0 OR isnull(before_count,0) = 0 OR isnull(source_count,0) = 0 THEN 0 ELSE before_size*(source_count/before_count) END AS processed_size  FROM arld a  WHERE table_type <>'03' AND stage = '01' AND NOT EXISTS (SELECT 1 FROM arld b WHERE a.job_id = b.job_id AND a.table_name = b.table_name AND a.table_type = b.table_type AND CAST(a.stage AS INT)+1 = CAST(b.stage AS INT) AND b.table_type <>'03' AND a.stage = '01' AND b.stage = '02'))SELECT job_id,table_name,table_type,before_count,before_size,copied,purged,after_count,after_size,status,duration,processed_size, CASE WHEN duration = 0 OR processed_size IN (0,-1) THEN 0 ELSE processed_size/duration END AS speed  FROM base
```

## View: dbo.ycat

```sql

create view [dbo].[ycat] as select item_cat, item_type from icat
```

## View: dbo.yccn

```sql

CREATE VIEW dbo.yccn AS SELECT cust.cust_code, ccon.contct_code, cust.name, cust.sort_name, cust.contct_name, cust.addr_line_1, cust.addr_line_2, cust.addr_city, cust.addr_state, cust.addr_cntry, cust.addr_postcd, cust.phone_num_1, cust.phone_num_2, cust.phone_num_3, ccon.contct_type, ccon.primary_flag, ctct.name AS contact_name, ctct.addr_line_1 as contact_addr_line_1, ctct.addr_line_2 as contact_addr_line_2, ctct.addr_city as contact_addr_city, ctct.addr_state as contact_addr_state, ctct.addr_cntry as contact_addr_cntry, ctct.addr_postcd as contact_addr_postcd, ctct.phone_num_1 as contact_phone_num_1, ctct.phone_num_2 as contact_phone_num_2, ctct.phone_num_3 as contact_phone_num_3, ctct.phone_num_4 as contact_phone_num_4, ctct.email_addr, ctct.email_addr_2, ctct.email_addr_3, ctct.email_addr_mobile, ctct.cust_code AS contact_cust_code, ctct.comp_name, ctct.title, ctct.inactive_flag FROM cust inner join ccon ON cust.cust_code = ccon.cust_code inner join ctct ON ccon.contct_code = ctct.contct_code
```

## View: dbo.YCDM

```sql

create view DBO.YCDM as select CDLS.FILE_NAME, CDLS.COLUMN_NAME, CDLS.CODE_VALUE, MSGS.LANGUAGE,  MSGS.MESSAGE_ID, MSGS.DESCR, MSGS.TYPE from CDLS, MSGS where CDLS.MESSAGE_ID = MSGS.MESSAGE_ID
```

## View: dbo.ycem

```sql

CREATE VIEW [dbo].[ycem]ASSELECT DISTINCT i.item_code,i.descr AS imst_descr,i.cem_type, i.qc_note, u.uom,u.abbr AS uoms_abbr,u.imperial_flag, l.loc_code AS iloc_loc_code,l.spec_grav FROM dbo.imst AS i INNER JOIN dbo.uoms AS u ON i.batch_uom = u.uom INNER JOIN dbo.icat AS c ON i.item_cat = c.item_cat  LEFT OUTER JOIN dbo.iloc AS l ON i.item_code = l.item_code WHERE ( c.item_type IN ('03', '21') AND l.loc_code IS NOT NULL  and (i.inactive_code != '02' or i.inactive_code = '' or i.inactive_code is null) and (l.inactive_code != '02' or l.inactive_code = '' or l.inactive_code is null))
```

## View: dbo.yclc

```sql

CREATE VIEW [dbo].[yclc]ASSELECT s.item_code,s.loc_code,s.const_item_code,s.qty, c.item_type, l.contri_pct_to_cem_content FROM icst AS s INNER JOIN dbo.imst AS i ON s.const_item_code = i.item_code INNER JOIN dbo.icat AS c ON i.item_cat = c.item_cat INNER JOIN dbo.iloc AS l ON s.const_item_code = l.item_code AND s.loc_code = l.loc_code where ((i.inactive_code != '02' or i.inactive_code = '' or i.inactive_code is null) and (l.inactive_code != '02' or l.inactive_code = '' or l.inactive_code is null))
```

## View: dbo.ycmc

```sql

CREATE VIEW dbo.ycmc ASSELECTa.mgr_num,a.mgr_name,a.process_id,a.computer_name,a.ip_address,a.status,a.prompt_type,b.mgr_type,b.mgr_sub,b.mgr_update,b.mgr_next_upd,a.update_dateFROM cmct a	left outer join cmcs b on a.mgr_num = b.mgr_num
```

## View: dbo.ycmt

```sql

CREATE VIEW [dbo].[ycmt] AS SELECT b.item_code, b.loc_code, b.batch_code, b.sort_line_num, b.descr, b.short_descr FROM imlb b INNER JOIN imst i ON (b.item_code = i.item_code AND i.const_flag = 'true' AND (NOT EXISTS (SELECT * FROM imst s WHERE s.item_code = b.batch_code) OR		 EXISTS (SELECT * FROM imst s WHERE s.item_code = b.batch_code AND				 s.const_flag = 'false'))	 )
```

## View: dbo.ycpc

```sql

create view [dbo].[ycpc] as select u.cust_code, 'NO_PROJECT' proj_code, u.comp_code, u.last_invc_amt, u.last_invc_date, u.last_check_amt, u.last_check_date, u.curr_bal_amt, u.high_bal_amt, u.cred_code, u.cred_limit_amt, u.ar_cred_empl_code, u.avg_pmt_days, u.avg_pmt_trans, u.booked_orders_amt, u.shipped_orders_amt from cuco u, cust c where u.cust_code = c.cust_code and (c.inactive_code != '02' or c.inactive_code = '' or c.inactive_code is null) union select p.cust_code, p.proj_code, p.comp_code, p.last_invc_amt, p.last_invc_date, p.last_check_amt, p.last_check_date, p.curr_bal_amt, p.high_bal_amt, p.cred_code, p.cred_limit_amt, p.ar_cred_empl_code, p.avg_pmt_days, p.avg_pmt_trans, p.booked_orders_amt, p.shipped_orders_amt from prcr p, proj j, prjo k where p.proj_code = j.proj_code and p.proj_code = k.proj_code and p.cust_code = j.cust_code and p.cust_code = k.cust_code and k.cred_limit_flag != '0' and not (p.comp_code != '#' and k.cred_limit_level_code = '1')  and not (p.comp_code = '#' and k.cred_limit_level_code = '2') and (j.inactive_code != '02' or j.inactive_code = '' or j.inactive_code is null)
```

## View: dbo.ycpj

```sql

create view [dbo].[ycpj] as select a.cust_code, b.proj_code, a.name, b.proj_name, a.invc_freq_code cust_freq_code, b.invc_freq_code proj_freq_code, a.invc_copies cust_copies, b.invc_copies proj_copies from cust as a left outer join proj as b on a.cust_code = b.cust_code
```

## View: dbo.ycpl

```sql

create view [dbo].[ycpl] as select u.contct_code, c.cust_code, 'NO_PROJECT' proj_code, c.sort_name, c.name AS full_name from ccon u, cust c where u.cust_code = c.cust_code union select j.contct_code, p.cust_code, p.proj_code, p.sort_name, p.proj_name AS full_name from pcon j, proj p where j.proj_code = p.proj_code and j.cust_code = p.cust_code
```

## View: dbo.ycpp

```sql

create view [dbo].[ycpp] as	select	ordr.order_date,		ordr.order_code,		ordr.cust_code,		ordr.proj_code,		schd.pour_meth_code,		tick.tkt_code,		tick.on_job_time,		tick.begin_unld_time,		tick.end_unld_time,		tick.wash_time,		tktl.delv_qty,		tktl.delv_qty_uom	from ordr, schd, tick, tktl	where		ordr.order_date = schd.order_date and		ordr.order_code = schd.order_code and		ordr.order_date = tick.order_date and		ordr.order_code = tick.order_code and		ordr.order_date = tktl.order_date and		ordr.order_code = tktl.order_code and		tick.tkt_code = tktl.tkt_code and		tick.remove_rsn_code is NULL and		tktl.rm_mix_flag = 1 and		schd.pour_meth_code is not NULL
```

## View: dbo.ycrg

```sql

create view [dbo].[ycrg] as select ctrg.cart_code id, ctrg.range_from, ctrg.range_to, space(8-len('$' + cast(ctrg.range_amt as varchar(6))))+'$'+ cast(ctrg.range_amt as varchar(6)) amt, ctrg.min_qty min, ctrg.max_qty max, ctrg.prev_range_rate prev_rate, ctrg.range_rate_effect_date effect_date from ctrg
```

## View: dbo.YCRM

```sql

CREATE VIEW [dbo].[YCRM]ASSELECT c.cust_code, c.intrnl_line_num, c.sort_line_num,c.prod_code,c.batch_code, IsNull(c.prod_descr,i.descr) AS Prod_Descr, IsNull(c.short_prod_descr,i.short_descr) AS Short_Prod_Descr, c.est_qty, c.price_uom, c.price, c.price_ext_code, c.price_plant_code, c.effect_date, c.prev_price, c.prev_price_ext_code, c.delv_price_flag, c.dflt_load_qty, c.order_qty_uom, c.order_qty_ext_code, c.order_dosage_qty, c.order_dosage_qty_uom, c.delv_qty_uom, c.price_qty_ext_code, c.tkt_qty_ext_code,c.usage_code, c.rm_slump,c.rm_slump_uom,c.quote_code, c.allow_price_adjust_flag, c.sep_invc_flag, j.item_type, c.override_terms_disc_flag, c.disc_rate_type, c.disc_amt, c.disc_amt_uom, c.content_up_price, c.content_down_price, c.content_up_price_effect_date, c.content_down_price_effect_date, c.prev_content_up_price, c.prev_content_down_price, c.modified_date, c.type_price, c.auto_prod_flag, c.item_cat_price_flag, c.auth_user_name, c.price_status, c.price_expir_date,i.legacy_item_code,c.update_date, c.u_version, c.ca_sur_codes, c.cb_sur_codes, c.cc_sur_codes, c.cd_sur_codes, c.ca_sur_rates, c.cb_sur_rates, c.cc_sur_rates, c.cd_sur_rates, c.ca_sundry_chrg_table_ids, c.cb_sundry_chrg_table_ids, c.cc_sundry_chrg_table_ids, c.cd_sundry_chrg_table_ids, c.ca_sundry_chrg_sep_invc_flags,c.cb_sundry_chrg_sep_invc_flags, c.cc_sundry_chrg_sep_invc_flags, c.cd_sundry_chrg_sep_invc_flagsfrom CUST u, CPRD cleft outer join IMST i on c.prod_code = i.item_code left outer join ICAT j on i.item_cat = j.item_catwhere c.cust_code = u.cust_code  and (u.inactive_code != '02' or u.inactive_code = '' or u.inactive_code is null)
```

## View: dbo.ycst

```sql

CREATE VIEW [dbo].[ycst]ASSELECT s.item_code,s.loc_code,s.const_item_code, c.item_type FROM icst AS s INNER JOIN dbo.imst AS i ON s.const_item_code = i.item_code INNER JOIN dbo.icat AS c ON i.item_cat = c.item_cat where (i.inactive_code != '02' or i.inactive_code = '' or i.inactive_code is null)
```

## View: dbo.yctr

```sql

create view [dbo].[yctr] as select ctrt.cart_code id, ctrt.descr, ctrt.short_descr, ctrt.cart_rate_type rate_type, 'rate_type_descr' = case ctrt.cart_rate_type when '1' then 'Hourly (production)' when '2' then 'Hourly (clock)' when '3' then 'Load' when '4' then 'Qty/Dist' when '5' then 'Plant/Zone' when '6' then 'Qty' when '7' then 'User Defined' else 'Other' end, 'cart_type' = case ctrt.cart_type when '1' then 'Payment' when '2' then 'Charge' when '3' then 'Both' else 'Other' end, 'min_pay_type' = case ctrt.min_pay_code when '1' then 'No Charge' when '2' then 'Min Charge Amt' when '3' then 'Trucks Min Load Size time Charge Rate' when '4' then 'Trucks Sched. Load Size times Charge Rate' else 'Other' end, 'min_chr_type' = case ctrt.min_chrg_code when '1' then 'No Charge' when '2' then 'Min Charge Amt' when '3' then 'Trucks Min Load Size time Charge Rate' when '4' then 'Trucks Sched. Load Size times Charge Rate' else 'Other' end, uoms.short_descr price_uom, ctrt.prod_code, ctrt.min_qty, space(8-len('$'+cast(ctrt.dflt_rate as varchar(6))))+'$'+ cast(ctrt.dflt_rate as varchar(6)) def_rate, 'unld_time' = case ctrt.unld_time_flag when '1' then 'Yes' else 'No' end, space(8-len('$'+cast(ctrt.unld_time_rate as varchar(6))))+ '$'+cast(ctrt.unld_time_rate as varchar(6)) unl_rate, ctrt.dflt_rate_effect_date, space(8-len('$'+cast(ctrt.addl_cart_amt as varchar(6))))+ '$'+cast(ctrt.addl_cart_amt as varchar(6)) add_amt from ctrt left outer join uoms on ctrt.rate_uom=uoms.uom
```

## View: dbo.ycuc

```sql

create view [dbo].[ycuc] asselect cust.cust_code, cust.name, cust.sort_name, cuco.comp_code from cust,cuco where cust.cust_code = cuco.cust_code and (cust.inactive_code != '02' or cust.inactive_code = '' or cust.inactive_code is null)
```

## View: dbo.yczn

```sql

create view [dbo].[yczn] as select ctzn.cart_code id, 'zone' = case ctzn.zone_code when '#' then 'All' else ctzn.zone_code end, 'plant' = case ctzn.plant_code when '#' then 'All' else ctzn.plant_code end, ctzn.truck_type, space(8-len('$'+cast(ctzn.pay_rate as varchar(6))))+'$'+ cast(ctzn.pay_rate as varchar(6)) pay_rate, space(8-len('$'+cast(ctzn.charge_rate as varchar(6))))+'$'+ cast(ctzn.charge_rate as varchar(6)) charge_rate, space(8-len('$'+cast(ctzn.min_pay_amt as varchar(6))))+'$'+ cast(ctzn.min_pay_amt as varchar(6)) min_pay_amt, space(8-len('$'+cast(ctzn.min_chrg_amt as varchar(6))))+'$'+ cast(ctzn.min_chrg_amt as varchar(6)) min_chg_amt from ctzn
```

## View: dbo.ydrv

```sql

create view [dbo].[ydrv] as select a.driv_empl_code, a.plant_code, b.name, b.short_name, a.callin_date from drci a, empl b  where b.empl_code = a.driv_empl_code and (b.inactive_code != '02' or b.inactive_code = '' or b.inactive_code is null)
```

## View: dbo.yeff

```sql

create view [dbo].[yeff] as	select o.order_date,	o.order_code,	t.ship_plant_code as plant_code, t.driv_empl_code as empl_code, t.tkt_code, t.tkt_date, t.typed_time, t.loaded_time, t.on_job_time, k.order_intrnl_line_num, s.sched_num,	o.stat as order_stat,	s.stat as sched_stat,	s.sched_qty, ol.order_qty, ol.delv_qty, t.journey_code from ordr o, tick t, tktl k, schd s, ordl ol	where		o.order_date = t.order_date and		o.order_code = t.order_code and		k.order_date = t.order_date and		k.order_code = t.order_code and		s.order_date = t.order_date and		s.order_code = t.order_code and 	s.sched_num = t.sched_num and		s.order_intrnl_line_num = k.order_intrnl_line_num and 	ol.order_date = t.order_date and 	ol.order_code = t.order_code and 	ol.order_intrnl_line_num = k.order_intrnl_line_num and		k.tkt_code = t.tkt_code and		t.remove_rsn_code is NULL and		t.qc_load is NULL and		t.typed_time is NOT NULL and		t.loaded_time is NOT NULL and		t.on_job_time is NOT NULL AND (o.stat = 4 OR s.stat = 4 OR ol.delv_qty >= ol.order_qty)
```

## View: dbo.ygoa

```sql

create view [dbo].[ygoa] as select ordr.order_date, ordr.order_code, ordr.prod_line_code, ordr.stat as stat_ordr, ordr.cust_code, ordr.cust_name, ordr.cust_sort_name, ordr.proj_code, ordr.zone_code, ordr.lot_block, ordr.cust_job_num, ordr.po, ordr.taken_by_empl_code, ordr.taken_on_phone_line_num, ordr.order_by_name, ordr.order_by_phone_num, ordr.apply_min_load_chrg_flag, ordr.price_plant_code, ordr.price_plant_loc_code, ordr.comp_code, ordr.hler_code, ordr.min_load_chrg_table_id, ordr.sales_anl_code, ordr.slsmn_empl_code, ordr.remove_rsn_code, ordr.pkt_num, ordr.track_order_color, ordr.curr_load_num, ordr.cod_order_amt, ordr.setup_date as setup_date_ordr, ordr.quote_code, ordr.map_page, ordr.delv_meth_code, ordr.expir_date as expir_date_ordr, ordr.cart_code, ordr.map_long, ordr.map_lat, ordr.map_radius, ordr.alt_scale_printer_flag, ordr.metric_cstmry_code as metric_cstmry_code_ordr, ordr.start_time as start_time_ordr, ordr.job_code, ordr.phase_code, ordr.ship_to_plant_code, ordr.ship_addr_line, ordr.ship_city, ordr.ship_state, ordr.ship_cntry, ordr.ship_postcd, ordr.delv_addr, ordl.order_intrnl_line_num, ordl.prod_code, ordl.prod_descr, ordl.short_prod_descr, ordl.prod_cat, ordl.price_qty, ordl.order_qty, ordl.cstmry_order_qty, ordl.metric_order_qty, ordl.orig_order_qty, ordl.cstmry_orig_order_qty, ordl.metric_orig_order_qty, ordl.delv_qty, ordl.cstmry_delv_qty, ordl.metric_delv_qty, ordl.delv_to_date_qty, ordl.cstmry_delv_to_date_qty, ordl.metric_delv_to_date_qty, ordl.comment_text, ordl.usage_code, ordl.am_min_temp, ordl.batch_code, schd.sched_num, schd.plant_code, schd.sched_qty, schd.sched_hold_qty, schd.max_qty, schd.truck_type, schd.load_size, schd.start_time as start_time_schd, schd.end_start_time, schd.orig_start_time, schd.distance, schd.load_time, schd.tarp_time, schd.trvl_time, schd.truck_spacing_mins, schd.unld_mins_per_load, schd.qty_per_hour, schd.trucks_req, schd.rate_type, schd.loads, schd.job_washdown_time, schd.stat as stat_schd, schd.to_job_trvl_time, schd.to_plant_trvl_time, schd.sched_loads, cust.phone_num_1 as phone_num_1_cust, cust.phone_num_2 as phone_num_2_cust, cust.phone_num_3 as phone_num_3_cust, cust.phone_num_4 as phone_num_4_cust, cust.setup_date as setup_date_cust, cust.ca_track_order_color, cust.cd_track_order_color, cust.ca_print_mix_wgts_flag, cust.cd_print_mix_wgts_flag, cust.metric_cstmry_code as metric_cstmry_code_cust, proj.proj_name, proj.est_trvl, proj.contct_name, proj.phone_num_1 as phone_num_1_proj, proj.phone_num_2 as phone_num_2_proj, proj.phone_num_3 as phone_num_3_proj, proj.phone_num_4 as phone_num_4_proj, proj.setup_date as setup_date_proj, proj.expir_date as expir_date_proj, 999999.99 as sched_delv_qty_schd from ordr inner join ordl on ordr.order_date = ordl.order_date and ordr.order_code = ordl.order_code inner join cust on ordr.cust_code = cust.cust_code left outer join proj on ordr.cust_code = proj.cust_code and ordr.proj_code = proj.proj_code full outer join schd on ordl.order_date = schd.order_date and ordl.order_code = schd.order_code and ordl.order_intrnl_line_num = schd.order_intrnl_line_num where (ordr.prod_line_code = 'CA' or ordr.prod_line_code = 'CD')
```

## View: dbo.ygoc

```sql

create view [dbo].[ygoc] as select ordr.order_date, ordr.order_code, ordr.prod_line_code, ordr.stat as stat_ordr, ordr.cust_code, ordr.cust_name, ordr.cust_sort_name, ordr.proj_code, ordr.zone_code, ordr.lot_block, ordr.cust_job_num, ordr.po, ordr.taken_by_empl_code, ordr.taken_on_phone_line_num, ordr.order_by_name, ordr.order_by_phone_num, ordr.apply_min_load_chrg_flag, ordr.rm_print_mix_wgts_flag, ordr.price_plant_code, ordr.price_plant_loc_code, ordr.comp_code, ordr.hler_code, ordr.min_load_chrg_table_id, ordr.sales_anl_code, ordr.slsmn_empl_code, ordr.remove_rsn_code, ordr.pkt_num, ordr.track_order_color, ordr.curr_load_num, ordr.cod_order_amt, ordr.setup_date as setup_date_ordr, ordr.quote_code, ordr.map_page, ordr.delv_meth_code, ordr.expir_date as expir_date_ordr, ordr.cart_code, ordr.map_long, ordr.map_lat, ordr.map_radius, ordr.metric_cstmry_code as metric_cstmry_code_ordr, ordr.start_time as start_time_ordr, ordr.job_code, ordr.phase_code, ordr.ship_to_plant_code, ordr.ship_addr_line, ordr.ship_city, ordr.ship_state, ordr.ship_cntry, ordr.ship_postcd, ordr.delv_addr, ordl.order_intrnl_line_num, ordl.prod_code, ordl.prod_descr, ordl.short_prod_descr, ordl.prod_cat, ordl.price_qty, ordl.order_qty, ordl.cstmry_order_qty, ordl.metric_order_qty, ordl.orig_order_qty, ordl.cstmry_orig_order_qty, ordl.metric_orig_order_qty, ordl.delv_qty, ordl.cstmry_delv_qty, ordl.metric_delv_qty, ordl.rm_slump, ordl.comment_text, ordl.usage_code, ordl.mix_design_user_name, ordl.mix_design_update_date, ordl.qc_approvl_flag, ordl.qc_approvl_date, ordl.batch_code, schd.sched_num, schd.plant_code, schd.sched_qty, schd.sched_hold_qty, schd.max_qty, schd.truck_type, schd.load_size, schd.start_time as start_time_schd, schd.end_start_time, schd.orig_start_time, schd.distance, schd.load_time, schd.tarp_time, schd.trvl_time, schd.truck_spacing_mins, schd.unld_mins_per_load, schd.qty_per_hour, schd.trucks_req, schd.rate_type, schd.loads, schd.job_washdown_time, schd.stat as stat_schd, schd.to_job_trvl_time, schd.to_plant_trvl_time, schd.sched_loads, cust.phone_num_1 as phone_num_1_cust, cust.phone_num_2 as phone_num_2_cust, cust.phone_num_3 as phone_num_3_cust, cust.phone_num_4 as phone_num_4_cust, cust.setup_date as setup_date_cust, cust.cc_track_order_color, cust.cc_print_mix_wgts_flag, cust.metric_cstmry_code as metric_cstmry_code_cust, proj.proj_name, proj.contct_name, proj.est_trvl, proj.phone_num_1 as phone_num_1_proj, proj.phone_num_2 as phone_num_2_proj, proj.phone_num_3 as phone_num_3_proj, proj.phone_num_4 as phone_num_4_proj, proj.setup_date as setup_date_proj, proj.expir_date as expir_date_proj, 999999.99 as sched_delv_qty_schd from ordr inner join ordl on ordr.order_date = ordl.order_date and ordr.order_code = ordl.order_code inner join cust on ordr.cust_code = cust.cust_code left outer join proj on ordr.cust_code = proj.cust_code and ordr.proj_code = proj.proj_code full outer join schd on ordl.order_date = schd.order_date and ordl.order_code = schd.order_code and ordl.order_intrnl_line_num = schd.order_intrnl_line_num where ordr.prod_line_code = 'CC'
```

## View: dbo.ygta

```sql

create view [dbo].[ygta] as select truc.truck_code,truc.prod_line_code,truc.descr,truc.short_descr,truc.owner_name,truc.hler_code as hler_code_truc,truc.lic_num,truc.lic_expir_date, truc.insur_name,truc.radio_code,truc.auto_tkt_card_code,truc.assgn_driv_empl_code,truc.assgn_plant_code,truc.truck_type as truck_type_truc,truc.min_load_size, truc.max_load_size, truc.sched_load_size, truc.curr_driv_empl_code, truc.curr_stat, truc.curr_stat_time, truc.from_plant_code, truc.to_plant_code, truc.last_order_date, truc.last_order_code, truc.on_job_time as on_job_time_truc, truc.track_truck_color, truc.track_truck_perm_color, truc.track_truck_flag_code, truc.signl_unit_code, truc.next_net_wgt, truc.next_delv_meth_code, truc.next_prim_trlr_net_wgt, truc.next_scndry_trlr_net_wgt, truc.tare_date, truc.tare_time, truc.tare_wgt, truc.tare_days, truc.gross_date, truc.gross_time, truc.gross_wgt, truc.prim_trlr_code, truc.scndry_trlr_code, truc.fob_flag, truc.map_long as map_long_truc, truc.map_lat as map_lat_truc, truc.truck_avail_flag, truc.rtt_flag, truc.bin_num, truc.num_drops, truc.drop_pct_1, truc.drop_pct_2, truc.drop_pct_3, truc.drop_pct_4, truc.drop_pct_5, truc.drop_pct_6, truc.last_order_intrnl_line_num, truc.last_order_sched_num, ordr.order_date, ordr.order_code, ordr.stat, ordr.cust_code, ordr.cust_name, ordr.cust_sort_name, ordr.lot_block as lot_block_ordr, ordr.price_plant_code, ordr.price_plant_loc_code, ordr.map_page, ordr.delv_meth_code as delv_meth_code_ordr, ordr.map_long as map_long_ordr, ordr.map_lat as map_lat_ordr, ordr.map_radius, ordr.ship_to_plant_code as ship_to_plant_code_ordr, ordr.delv_addr as delv_addr_ordr, ordl.order_intrnl_line_num, ordl.prod_code, ordl.prod_descr, ordl.short_prod_descr, ordl.order_qty, ordl.cstmry_order_qty, ordl.metric_order_qty, ordl.delv_qty as delv_qty_ordl, ordl.cstmry_delv_qty as cstmry_delv_qty_ordl, ordl.metric_delv_qty as metric_delv_qty_ordl, ordl.delv_to_date_qty, ordl.cstmry_delv_to_date_qty, ordl.metric_delv_to_date_qty, ordl.comment_text, ordl.usage_code, ordl.am_min_temp, ordl.batch_code as batch_code_ordl, tick.tkt_code, tick.tkt_date, tick.driv_empl_code, tick.hler_code as hler_code_tick, tick.lot_block as lot_block_tick, tick.ship_plant_code as ship_plant_code_tick, tick.ship_plant_loc_code, tick.scale_code, tick.truck_type as truck_type_tick, tick.delv_meth_code as delv_meth_code_tick, tick.weigh_master_empl_code, tick.cod_amt, tick.cod_order_amt, tick.load_num, tick.sched_num, tick.sched_load_time, tick.typed_time, tick.load_time, tick.to_job_time, tick.on_job_time as on_job_time_tick, tick.begin_unld_time, tick.begin_unld_time_print, tick.end_unld_time, tick.wash_time, tick.to_plant_time, tick.at_plant_time, tick.distance, tick.truck_tare_wgt, tick.truck_net_wgt, tick.truck_gross_wgt, tick.man_wgt_flag, tick.ship_to_plant_code as ship_to_plant_code_tick, tick.delv_addr as delv_addr_tick, tktl.delv_qty as delv_qty_tktl, tktl.cstmry_delv_qty as cstmry_delv_qty_tktl, tktl.metric_delv_qty as metric_delv_qty_tktl, tktl.orig_delv_qty, tktl.cstmry_orig_delv_qty, tktl.metric_orig_delv_qty, tktl.order_delv_qty, tktl.cstmry_order_delv_qty, tktl.metric_order_delv_qty, tktl.price_qty, tktl.cstmry_price_qty, tktl.metric_price_qty, tktl.tkt_qty, tktl.cstmry_tkt_qty, tktl.metric_tkt_qty, tktl.ship_plant_code as ship_plant_code_tktl, tktl.batch_code as batch_code_tktl from truc left outer join tktl on truc.last_order_date = tktl.order_date and truc.last_order_code = tktl.order_code and truc.last_tkt_code = tktl.tkt_code and truc.last_order_intrnl_line_num = tktl.order_intrnl_line_num left outer join tick on truc.last_tkt_code = tick.tkt_code and truc.last_order_date = tick.order_date and truc.last_order_code = tick.order_code left outer join ordl on truc.last_order_date = ordl.order_date and truc.last_order_code = ordl.order_code and truc.last_order_intrnl_line_num = ordl.order_intrnl_line_num left outer join ordr on truc.last_order_date = ordr.order_date and truc.last_order_code = ordr.order_code where (truc.prod_line_code = 'CA' or truc.prod_line_code = 'CD')
```

## View: dbo.ygtc

```sql

create view [dbo].[ygtc] as select truc.truck_code, truc.prod_line_code, truc.descr, truc.short_descr, truc.owner_name, truc.hler_code as hler_code_truc, truc.lic_num, truc.lic_expir_date, truc.insur_name, truc.radio_code, truc.assgn_driv_empl_code, truc.assgn_plant_code, truc.truck_type as truck_type_truc, truc.min_load_size, truc.max_load_size, truc.sched_load_size, truc.curr_driv_empl_code, truc.curr_stat, truc.curr_stat_time, truc.from_plant_code, truc.to_plant_code, truc.last_order_date, truc.last_order_code, truc.on_job_time as on_job_time_truc, truc.track_truck_color, truc.track_truck_perm_color, truc.track_truck_flag_code, truc.signl_unit_code, truc.next_delv_meth_code, truc.map_long as map_long_truc, truc.map_lat as map_lat_truc, truc.ret_matl_flag, truc.ret_matl_qty, truc.truck_avail_flag, truc.last_order_intrnl_line_num, truc.last_order_sched_num, ordr.order_date, ordr.order_code, ordr.stat, ordr.cust_code, ordr.cust_name, ordr.cust_sort_name, ordr.lot_block as lot_block_ordr, ordr.price_plant_code, ordr.price_plant_loc_code, ordr.map_page, ordr.delv_meth_code as delv_meth_code_ordr, ordr.map_long as map_long_ordr, ordr.map_lat as map_lat_ordr, ordr.map_radius, ordr.ship_to_plant_code as ship_to_plant_code_ordr, ordr.delv_addr as delv_addr_ordr, ordl.order_intrnl_line_num, ordl.prod_code, ordl.prod_descr, ordl.short_prod_descr, ordl.order_qty, ordl.cstmry_order_qty, ordl.metric_order_qty, ordl.delv_qty as delv_qty_ordl, ordl.cstmry_delv_qty as cstmry_delv_qty_ordl, ordl.metric_delv_qty as metric_delv_qty_ordl, ordl.rm_slump as rm_slump_ordl, ordl.comment_text, ordl.usage_code, ordl.qc_approvl_flag, ordl.qc_approvl_date, ordl.batch_code as batch_code_ordl, tick.tkt_code, tick.tkt_date, tick.driv_empl_code, tick.hler_code as hler_code_tick, tick.lot_block as lot_block_tick, tick.rm_print_mix_wgts_flag, tick.rm_water_added_on_job, tick.ship_plant_code as ship_plant_code_tick, tick.ship_plant_loc_code, tick.truck_type as truck_type_tick, tick.delv_meth_code as delv_meth_code_tick, tick.weigh_master_empl_code, tick.cod_amt, tick.cod_order_amt, tick.load_num, tick.sched_num, tick.sched_load_time, tick.typed_time, tick.load_time, tick.to_job_time, tick.on_job_time as on_job_time_tick, tick.begin_unld_time, tick.begin_unld_time_print, tick.end_unld_time, tick.wash_time, tick.to_plant_time, tick.at_plant_time, tick.distance, tick.ship_to_plant_code as ship_to_plant_code_tick, tick.delv_addr as delv_addr_tick, tktl.delv_qty as delv_qty_tktl, tktl.cstmry_delv_qty as cstmry_delv_qty_tktl, tktl.metric_delv_qty as metric_delv_qty_tktl, tktl.orig_delv_qty, tktl.cstmry_orig_delv_qty, tktl.metric_orig_delv_qty, tktl.order_delv_qty, tktl.cstmry_order_delv_qty, tktl.metric_order_delv_qty, tktl.pre_batched_qty, tktl.cstmry_pre_batched_qty, tktl.metric_pre_batched_qty, tktl.price_qty, tktl.cstmry_price_qty, tktl.metric_price_qty, tktl.tkt_qty, tktl.cstmry_tkt_qty, tktl.metric_tkt_qty, tktl.rm_slump as rm_slump_tktl, tktl.ship_plant_code as ship_plant_code_tktl, tktl.batch_code as batch_code_tktl from truc left outer join tktl on truc.last_order_date = tktl.order_date and truc.last_order_code = tktl.order_code and truc.last_tkt_code = tktl.tkt_code and truc.last_order_intrnl_line_num = tktl.order_intrnl_line_num left outer join tick on truc.last_tkt_code = tick.tkt_code and truc.last_order_date = tick.order_date and truc.last_order_code = tick.order_code left outer join ordl on truc.last_order_date = ordl.order_date and truc.last_order_code = ordl.order_code and truc.last_order_intrnl_line_num = ordl.order_intrnl_line_num left outer join ordr on truc.last_order_date = ordr.order_date and truc.last_order_code = ordr.order_code where truc.prod_line_code = 'CC'
```

## View: dbo.yict

```sql

create view [dbo].[yict] as select  imst.*,  icat.item_typefrom  imst inner join icat on imst.item_cat = icat.item_catwhere (imst.inactive_code != '02' or imst.inactive_code = '' or imst.inactive_code is null)
```

## View: dbo.yilc

```sql

create view [dbo].[yilc] as select  iloc.loc_code,  imst.*,  iloc.item_status_code as iloc_item_status_code,  icat.item_type, usge.descr as usage_descr, usge.short_descr as usage_short_descrfrom  imst inner join iloc on imst.item_code = iloc.item_code inner join icat on imst.item_cat = icat.item_cat left outer join usge on imst.usage_code = usge.usage_code
```

## View: dbo.yims

```sql

create view [dbo].[yims] as select item_code, terms_disc_flag from imst where (inactive_code != '02' or inactive_code = '' or inactive_code is null)
```

## View: dbo.yisy

```sql

CREATE VIEW [dbo].[yisy] AS SELECT l.item_code, l.loc_code, l.edx_synch_status_code, l.guid, i.short_descr, i.item_cat, i.const_flag, i.resale_flag, c.item_type FROM (iloc l INNER JOIN imst i ON l.item_code = i.item_code) INNER JOIN icat c ON i.item_cat = c.item_cat
```

## View: dbo.yitg

```sql

CREATE VIEW dbo.yitg AS SELECT i.item_code, i.descr, i.short_descr, i.item_cat, i.cart_cat, i.invy_flag, i.invy_item_code, i.taxble_code, i.tax_rate_code, i.non_tax_rsn_code, i.usage_code, i.batch_code, i.dose_extension_code, c.item_type, i.matl_type, i.order_uom, i.price_uom, i.purch_uom, i.batch_uom, i.dose_uom, i.delv_uom, i.invy_uom, c.dflt_price_uom AS cat_price_uom, c.short_descr	AS cat_short_descr, i.inactive_code, i.terms_disc_flag FROM imst i, icat c WHERE c.item_cat = i.item_cat AND (i.inactive_code != '02' or i.inactive_code = '' or i.inactive_code is null)
```

## View: dbo.yitr

```sql

create view [dbo].[yitr] as select cust_code, item_ref_code, 'amount' = sum(case when itrn.trans_type = 11 then isnull(itrn.pretax_amt,0) + isnull(itrn.tax_amt,0) when itrn.trans_type = 21 then isnull(itrn.pretax_amt,0) + isnull(itrn.tax_amt,0) when itrn.trans_type = 22 then isnull(itrn.pretax_amt,0) + isnull(itrn.tax_amt,0) when itrn.trans_type = 13 then isnull(itrn.finc_chrg_amt,0) when itrn.trans_type = 31 then isnull(itrn.pmt_amt,0) + isnull(itrn.disc_taken_amt,0) + isnull(itrn.disc_taken_tax_amt,0) when itrn.trans_type = 32 then isnull(itrn.pmt_amt,0) + isnull(itrn.disc_taken_amt,0) + isnull(itrn.disc_taken_tax_amt,0) when itrn.trans_type = 33 then isnull(itrn.pmt_amt,0) + isnull(itrn.disc_taken_amt,0) + isnull(itrn.disc_taken_tax_amt,0) when itrn.trans_type = 41 then isnull(itrn.adj_amt,0) when itrn.trans_type = 42 then isnull(itrn.adj_amt,0) when itrn.trans_type = 43 then isnull(itrn.tax_amt,0) when itrn.trans_type = 44 then isnull(itrn.tax_amt,0) when itrn.trans_type = 51 then itrn.assgn_amt else 0 end) from itrn where post_stat = 4 and  trans_date <= convert(char(11), current_timestamp, 120) group by cust_code, item_ref_code
```

## View: dbo.yitt

```sql

CREATE VIEW [dbo].[yitt]ASSELECT i.item_code,i.descr,i.short_descr,i.item_cat,i.batch_uom, i.dose_uom,i.dose_extension_code, u.abbr AS uoms_abbr,u.imperial_flag, c.item_type, u2.abbr AS uoms_dose_abbr FROM imst AS i INNER JOIN dbo.uoms AS u ON i.batch_uom = u.uom INNER JOIN dbo.icat AS c ON i.item_cat = c.item_cat LEFT OUTER JOIN dbo.uoms AS u2 ON i.dose_uom = u2.uom where (i.inactive_code != '02' or i.inactive_code = '' or i.inactive_code is null)
```

## View: dbo.yjaf

```sql

create view [dbo].[yjaf] as select yjft.customercode, yjft.customername, yjft.customer, yjft.projectcode, yjft.projectname, yjft.project, yjft.iln, yjft.productcode, yjft.productdescr, yjft.jobid, yjft.jobname, yjft.job, yjft.jobbegindate, yjft.product, 'application' = case when yjft.itemtype = '01' then 'Concrete' when yjft.itemtype in ('04','24','25') then 'Aggregate' when yjft.itemtype = '02' then 'Asphalt' else 'Other' end, yjft.itemtype, yjft.forecastdate, yjft.plant, yjft.forecastqty, yoal.priceqty from yjft left outer join yoal on yjft.customercode = yoal.customercode and yjft.projectcode = yoal.projectcode and yjft.iln = yoal.iln and yjft.forecastdate = yoal.deliverydate and yjft.plant = yoal.plant
```

## View: dbo.yjft

```sql

create view [dbo].[yjft] as select prjp.cust_code customercode, cust.name customername, ltrim(prjp.cust_code+' '+substring(cust.name,1,20)) customer, prjp.proj_code projectcode, proj.proj_name projectname, ltrim(prjp.proj_code+' '+substring(proj.proj_name,1,20)) project, prjp.prod_code productcode, prjp.short_prod_descr productdescr, ltrim(prjp.prod_code+' '+prjp.short_prod_descr) product, jobs.job_id jobid, jobs.job_name jobname, ltrim(jobs.job_id+' '+substring(jobs.job_name,1,20)) job, convert(char(10),jobs.job_begin_date,101) jobbegindate, icat.item_type itemtype, prjp.intrnl_line_num iln, jsch.price_plant_code plant, right(convert(char(10),jsch.sched_date,103),7) forecastdate, jsch.qty forecastqty from prjp inner join cust on prjp.cust_code = cust.cust_code inner join proj on prjp.cust_code = proj.cust_code and prjp.proj_code = proj.proj_code inner join prjo on prjp.cust_code = prjo.cust_code and prjp.proj_code = prjo.proj_code inner join jprd on prjp.job_quote_unique_line_num = jprd.unique_line_num inner join jobs on jprd.job_id = jobs.job_id inner join jsch on jprd.job_id = jsch.job_id and jprd.unique_line_num = jsch.unique_line_num inner join imst on prjp.prod_code = imst.item_code  inner join icat on imst.item_cat = icat.item_cat where (imst.inactive_code != '02' or imst.inactive_code = '' or imst.inactive_code is null)
```

## View: dbo.YJOU

```sql

CREATE VIEW DBO.YJOU ASSELECT r.JOURNEY_DATE, r.JOURNEY_CODE, r.JOURNEY_PLANT_CODE, r.TRUCK_CODE AS JOUR_TRUCK_CODE, r.JOURNEY_STATUS, l.JOURNEY_INTRNL_LINE_NUM, l.JOURNEY_SEQ_CODE, l.TKT_DATE, l.TKT_CODE, l.LOAD_QTY, o.ORDER_DATE, o.ORDER_CODE, d.ORDER_INTRNL_LINE_NUM, d.PROD_CODE, d.PROD_DESCR, d.SHORT_PROD_DESCR, d.BATCH_CODEfrom jour rinner join joul lon r.journey_date = l.journey_dateand r.journey_code = l.journey_codeleft outer join ordr oon o.order_date = l.order_dateand o.order_code = l.order_codeinner join ordl don o.order_date = d.order_dateand o.order_code = d.order_codeand l.order_intrnl_line_num = d.order_intrnl_line_num
```

## View: dbo.yjqp

```sql

create view [dbo].[yjqp] asselect jprd.job_id, jprd.unique_line_num,  jprd.sort_line_num,  jprd.item_code,  jprd.price_plant_code,  jprd.prod_descr,  jprd.short_prod_descr,  jprd.est_qty,  jprd.price,  jprd.chrg_cart_code, jprd.pay_cart_code, jprd.rm_slump, jprd.usage_code,  jprd.pref_truck_type,  jprd.stat,  jprd.price_status, icat.item_type,  sum(qprd.est_qty) quot_est_qty from jprd left outer join qprd on  jprd.unique_line_num = qprd.unique_line_numINNER JOIN imst on jprd.item_code = imst.item_code INNER JOIN icat on imst.item_cat = icat.item_catgroup by jprd.job_id, jprd.unique_line_num,  jprd.sort_line_num,  jprd.item_code,  jprd.price_plant_code, jprd.prod_descr,  jprd.short_prod_descr,  jprd.est_qty,  jprd.price,  jprd.chrg_cart_code, jprd.pay_cart_code, jprd.rm_slump,  jprd.usage_code,  jprd.pref_truck_type,  jprd.stat,  jprd.price_status, icat.item_typeunion allselect jprd.job_id, jprd.unique_line_num,  jprd.sort_line_num,  jprd.item_code,  jprd.price_plant_code,  jprd.prod_descr,  jprd.short_prod_descr,  jprd.est_qty,  jprd.price,  jprd.chrg_cart_code, jprd.pay_cart_code, jprd.rm_slump, jprd.usage_code,  jprd.pref_truck_type,  jprd.stat,  jprd.price_status, icat.item_type,  sum(qprd.est_qty) quot_est_qty from jprd left outer join qprd on  jprd.unique_line_num = qprd.unique_line_numINNER JOIN icat on ltrim(rtrim(jprd.item_code)) = ltrim(rtrim(icat.item_cat))left outer join imst i on jprd.item_code = i.item_codewhere i.item_code is nullgroup by jprd.job_id, jprd.unique_line_num,  jprd.sort_line_num,  jprd.item_code,  jprd.price_plant_code, jprd.prod_descr,  jprd.short_prod_descr,  jprd.est_qty,  jprd.price,  jprd.chrg_cart_code, jprd.pay_cart_code, jprd.rm_slump,  jprd.usage_code,  jprd.pref_truck_type,  jprd.stat,  jprd.price_status, icat.item_type
```

## View: dbo.yjsc

```sql

create view [dbo].[yjsc] as select 'J' rec_type, jsch.job_id, jsch.item_code, jsch.price_plant_code, jsch.sched_date, jsch.qty, icat.item_type from jsch, imst, icat where jsch.item_code = imst.item_code and imst.item_cat = icat.item_cat and (inactive_code != '02' or inactive_code = '' or inactive_code is null)
```

## View: dbo.ylck

```sql

CREATE VIEW dbo.ylck ASSELECT CAST(a.request_session_id AS NUMERIC(12)) AS session_id, CAST(NULL AS NUMERIC(12)) AS serial, CAST(b.loginame AS VARCHAR(40)) AS db_login, CAST(db_name(resource_database_id) AS VARCHAR(50)) AS db_name, CAST(CASE request_mode WHEN 'Sch-M' THEN CAST(resource_associated_entity_id AS VARCHAR) ELSE CASE WHEN resource_type = 'object' THEN object_name(resource_associated_entity_id)ELSE object_name(d.object_id) END END AS VARCHAR(60)) AS [object_name], CAST(request_owner_type+'::'+resource_type AS VARCHAR(75)) AS rsc_type, CAST(request_mode+'::'+b.cmd AS VARCHAR(75)) AS req_mode, CAST(request_status+'::'+b.status AS VARCHAR(75)) AS req_status, CAST(b.blocked AS NUMERIC(12)) AS blocked_by, CAST(b.open_tran AS NUMERIC(4)) AS open_tran, CAST(b.nt_username AS VARCHAR(200)) AS os_user_name, CAST(b.hostprocess AS VARCHAR(20)) AS process_id, CAST(b.hostname AS VARCHAR(64)) AS host_name, CAST(c.client_net_address AS VARCHAR(30)) AS client_ip, CAST(b.program_name AS VARCHAR(1000)) AS program FROM sys.dm_tran_locks a  inner join sys.sysprocesses b ON a.request_session_id = b.spid left outer join sys.dm_exec_connections c ON a.request_session_id = c.session_id left outer join sys.partitions d ON d.hobt_id = a.resource_associated_entity_id left outer join sys.indexes e ON e.object_id = d.object_id AND e.index_id = d.index_idWHERE resource_database_id = db_id() AND resource_associated_entity_id > 0 AND resource_type IS NOT NULL AND resource_type <> 'DATABASE' AND request_mode IS NOT NULL  AND request_mode NOT IN ('Sch-S','IS')
```

## View: dbo.ylck1

```sql

CREATE VIEW dbo.ylck1 ASSELECT * FROM dbo.ylck  WHERE NOT EXISTS (SELECT 1 FROM lckr WHERE sid = session_id  AND db_login collate database_default = db_login collate database_default  AND pid collate database_default = process_id collate database_default AND host collate database_default = host_name collate database_default AND ip collate database_default = client_ip collate database_default)
```

## View: dbo.ymca

```sql

create view [dbo].[ymca] as select icst.item_code, icst.const_item_code, icst.loc_code, icst.qty_uom, icst.qty, imst.invy_uom const_invy_uom, imst2.invy_uom mix_invy_uom, iloc.cost_ext_code const_cost_ext_code, iloc.prev_cost_ext_code const_prev_cost_ext_code, iloc.curr_std_cost const_curr_std_cost, iloc.prev_std_cost const_prev_std_cost, iloc.std_cost_effect_date const_std_cost_effect_date, iloc2.cost_ext_code mix_cost_ext_code, iloc2.prev_cost_ext_code mix_prev_cost_ext_code, iloc2.curr_std_cost mix_curr_std_cost, iloc2.prev_std_cost mix_prev_std_cost, iloc2.std_cost_effect_date mix_std_cost_effect_date from  imst, icst, imst as imst2, iloc, iloc as iloc2 where  imst.item_code = icst.const_item_code and iloc.item_code = icst.const_item_code and iloc.loc_code = icst.loc_code and imst2.item_code = icst.item_code and iloc2.item_code = icst.item_code and iloc2.loc_code = icst.loc_code and (imst.inactive_code != '02' or imst.inactive_code = '' or imst.inactive_code is null) and (imst2.inactive_code != '02' or imst2.inactive_code = '' or imst2.inactive_code is null) and (iloc.inactive_code != '02' or iloc.inactive_code = '' or iloc.inactive_code is null) and (iloc2.inactive_code != '02' or iloc2.inactive_code = '' or iloc2.inactive_code is null)
```

## View: dbo.YMCH

```sql

CREATE VIEW [dbo].[YMCH](QUOTE_CODE, REV_NUM, ID, PRICE_PER_QTY, LOAD_SIZE,  COMP_CODE, PLANT_CODE)AS SELECT quot.quote_code, quot.rev_num,  mchr.min_load_chrg_table_id, mchr.price_per_qty, mchr.load_size, 'COMP_CODE' = CASE mchr.comp_code  WHEN '#' THEN 'All' ELSE mchr.comp_code END, 'PLANT_CODE' = CASE mchr.plant_code  WHEN '#' THEN 'All' ELSE mchr.plant_code ENDFROM mchr INNER JOIN quot ON mchr.min_load_chrg_table_id = quot.cc_min_load_chrg_table_id LEFT OUTER JOIN mchg ON  mchr.min_load_chrg_table_id = mchg.min_load_chrg_table_idINNER JOIN plnt ON plnt.plant_code = quot.cc_price_plant_codeINNER JOIN comp ON comp.comp_code = plnt.comp_codeWHERE (mchr.comp_code = comp.comp_code OR mchr.comp_code = '#') AND (mchr.plant_code = plnt.plant_code OR mchr.plant_code = '#')
```

## View: dbo.YMCT

```sql

CREATE VIEW [dbo].[YMCT](QUOTE_CODE, REV_NUM, ID, SHORT_DESCR, DESCR,PROD_CODE, MIN_QTY, NUM_FREE_LOADS, MIN_LOADS, UOM_DESCR, COMP_CODE, PLANT_CODE)AS SELECT quot.quote_code, quot.rev_num,  mchg.min_load_chrg_table_id, mchg.short_descr, mchg.descr, mchc.prod_code, mchc.min_qty, mchc.num_free_loads, mchc.min_loads, u1.short_descr, 'COMP_CODE' = CASE mchc.comp_code  WHEN '#' THEN 'All' ELSE mchc.comp_code END, 'PLANT_CODE' = CASE mchc.plant_code  WHEN '#' THEN 'All' ELSE mchc.plant_code ENDFROM mchC INNER JOIN quot ON  mchc.min_load_chrg_table_id = quot.cc_min_load_chrg_table_id LEFT OUTER JOIN mchg ON  mchc.min_load_chrg_table_id = mchg.min_load_chrg_table_idLEFT OUTER JOIN uoms as u1 on mchc.price_uom = u1.uomINNER JOIN plnt ON plnt.plant_code = quot.cc_price_plant_codeINNER JOIN comp ON comp.comp_code = plnt.comp_codeWHERE (mchc.comp_code = comp.comp_code OR mchc.comp_code = '#') AND (mchc.plant_code = plnt.plant_code OR mchc.plant_code = '#')
```

## View: dbo.ymix

```sql

CREATE VIEW [dbo].[ymix]ASSELECT DISTINCT i.item_code AS imst_item_code,i.descr AS imst_descr, i.water_cem_ratio AS imst_water_cem_ratio,i.strgth,i.qc_note, i.item_cat,i.slump,i.agg_size,i.sort_code,i.min_cem_cont, i.min_cem_override_flag, u.uom,u.abbr AS uoms_abbr,u.imperial_flag, l.loc_code AS iloc_loc_code, l.water_cem_ratio AS iloc_water_cem_ratio, l.cem_content,l.cemnt_content, s.const_item_code AS icst_const_item_code FROM dbo.imst AS i INNER JOIN dbo.uoms AS u ON i.batch_uom = u.uom INNER JOIN dbo.icat AS c ON i.item_cat = c.item_cat LEFT OUTER JOIN dbo.iloc AS l ON i.item_code = l.item_code LEFT OUTER JOIN dbo.icst AS s ON l.item_code = s.item_code AND l.loc_code = s.loc_code WHERE ( i.const_substitution_flag = 1 and (i.inactive_code != '02' or i.inactive_code = '' or i.inactive_code is null) AND c.item_type = '01' AND l.loc_code IS NOT NULL  and (l.inactive_code != '02' or l.inactive_code = '' or l.inactive_code is null)  )
```

## View: dbo.ymlc

```sql

create view [dbo].[ymlc] asselectmchc.min_load_chrg_table_id,mchc.comp_code,mchc.plant_code,mchg.descr,mchg.short_descr,mchc.Prod_code,mchc.min_qty,mchc.min_loads,mchc.num_free_loads,mchc.price_uom,mchc.incl_min_load_chrg_code,mchc.calc_meth_code,mchc.rate_meth_code,mchc.bas_qty_code,mchc.min_load_qty_code,mchc.cart_code,mchc.base_qty,mchc.per_unit_rate,mchc.zero_amount_print_codefrom mchc, mchgwhere mchc.min_load_chrg_table_id = mchg.min_load_chrg_table_id
```

## View: dbo.ymta

```sql

create view [dbo].[ymta] asselect o.cust_code,  o.proj_code,  sum(l.delv_qty) as shipped_qty, l.price_uomfrom ordr o left outer join ordl as l on l.order_code = o.order_code and  l.order_date = o.order_date  where l.price_uom = '60003' or l.price_uom = '60013' and  o.remove_rsn_code is null and  o.proj_code is not null and  o.order_date >= DATEADD(month, -1, DATEADD(month, DATEDIFF(month, 0, CURRENT_TIMESTAMP), 0)) and o.order_date < DATEADD(month, DATEDIFF(month, 0, CURRENT_TIMESTAMP), 0) and o.order_type != '5' and o.order_type != '6' and o.order_type != '7'group by cust_code, proj_code, price_uom
```

## View: dbo.ymtc

```sql

create view [dbo].[ymtc] asselect o.cust_code, o.proj_code, sum(l.delv_qty) as shipped_qtyfrom ordr oleft outer join ordl as l on l.order_code = o.order_code and l.order_date = o.order_date where l.rm_mix_flag = '1' and o.remove_rsn_code is null and o.proj_code is not null and o.order_date >= DATEADD(month, -1, DATEADD(month, DATEDIFF(month, 0, CURRENT_TIMESTAMP), 0)) and o.order_date < DATEADD(month, DATEDIFF(month, 0, CURRENT_TIMESTAMP), 0) and o.order_type != '5' and o.order_type != '6' and o.order_type != '7'group by cust_code, proj_code
```

## View: dbo.ymtk

```sql

CREATE VIEW DBO.ymtk AS SELECT i.loc_code, m.item_code, m.descr, m.short_descr, m.invy_flag, m.taxble_code, m.tax_rate_code, m.usage_code, m.non_tax_rsn_code, m.item_cat, m.matl_type, m.invy_item_code, m.order_uom, m.price_uom, m.invy_uom, m.purch_uom, m.batch_uom,  m.terms_disc_flag, m.trade_disc_flag, m.expir_date, m.resale_flag, m.cust_code, m.proj_code, m.order_qty_ext_code, m.order_dosage_qty, m.order_dosage_qty_uom, m.price_qty_ext_code, m.tkt_qty_ext_code, m.delv_uom, m.batch_code, m.do_not_allow_tkting_flag, i.mobileticket_code, i.item_status_code, c.item_type, m.guid, m.update_date FROM imst m inner join iloc i ON m.item_code = i.item_code AND i.mobileticket_code = '01' inner join icat c ON m.item_cat = c.item_cat WHERE (c.item_type != '01' AND c.item_type != '02' AND c.item_type != '06' AND c.item_type != '07' AND c.item_type != '08' AND c.item_type != '11' AND c.item_type != '12' AND c.item_type != '27') AND (m.do_not_allow_tkting_flag IS null OR m.do_not_allow_tkting_flag = 0) AND (m.resale_flag = 1) AND (m.inactive_code != '02' or m.inactive_code = '' or m.inactive_code is null) AND (i.inactive_code != '02' or i.inactive_code = '' or i.inactive_code is null)
```

## View: dbo.ymzm

```sql

CREATE VIEW dbo.ymzm ASSELECT  p.map_page, p.zone_code, z.descr as zone_descr, z.short_descr as zone_short_descr, z.tax_code, z.price_adj_uom, z.sched_plant_code, z.sundry_chrg_table_id, m.descr as map_descr, m.short_descr as map_short_descr, m.map_upper_left_long, m.map_upper_left_lat, m.map_lower_right_long, m.map_lower_right_lat, m.map_radius FROM mapz p  left outer join zone z on p.zone_code = z.zone_code left outer join maps m on p.map_page = m.map_page
```

## View: dbo.yoal

```sql

create view [dbo].[yoal] as select ordr.cust_code customercode, ordr.proj_code projectcode, ordl.prod_code productcode, ordl.proj_line_num iln, tick.ship_plant_code plant, right(convert(char(10),tktl.order_date,103),7) deliverydate, sum(tktl.cstmry_price_qty) priceqty from ordr inner join ordl on ordr.order_date = ordl.order_date and ordr.order_code = ordl.order_code inner join tick on ordl.order_date = tick.order_date and ordl.order_code = tick.order_code inner join tktl on ordl.order_date = tktl.order_date and ordl.order_code = tktl.order_code and tick.tkt_code = tktl.tkt_code and ordl.order_intrnl_line_num = tktl.order_intrnl_line_num group by ordr.cust_code, ordr.proj_code, ordl.prod_code, ordl.proj_line_num, tick.ship_plant_code, tktl.order_date
```

## View: dbo.yopj

```sql

create view [dbo].[yopj] (order_date, order_code, proj_code, order_type, prod_line_code, remove_rsn_code, susp_rsn_code, cust_code, acct_cat_code, ca_terms_code, cb_terms_code, cc_terms_code, cd_terms_code, invc_freq_code, invc_grouping_code, invc_sub_grouping_code, invc_det_sum_code, invc_single_mult_day_code, invc_comb_haul_flag, invc_sep_by_prod_line_flag, invc_postcd) as select a.order_date, a.order_code, a.proj_code, a.order_type, a.prod_line_code, a.remove_rsn_code, a.susp_rsn_code, a.cust_code, b.acct_cat_code, b.ca_terms_code, b.cb_terms_code, b.cc_terms_code, b.cd_terms_code, b.invc_freq_code, b.invc_grouping_code, b.invc_sub_grouping_code, b.invc_det_sum_code, b.invc_single_mult_day_code, b.invc_comb_haul_flag, b.invc_sep_by_prod_line_flag, b.invc_postcd from ordr a, proj b where a.cust_code = b.cust_code and a.proj_code = b.proj_code
```

## View: dbo.yopl

```sql

create view [dbo].[yopl] (order_date, order_code, plant_code, order_type, prod_line_code, remove_rsn_code, susp_rsn_code, comp_code, next_invc_seq, terms_code, loc_code) as select a.order_date, a.order_code, b.plant_code, a.order_type, a.prod_line_code, a.remove_rsn_code, a.susp_rsn_code, b.comp_code, b.next_invc_seq, b.terms_code, b.loc_code from ordr a, plnt b where a.price_plant_code = b.plant_code
```

## View: dbo.yopr

```sql

create view [dbo].[yopr] as select convert(char(2),'OR') order_type, a.order_date, a.order_code, a.cust_code, a.prod_line_code, a.remove_rsn_code, a.order_type order_type2, a.proj_code, a.sampling_lab_code, a.cust_job_num, b.prod_cat, b.prod_code, b.short_prod_descr, b.proj_line_num, b.rm_mix_flag, b.delv_qty, b.delv_qty_uom, b.order_qty, b.order_qty_uom, b.exclude_from_sample_sched_rpt, b.additional_samples, b.apply_to_contract, c.plant_code, c.sched_qty, (select sum(load_size) from schl  where schl.order_date = a.order_date  and schl.order_code = a.order_code  and schl.ORDER_INTRNL_LINE_NUM = b.ORDER_INTRNL_LINE_NUM and schl.sched_num = c.sched_num and schl.tkt_code not like '% ' and schl.tkt_code is not null and schl.tkt_code <> '########') sched_delv_qty, a.stat, cast(a.delv_addr as varchar(4000)) delv_addr, b.price_qty, c.priority, (select count(load_num) from schl  where schl.order_date = a.order_date  and schl.order_code = a.order_code  and schl.ORDER_INTRNL_LINE_NUM = b.ORDER_INTRNL_LINE_NUM and schl.load_size > 0) num_loads, b.price_uom from ordr a,  ordl b LEFT OUTER JOIN schd c ON b.order_code = c.order_code and b.order_date = c.order_date and b.order_intrnl_line_num = c.order_intrnl_line_num  where a.order_code = b.order_code and a.order_date = b.order_date union all select convert(char(2),'ST') order_type, convert (char(1),' ') order_date, d.order_code, d.cust_code, d.prod_line_code, d.remove_rsn_code, d.order_type order_type2, d.proj_code, NULL sampling_lab_code2, d.cust_job_num, e.prod_cat, e.prod_code, e.short_prod_descr, e.proj_line_num, e.rm_mix_flag, e.delv_qty, e.delv_qty_uom, e.order_qty,null, e.order_qty_uom, NULL, NULL, NULL, cast(null as numeric), cast(null as numeric), d.stat, cast(d.delv_addr as varchar(4000)) delv_addr, e.price_qty, NULL, NULL, NULL from stor d, stol e where d.order_code = e.order_code
```

## View: dbo.yorx

```sql

create view [dbo].[yorx] as select ordr.order_date, ordr.order_code, ordl.order_intrnl_line_num, ordr.order_type, ordr.prod_line_code, ordr.stat order_stat, ordr.cust_code, ordr.ship_cust_code, ordr.ref_cust_code, ordr.cust_name, ordr.cust_sort_name, ordr.proj_code, proj.proj_name, ordr.zone_code, ordr.lot_block, ordr.cust_job_num, ordr.po, ordr.comp_code, comp.short_name comp_short_name, ordr.susp_rsn_code, ordr.susp_user_name, ordr.susp_date_time, ordr.susp_cancel_date_time, ordr.susp_cancel_user_name, ordr.remove_rsn_code, rsnc.short_descr remove_rsn_short_descr, ordr.pkt_num, ordr.curr_load_num order_curr_load_num, ordr.cod_order_amt, ordr.quote_code, ordr.map_page, ordr.delv_meth_code, ordr.expir_date, ordr.job_phase, ordr.job_code, ordr.ship_to_plant_code, ordr.pmt_acct_bank_name, ordr.pmt_acct_check_num, ordr.pmt_acct_exp_date, ordr.pmt_acct_name, ordr.pmt_auth_code, ordr.pmt_meth, ordr.pmt_check_num, ordr.pmt_acct_num, ordr.ship_addr_line, ordr.ship_city, ordr.ship_state, ordr.ship_cntry, ordr.ship_postcd, ordr.modified_date, ordr.update_date, ordr.priority order_priority, ordl.prod_code, ordl.prod_descr, ordl.short_prod_descr, ordl.dflt_load_qty, ordl.order_dosage_qty, ordl.order_qty, ordl.orig_order_qty, ordl.delv_qty, ordl.rm_slump, ordl.usage_code, usge.short_descr usage_short_descr, ordl.curr_load_num order_line_curr_load_num, ordl.mix_design_user_name, ordl.mix_design_update_date, ordl.qc_approvl_flag, ordl.qc_approvl_date, ordl.batch_code, schd.sched_num, schd.plant_code sched_plant_code, schd.sched_qty, schd.sched_hold_qty, schd.max_qty, schd.truck_type, schd.load_size, schd.start_time, schd.trvl_time, schd.truck_spacing_mins, schd.unld_mins_per_load, schd.qty_per_hour, schd.trucks_req, schd.loads, schd.stat sched_stat, schd.pour_meth_code, schd.priority sched_priority, icat.item_type, ordl.dflt_load_qty_uom, ordl.delv_qty_uom, ordl.rm_mix_flag, ordr.metric_cstmry_code, ordr.delv_addr from ordr left outer join proj on ordr.cust_code = proj.cust_code  and ordr.proj_code = proj.proj_code inner join comp on ordr.comp_code = comp.comp_code left outer join rsnc on ordr.remove_rsn_code = rsnc.rsn_code inner join ordl on ordr.order_date = ordl.order_date  and ordr.order_code = ordl.order_code left outer join usge on ordl.usage_code = usge.usage_code left outer join schd on ordl.order_date = schd.order_date and ordl.order_code = schd.order_code and ordl.order_intrnl_line_num = schd.order_intrnl_line_num left outer join icat on ordl.prod_cat = icat.item_cat
```

## View: dbo.yote

```sql

CREATE VIEW [dbo].[yote] AS SELECT ordr.order_date, ordr.order_code,cast('#' as char(8)) as tkt_code, ordl.order_intrnl_line_num, ordr.order_date as tkt_date, ordr.order_type,ordr.prod_line_code, ordr.stat, ordr.cust_code, ordr.ship_cust_code,ordr.ref_cust_code,ordr.cust_name,ordr.cust_sort_name,ordr.proj_code,proj.proj_name,ordr.zone_code,ordr.lot_block, ordr.cust_job_num,ordr.po,ordr.taken_by_empl_code,ordr.taken_on_phone_line_num,ordr.order_by_name,ordr.order_by_phone_num,ordr.apply_min_load_chrg_flag,ordr.apply_zone_chrg_flag,ordr.apply_excess_unld_chrg_flag,ordr.apply_season_chrg_flag,ordr.rm_print_mix_wgts_flag,ordr.price_plant_code,ordr.price_plant_loc_code,ordr.comp_code,ordr.hler_code,ordr.min_load_chrg_table_id,ordr.excess_unld_chrg_table_id,ordr.season_chrg_table_id,ordr.min_load_sep_invc_flag,ordr.excess_unld_sep_invc_flag,ordr.season_sep_invc_flag, ordr.sales_anl_code,ordr.slsmn_empl_code,ordr.taxble_code,ordr.tax_code,ordr.non_tax_rsn_code,ordr.susp_rsn_code,ordr.susp_user_name,ordr.susp_date_time,ordr.susp_cancel_date_time,ordr.susp_cancel_user_name,ordr.remove_rsn_code,ordr.memo_rsn_code,ordr.pkt_num,ordr.track_order_color,ordr.intrnl_line_num,ordr.curr_load_num,ordr.cod_order_amt,cast('' as char(12)) as invc_code, ordr.setup_date,ordr.quote_code,ordr.map_page,ordr.cred_over_user_name,ordr.cred_over_auth_code,ordr.cred_limtn_code,ordr.est_order_amt,ordr.delv_meth_code,ordr.expir_date,ordr.exceed_qty_flag,ordr.clear_daily_flag,ordr.cart_code,ordr.cart_rate_amt,ordr.apply_cart_rate_hler_flag,ordr.apply_min_haul_flag,ordr.map_long,ordr.map_lat,ordr.map_radius,ordr.alt_scale_printer_flag,ordr.metric_cstmry_code,ordr.invy_adjust_code,ordr.sales_anl_adjust_code,ordr.mix_design_user_name,ordr.mix_design_update_date,ordr.qc_approvl_flag,ordr.qc_approvl_date,ordr.job_phase,ordr.start_time,ordr.scale_use_order_flag,ordr.job_code,ordr.phase_code,ordr.ship_to_plant_code,ordr.pmt_acct_bank_name,ordr.pmt_acct_check_num,ordr.pmt_acct_exp_date,ordr.pmt_acct_name,ordr.pmt_amt,ordr.pmt_auth_code,ordr.pmt_meth,ordr.pmt_check_num,ordr.pmt_acct_num,ordr.ship_addr_line,ordr.ship_city,ordr.ship_state,ordr.ship_cntry,ordr.ship_postcd,ordr.pay_cart_code,ordr.pay_cart_rate_amt,ordr.priority,ordr.quote_rev_num,ordr.modified_date,ordr.dataout_date,ordr.copy_from_order_code,ordr.copy_from_order_date,ordr.time_analysis_flag,ordr.pmt_form_code,ordr.map_updt_ordr_coord_flag,ordr.map_truck_poll_type,ordr.first_truck_polled_flag,ordr.cred_debit_memo_comment,cast(NULL as numeric(5,0)) as load_num,cast('' as char(8)) as truck_code,cast('' as char(3)) as ship_plant_code,cast(null as numeric(10,2)) as resold_qty,ordl.prod_code,ordl.prod_descr,ordl.price,ordl.order_qty,ordl.delv_qty,ordl.dflt_load_qty,ordl.rm_slump,empl.name as [name],uoms.short_descr,cast(NULL as datetime) as reused_order_date,cast('' as char(12)) as reused_order_code,cast('' as char(8)) as resold_tkt_code,cast(NULL as numeric(16,0)) as tkt_delv_qty, cast('' as datetime) as invc_date,ordr.update_date from ordr inner join ordl on ordr.order_date = ordl.order_date and ordr.order_code = ordl.order_code left outer join proj on ordr.cust_code = proj.cust_code and ordr.proj_code = proj.proj_code left outer join empl on ordr.slsmn_empl_code = empl.empl_code inner join uoms on uoms.uom = ordl.delv_qty_uom where ((ordr.curr_load_num is NULL and ordr.cod_order_amt is NULL) or ((ordl.price_qty is NULL or ordl.price_qty = 0) and (ordl.delv_qty is NULL or ordl.delv_qty = 0))) UNION select ordr.order_date,ordr.order_code,ISNULL(tick.tkt_code,'#') as tkt_code,ordl.order_intrnl_line_num,tick.tkt_date,ordr.order_type,ordr.prod_line_code,ordr.stat,ordr.cust_code,ordr.ship_cust_code,ordr.ref_cust_code,ordr.cust_name,ordr.cust_sort_name,ordr.proj_code,proj.proj_name,ordr.zone_code,ordr.lot_block,ordr.cust_job_num,ordr.po,ordr.taken_by_empl_code,ordr.taken_on_phone_line_num,ordr.order_by_name,ordr.order_by_phone_num,ordr.apply_min_load_chrg_flag,ordr.apply_zone_chrg_flag,ordr.apply_excess_unld_chrg_flag,ordr.apply_season_chrg_flag,ordr.rm_print_mix_wgts_flag,ordr.price_plant_code,ordr.price_plant_loc_code,ordr.comp_code,ordr.hler_code,ordr.min_load_chrg_table_id,ordr.excess_unld_chrg_table_id,ordr.season_chrg_table_id,ordr.min_load_sep_invc_flag,ordr.excess_unld_sep_invc_flag,ordr.season_sep_invc_flag,ordr.sales_anl_code,ordr.slsmn_empl_code,ordr.taxble_code,ordr.tax_code,ordr.non_tax_rsn_code,ordr.susp_rsn_code,ordr.susp_user_name,ordr.susp_date_time,ordr.susp_cancel_date_time,ordr.susp_cancel_user_name,ordr.remove_rsn_code,ordr.memo_rsn_code,ordr.pkt_num,ordr.track_order_color,ordr.intrnl_line_num,ordr.curr_load_num,ordr.cod_order_amt,tick.invc_code,ordr.setup_date,ordr.quote_code,ordr.map_page,ordr.cred_over_user_name,ordr.cred_over_auth_code,ordr.cred_limtn_code,ordr.est_order_amt,ordr.delv_meth_code,ordr.expir_date,ordr.exceed_qty_flag,ordr.clear_daily_flag,ordr.cart_code,ordr.cart_rate_amt,ordr.apply_cart_rate_hler_flag,ordr.apply_min_haul_flag,ordr.map_long,ordr.map_lat,ordr.map_radius,ordr.alt_scale_printer_flag,ordr.metric_cstmry_code,ordr.invy_adjust_code,ordr.sales_anl_adjust_code,ordr.mix_design_user_name,ordr.mix_design_update_date,ordr.qc_approvl_flag,ordr.qc_approvl_date,ordr.job_phase,ordr.start_time,ordr.scale_use_order_flag,ordr.job_code,ordr.phase_code,ordr.ship_to_plant_code,ordr.pmt_acct_bank_name,ordr.pmt_acct_check_num,ordr.pmt_acct_exp_date,ordr.pmt_acct_name,ordr.pmt_amt,ordr.pmt_auth_code,ordr.pmt_meth,ordr.pmt_check_num,ordr.pmt_acct_num,ordr.ship_addr_line,ordr.ship_city,ordr.ship_state,ordr.ship_cntry,ordr.ship_postcd,ordr.pay_cart_code,ordr.pay_cart_rate_amt,ordr.priority,ordr.quote_rev_num,ordr.modified_date,ordr.dataout_date,ordr.copy_from_order_code,ordr.copy_from_order_date,ordr.time_analysis_flag,ordr.pmt_form_code,ordr.map_updt_ordr_coord_flag,ordr.map_truck_poll_type,ordr.first_truck_polled_flag,ordr.cred_debit_memo_comment,tick.load_num,tick.truck_code,tick.ship_plant_code,tktl.resold_qty,ordl.prod_code,ordl.prod_descr,ordl.price,ordl.order_qty,ordl.delv_qty,ordl.dflt_load_qty,ordl.rm_slump,empl.name,uoms.short_descr,tktl.reused_order_date,tktl.reused_order_code,tktl.resold_tkt_code, tktl.delv_qty as tkt_delv_qty,tick.invc_date,ordr.update_date from ordr inner join ordl on ordr.order_date = ordl.order_date and ordr.order_code = ordl.order_code inner join tick on ordr.order_date = tick.order_date and ordr.order_code = tick.order_code inner join tktl on tick.tkt_code = tktl.tkt_code and ordr.order_date = tktl.order_date and ordr.order_code = tktl.order_code and ordl.order_intrnl_line_num = tktl.order_intrnl_line_num inner join uoms on uoms.uom = ordl.delv_qty_uom left outer join proj on ordr.cust_code = proj.cust_code and ordr.proj_code = proj.proj_code left outer join empl on tick.driv_empl_code = empl.empl_code
```

## View: dbo.ypaf

```sql

create view [dbo].[ypaf] as select ypft.customercode, ypft.customername, ypft.customer, ypft.projectcode, ypft.projectname, ypft.project, ypft.projectbegindate, ypft.iln, ypft.productcode, ypft.productdescr, ypft.product, 'application' = case when ypft.itemtype = '01' then 'Concrete' when ypft.itemtype in ('04','24','25') then 'Aggregate' when ypft.itemtype = '02' then 'Asphalt' else 'Other' end, ypft.itemtype, ypft.forecastdate, ypft.plant, ypft.forecastqty, yoal.priceqty from ypft left outer join yoal on ypft.customercode = yoal.customercode and ypft.projectcode = yoal.projectcode and ypft.iln = yoal.iln and ypft.forecastdate = yoal.deliverydate and ypft.plant = yoal.plant
```

## View: dbo.ypch

```sql

create view [dbo].[ypch] asselectpchc.sundry_chrg_table_id,pchc.comp_code,pchc.plant_code,pchg.descr,pchg.short_descr,pchc.prod_code,pchc.chrg_type,pchc.target_uom,pchc.time_to_use,pchc.first_load_flag,pchg.auto_chrg_flag,pchg.ca_apply_auto_chrg_flag,pchg.cb_apply_auto_chrg_flag,pchg.cc_apply_auto_chrg_flag,pchg.cd_apply_auto_chrg_flag,pchc.from_date,pchc.thru_date,pchc.comb_matl_price_code,pchc.apply_min_chrg_item,pchc.delv_meth_code,pchc.apply_item_cat,pchg.sep_invc_flag,pchg.apply_to_zone_flagfrom pchg, pchcwhere pchc.sundry_chrg_table_id = pchg.sundry_chrg_table_id
```

## View: dbo.YPCN

```sql

CREATE VIEW DBO.YPCN AS SELECT proj.cust_code, proj.proj_code, pcon.contct_code, proj.proj_name, proj.sort_name, proj.contct_name, proj.ship_name, proj.ship_cust_code, proj.ship_addr_line_1, proj.ship_addr_line_2, proj.ship_city, proj.ship_state, proj.ship_cntry, proj.ship_postcd, proj.phone_num_1, proj.phone_num_2, proj.phone_num_3, pcon.contct_type, pcon.primary_flag, ctct.name AS contact_name, ctct.addr_line_1 as contact_addr_line_1, ctct.addr_line_2 as contact_addr_line_2, ctct.addr_city as contact_addr_city, ctct.addr_state as contact_addr_state, ctct.addr_cntry as contact_addr_cntry, ctct.addr_postcd as contact_addr_postcd, ctct.phone_num_1 as contact_phone_num_1, ctct.phone_num_2 as contact_phone_num_2, ctct.phone_num_3 as contact_phone_num_3, ctct.phone_num_4 as contact_phone_num_4, ctct.email_addr, ctct.email_addr_2, ctct.email_addr_3, ctct.email_addr_mobile, ctct.cust_code AS contact_cust_code, ctct.comp_name, ctct.title, ctct.inactive_flag FROM proj inner join pcon ON proj.cust_code = pcon.cust_code AND proj.proj_code = pcon.proj_code inner join ctct ON pcon.contct_code = ctct.contct_code
```

## View: dbo.ypft

```sql

create view [dbo].[ypft] as select prjp.cust_code customercode, cust.name customername,ltrim(prjp.cust_code + ' ' + substring(cust.name,1,20)) customer, prjp.proj_code projectcode, proj.proj_name projectname, ltrim(prjp.proj_code+' '+substring(proj.proj_name,1,20)) project, convert(char(10),prjo.begin_date,101) projectbegindate, prjp.prod_code productcode, prjp.short_prod_descr productdescr, ltrim(prjp.prod_code+' '+prjp.short_prod_descr) product, icat.item_type itemtype, prjp.intrnl_line_num iln, psch.price_plant_code plant, right(convert(char(10),psch.sched_date,103),7) forecastdate, psch.qty forecastqtyfrom prjp  left outer join psch on prjp.cust_code = psch.cust_code and prjp.proj_code = psch.proj_code and prjp.intrnl_line_num = psch.intrnl_line_num inner join cust on prjp.cust_code = cust.cust_code inner join proj on prjp.cust_code = proj.cust_code and prjp.proj_code = proj.proj_code inner join prjo on prjp.cust_code = prjo.cust_code and prjp.proj_code = prjo.proj_code inner join imst on prjp.prod_code = imst.item_code  inner join icat on imst.item_cat = icat.item_cat where (imst.inactive_code != '02' or imst.inactive_code = '' or imst.inactive_code is null)
```

## View: dbo.yplt

```sql

create view [dbo].[yplt] asselect t.invc_code, t.invc_date, t.order_date, t.order_code, t.tkt_code, t.ship_plant_code, t.tkt_date, o.price_plant_code, p.name as ship_plant_name, p.short_name as ship_short_name, p.comp_code as ship_comp_code, p.loc_code as ship_loc_codefrom tick t left outer join ordr o on t.order_date = o.order_date and t.order_code = o.order_code left outer join plnt p on t.ship_plant_code = p.plant_code
```

## View: dbo.ypqu

```sql

create view [dbo].[ypqu] as select * from yprj union select * from yquo
```

## View: dbo.yprj

```sql

create view [dbo].[yprj] as select 'P' rec_type, a.proj_code, a.quote_code, a.ship_cust_code cust_code, b.sort_name, b.name cust_name, a.ship_addr_line_1 addr_line, a.proj_name, c.quote_rev_num rev_num, a.expir_date, a.po, a.cust_job_num, cast(delv_addr as varchar(2000)) delv_addr from proj a, cust b, prjo c where b.cust_code = a.ship_cust_code and	c.proj_code = a.proj_code and c.cust_code = a.cust_code and (a.inactive_code != '02' or a.inactive_code = '' or a.inactive_code is null) and (b.inactive_code != '02' or b.inactive_code = '' or b.inactive_code is null)
```

## View: dbo.YPRM

```sql

CREATE VIEW [dbo].[YPRM]ASSELECT p.cust_code,p.proj_code, p.intrnl_line_num, p.sort_line_num,p.prod_code,p.batch_code, IsNull(p.prod_descr,i.descr) AS Prod_Descr,IsNull(p.short_prod_descr,i.short_descr) AS Short_Prod_Descr, p.est_qty,p.rm_slump,p.rm_slump_uom,p.usage_code, p.price_uom, p.price, p.price_ext_code, p.price_plant_code, p.price_expir_date, p.effect_date, p.prev_price, p.prev_price_ext_code, p.delv_price_flag, p.dflt_load_qty, p.order_qty_uom, p.order_qty_ext_code, p.order_dosage_qty, p.order_dosage_qty_uom, p.delv_qty_uom, p.price_qty_ext_code, p.tkt_qty_ext_code, p.mix_type, j.item_type, p.quote_code, p.allow_price_adjust_flag, p.sep_invc_flag, p.override_terms_disc_flag, p.disc_rate_type, p.disc_amt, p.disc_amt_uom, p.content_up_price, p.content_down_price, p.content_up_price_effect_date, p.content_down_price_effect_date, p.prev_content_up_price, p.prev_content_down_price, p.ca_chrg_cart_code, p.cb_chrg_cart_code,p.cc_chrg_cart_code, p.cd_chrg_cart_code,p.job_quote_unique_line_num, p.pour_meth_code, p.ca_truck_type, p.cb_truck_type, p.cc_truck_type, p.cd_truck_type, p.ca_chrg_cart_rate, p.cb_chrg_cart_rate, p.cc_chrg_cart_rate, p.cd_chrg_cart_rate, p.quote_rev_num, p.modified_date, p.type_price, p.matl_price, p.auto_prod_flag, p.item_cat_price_flag, p.auth_user_name, p.price_status, p.unique_line_num,u.descr as usage_descr,u.short_descr as usage_short_descr, i.legacy_item_code,p.update_date, p.u_version,p.ca_sur_codes, p.cb_sur_codes, p.cc_sur_codes, p.cd_sur_codes, p.ca_sur_rates, p.cb_sur_rates, p.cc_sur_rates, p.cd_sur_rates, p.ca_sundry_chrg_table_ids, p.cb_sundry_chrg_table_ids, p.cc_sundry_chrg_table_ids, p.cd_sundry_chrg_table_ids, p.ca_sundry_chrg_sep_invc_flags,p.cb_sundry_chrg_sep_invc_flags,p.cc_sundry_chrg_sep_invc_flags,p.cd_sundry_chrg_sep_invc_flagsfrom PROJ r, PRJP p left outer join IMST i on p.prod_code = i.item_code left outer join ICAT j on j.item_cat = i.item_catleft outer join USGE u on p.usage_code = u.usage_codewhere p.cust_code = r.cust_code and p.proj_code = r.proj_code and (r.inactive_code != '02' or r.inactive_code = '' or r.inactive_code is null)
```

## View: dbo.ypur

```sql

create view [dbo].[ypur] asselect  proj.proj_code, proj.cust_code, ordr.order_date, ordr.order_code, tick.invc_code, tick.tkt_code, tick.tkt_date from ordr right outer join proj on ordr.cust_code = proj.cust_code and ordr.proj_code = proj.proj_code, tick where  ordr.order_date = tick.order_date and ordr.order_code = tick.order_code and tick.remove_rsn_code is NULL
```

## View: dbo.yqca

```sql

create view [dbo].[yqca] asselect quote_code, rev_num, sum(est_qty) CA_Estfrom yqprwhere item_type = '02' or item_type = '04' or item_type = '24'group by quote_code, rev_num
```

## View: dbo.yqcc

```sql

create view [dbo].[yqcc] asselect quote_code, rev_num, sum(est_qty) CC_Estfrom yqprwhere item_type = '01'group by quote_code, rev_num
```

## View: dbo.YQCN

```sql

CREATE VIEW dbo.YQCN AS SELECT QCON.QUOTE_CODE,  QCON.REV_NUM, QCON.CONTCT_CODE, CTCT.CONTCT_TYPE, CTTY.DESCR,  CTCT.NAME,  CTCT.COMP_NAME, CTCT.ADDR_LINE_1,  CTCT.ADDR_LINE_2,  CTCT.ADDR_CITY,  CTCT.ADDR_STATE,  CTCT.ADDR_CNTRY, CTCT.ADDR_POSTCD, CTCT.PHONE_NUM_1, CTCT.PHONE_NUM_2, CTCT.PHONE_NUM_3, CTCT.PHONE_NUM_4, CTCT.EMAIL_ADDR FROM QCON,CTCT,CTTY WHERE QCON.CONTCT_CODE = CTCT.CONTCT_CODE AND CTCT.CONTCT_TYPE = CTTY.CONTCT_TYPE
```

## View: dbo.yqcs

```sql

create view [dbo].[yqcs] as select b.order_date, a.order_code, a.tkt_date, a.tkt_code, a.sample_number, c.cust_code, c.proj_code, d.prod_code, d.order_intrnl_line_num, d.proj_line_num, d.delv_qty, d.delv_qty_uom, d.order_qty, d.order_qty_uom, d.additional_samples, d.apply_to_contract, b.ship_plant_code, c.cust_job_num from qcst a, tick b, ordr c, ordl d, tktl e where a.tkt_date = b.tkt_date and a.tkt_code = b.tkt_code and a.order_code = b.order_code and b.order_date = c.order_date and b.order_code = c.order_code and b.order_date = e.order_date and b.order_code = e.order_code and b.tkt_code = e.tkt_code and e.order_date = d.order_date and e.order_code = d.order_code and e.rm_mix_flag = 1 and e.order_intrnl_line_num = d.order_intrnl_line_num
```

## View: dbo.yqhd

```sql

create view [dbo].[yqhd] as select quot.quote_code, quot.rev_num, quot.quote_name, quot.job_id job, jobs.job_name, jobs.owner, DATENAME(weekday, jobs.job_bid_date) as BidDueDay, DATENAME(month, jobs.job_bid_date)+' '+DATENAME(day, jobs.job_bid_date)+', '+DATENAME(year, jobs.job_bid_date) as BidDueDate, quot.bill_cust_code cust_code, quot.bill_cust_name name, quot.ship_addr_line_1 shipaddr1, quot.ship_addr_line_2 shipaddr2, CAST(RTRIM(quot.ship_city) AS VARCHAR(40)) shipcity, CAST(RTRIM(quot.ship_postcd) AS VARCHAR(10)) shippostcd, CAST(RTRIM(quot.ship_state) AS VARCHAR(10)) shipst, quot.tax_code taxcode, quot.taxble_code taxblecode, DATENAME(month, quot.expir_date)+' '+DATENAME(day, quot.expir_date)+', '+DATENAME(year, quot.expir_date) as expire, DATENAME(month, quot.reqrd_date)+' '+DATENAME(day, quot.reqrd_date)+', '+DATENAME(year, quot.reqrd_date) as RequiredDate, quot.map_page mappg, cust.addr_line_1 custaddr1, cust.addr_line_2 custaddr2, CAST(RTRIM(cust.addr_city) AS VARCHAR(40)) custcity, CAST(RTRIM(cust.addr_state) AS VARCHAR(10)) custst, cust.addr_cntry custcntry, CAST(RTRIM(cust.addr_postcd) AS VARCHAR(10)) custpostcd, cust.contct_name custcontctname, cust.phone_num_1 custphonenum1, cust.phone_num_2 custphonenum2, cust.phone_num_3 custfaxnum1, cust.phone_num_4 custfaxnum2, cust.invc_name InvcName, cust.invc_addr_line_1 InvcAddr1, cust.invc_addr_line_2 InvcAddr2, cust.invc_city InvcCity, cust.invc_state InvcState, cust.invc_cntry InvcCntry, cust.invc_postcd InvcPostcd, ctct.contct_type QuoteToContctType, ctct.name QuoteToContctName, ctct.addr_line_1 QuoteToContctAddr1, ctct.addr_line_2 QuoteToContctAddr2, ctct.addr_city QuoteToContctCity, ctct.addr_state QuoteToContctState, ctct.addr_cntry QuoteToContctCntry, ctct.addr_postcd QuoteToContctPostcd, ctct.phone_num_1 QuoteToContctPhoneNum1, ctct.phone_num_2 QuoteToContctPhoneNum2, ctct.phone_num_3 QuoteToContctPhoneNum3, ctct.phone_num_4 QuoteToContctPhoneNum4, substring(ctct.email_addr, 1, 254) as QuoteToContctEmailAddr1, substring(ctct.email_addr_2, 1, 254) as QuoteToContctEmailAddr2, substring(ctct.email_addr_3, 1, 254) as QuoteToContctEmailAddr3, ctty.descr QuoteToContctTypeDescr, trms1.descr CCTermsDescription, trms.descr CATermsDescription, yqcc.CC_Est, yqca.CA_Est, empl1.name PrimarySalesName, empl1.phone_num PrimarySalesPhone, empl1.phone_line_num PrimarySalesExt, empl1.addr_line_1 PrimSalesAddr1, empl1.addr_line_2 PrimSalesAddr2, empl1.addr_city PrimSalesCity, empl1.addr_state PrimSalesState, empl1.addr_cntry PrimSalesCntry, empl1.addr_postcd PrimSalesPostCD, empl2.name CASalesName, empl3.name CBSalesName, empl4.name CCSalesName, empl5.name CDSalesName, DATENAME(month, quot.job_begin_date)+' '+DATENAME(day, quot.job_begin_date)+', '+DATENAME(year, quot.job_begin_date) as JobBeginDate, DATENAME(month, quot.job_expir_date)+' '+DATENAME(day, quot.job_expir_date)+', '+DATENAME(year, quot.job_expir_date) as JobExpireDate, quot.ca_price_plant_code CAPricePlantCode, quot.cb_price_plant_code CBPricePlantCode, quot.cc_price_plant_code CCPricePlantCode, quot.cd_price_plant_code CDPricePlantCode, plnt1.name CAPricePlantName, plnt2.name CBPricePlantName, plnt3.name CCPricePlantName, plnt4.name CDPricePlantName, plnt1.short_name CAPricePlantShortName, plnt2.short_name CBPricePlantShortName, plnt3.short_name CCPricePlantShortName, plnt4.short_name CDPricePlantShortName, quot.ca_sched_plant_code CASchedPlantCode, quot.cb_sched_plant_code CBSchedPlantCode, quot.cc_sched_plant_code CCSchedPlantCode, quot.cd_sched_plant_code CDSchedPlantCode, quot.quote_to_contact_code QuoteToContctCode, plnt5.name CASchedPlantName, plnt6.name CBSchedPlantName, plnt7.name CCSchedPlantName, plnt8.name CDSchedPlantName, plnt5.short_name CASchedPlantShortName,  plnt6.short_name CBSchedPlantShortName, plnt7.short_name CCSchedPlantShortName, plnt8.short_name CDSchedPlantShortName, cast(cust.tax_exempt_id as varchar (500)) TaxExemptID from quot LEFT OUTER JOIN jobs ON quot.job_id = jobs.job_id LEFT OUTER JOIN cust ON quot.bill_cust_code = cust.cust_code LEFT OUTER JOIN ctct ON quot.quote_to_contact_code = ctct.contct_code LEFT OUTER JOIN ctty ON ctct.contct_type = ctty.contct_type LEFT OUTER JOIN plnt plnt1 on plnt1.plant_code = quot.ca_price_plant_code LEFT OUTER JOIN plnt plnt2 on plnt2.plant_code = quot.cb_price_plant_code LEFT OUTER JOIN plnt plnt3 on plnt3.plant_code = quot.cc_price_plant_code LEFT OUTER JOIN plnt plnt4 on plnt4.plant_code = quot.cd_price_plant_code LEFT OUTER JOIN plnt plnt5 on plnt5.plant_code = quot.ca_sched_plant_code LEFT OUTER JOIN plnt plnt6 on plnt6.plant_code = quot.cb_sched_plant_code LEFT OUTER JOIN plnt plnt7 on plnt7.plant_code = quot.cc_sched_plant_code LEFT OUTER JOIN plnt plnt8 on plnt8.plant_code = quot.cd_sched_plant_code LEFT OUTER JOIN empl empl1  on empl1.empl_code = quot.prim_slsmn_empl_code LEFT OUTER JOIN empl empl2  on empl2.empl_code = quot.ca_slsmn_empl_code LEFT OUTER JOIN empl empl3  on empl3.empl_code = quot.cb_slsmn_empl_code LEFT OUTER JOIN empl empl4  on empl4.empl_code = quot.cc_slsmn_empl_code LEFT OUTER JOIN empl empl5  on empl5.empl_code = quot.cd_slsmn_empl_code LEFT OUTER JOIN yqcc ON quot.quote_code = yqcc.quote_code and quot.rev_num = yqcc.rev_num LEFT OUTER JOIN yqca ON quot.quote_code = yqca.quote_code and quot.rev_num = yqca.rev_num LEFT OUTER JOIN trms ON quot.ca_terms_code = trms.terms_code LEFT OUTER JOIN trms trms1 on quot.cc_terms_code = trms1.terms_code
```

## View: dbo.yqpc

```sql

create view [dbo].[yqpc] as select qprd.quote_code, qprd.rev_num, qprd.unique_line_num, qprd.sort_line_num, qprd.item_code, qprd.prod_descr item_description, qprd.short_prod_descr item_short_description, 'Plant' = case qprd.price_plant_code when '#' then 'Any' else qprd.price_plant_code end, 'Plant_Name' = case when plnt.name IS NULL then 'Any' else plnt.name end, space(8-len('$' + cast(qprd.matl_price as varchar(8)))) + '$' + cast(qprd.matl_price as varchar(8)) item_price, space(8-len('$' + cast(qprd.price as varchar(8)))) + '$' + 	 cast(qprd.price as varchar(8)) delivered_price, qprd.est_qty, uoms.short_descr uom_desc, coalesce(qpct.truck_type,qprd.pref_truck_type) truck_type, space(8-len('$' +  cast(coalesce(qpct.chrg_cart_rate,qprd.ca_chrg_cart_rate)  as varchar(8)))) + '$' +  cast(coalesce(qpct.chrg_cart_rate,qprd.ca_chrg_cart_rate)  as varchar(8)) cartage_rate, space(8-len('$' +  cast(qprd.matl_price+coalesce(qpct.chrg_cart_rate, qprd.ca_chrg_cart_rate) as varchar(8)))) + '$' +  cast(qprd.matl_price+coalesce(qpct.chrg_cart_rate, qprd.ca_chrg_cart_rate) as varchar(8)) matl_cart_price from qprd left outer join qpct on ( qprd.quote_code = qpct.quote_code and  qprd.rev_num = qpct.rev_num and  qprd.unique_line_num = qpct.unique_line_num) left outer join uoms on qprd.order_qty_uom = uoms.uom left outer join plnt on plnt.plant_code = qprd.price_plant_code
```

## View: dbo.yqpp

```sql

create view [dbo].[yqpp] as select qprd.quote_code, qprd.rev_num, qprd.unique_line_num, qprd.sort_line_num,  qprd.item_code,  qprd.price_plant_code, qprd.prod_descr,  qprd.short_prod_descr, qprd.est_qty, qprd.price,  qprd.chrg_cart_code, qprd.pay_cart_code, qprd.rm_slump,  qprd.usage_code,  qprd.pref_truck_type,  qprd.stat,  qprd.price_status, icat.item_type,  sum(prjp.est_qty) proj_est_qty from qprd left outer join prjp on  qprd.quote_code = prjp.quote_code and qprd.unique_line_num = prjp.job_quote_unique_line_num 	 INNER JOIN imst on qprd.item_code = imst.item_code INNER JOIN icat on imst.item_cat = icat.item_cat  where (imst.inactive_code != '02' or imst.inactive_code = '' or imst.inactive_code is null)group by qprd.quote_code, qprd.rev_num, qprd.unique_line_num, qprd.sort_line_num, qprd.item_code, qprd.price_plant_code, qprd.prod_descr,  qprd.short_prod_descr, qprd.est_qty, qprd.price, qprd.chrg_cart_code, qprd.pay_cart_code, qprd.rm_slump, qprd.usage_code, qprd.pref_truck_type, qprd.stat, qprd.price_status, icat.item_typeunion allselect qprd.quote_code, qprd.rev_num, qprd.unique_line_num, qprd.sort_line_num,  qprd.item_code,  qprd.price_plant_code, qprd.prod_descr,  qprd.short_prod_descr, qprd.est_qty, qprd.price,  qprd.chrg_cart_code, qprd.pay_cart_code, qprd.rm_slump,  qprd.usage_code,  qprd.pref_truck_type,  qprd.stat,  qprd.price_status, icat.item_type,  sum(prjp.est_qty) proj_est_qty from qprd left outer join prjp on  qprd.quote_code = prjp.quote_code and qprd.unique_line_num = prjp.job_quote_unique_line_num INNER JOIN icat on ltrim(rtrim(qprd.item_code)) = ltrim(rtrim(icat.item_cat)) LEFT OUTER JOIN imst i on qprd.item_code = i.item_codewhere i.item_code is null group by qprd.quote_code, qprd.rev_num, qprd.unique_line_num, qprd.sort_line_num, qprd.item_code, qprd.price_plant_code, qprd.prod_descr,  qprd.short_prod_descr, qprd.est_qty, qprd.price, qprd.chrg_cart_code, qprd.pay_cart_code, qprd.rm_slump, qprd.usage_code, qprd.pref_truck_type, qprd.stat, qprd.price_status, icat.item_type
```

## View: dbo.yqpr

```sql

create view [dbo].[yqpr] asselect qprd.quote_code, qprd.rev_num, qprd.unique_line_num, qprd.item_code, qprd.sort_line_num, qprd.prod_descr Item_Description, qprd.short_prod_descr Item_Short_Description, qprd.est_qty, uoms.short_descr UOM_Desc, imst.item_cat, icat.item_type, imst.agg_size, imst.cem_type, imst.strgth, imst.days_to_strgth, uoms1.short_descr StrgthUom, imst.water_cem_ratio, cast(imst.user_defined AS varchar (40)) user_defined,  qprd.rm_slump, 'Plant' = case qprd.price_plant_code  when '#' then 'Any' else qprd.price_plant_code end, space(8-len('$' + cast(qprd.price as varchar(8)))) + '$' + cast(qprd.price as varchar(8)) Price, space(8-len('$' + cast(qprd.ca_chrg_cart_rate as varchar(8)))) + '$' + cast(qprd.ca_chrg_cart_rate as varchar(8)) cartage_rate, space(8-len('$' + cast(qprd.matl_price as varchar(8)))) + '$' + cast(qprd.matl_price as varchar(8)) Matl_Price, space(8-len('$' + cast(qprd.calc_price as varchar(8)))) + '$' + cast(qprd.calc_price as varchar(8)) Calc_Price, qprd.pref_truck_type Truck_Type, usge.descr Usage_Desc, imst.cart_cat, CAST(dbo.csfn_parse_individual(imst.user_defined,'|',':',1) AS VARCHAR(500)) AS udfld1, CAST(dbo.csfn_parse_individual(imst.user_defined,'|',':',2) AS VARCHAR(500)) AS udfld2, CAST(dbo.csfn_parse_individual(imst.user_defined,'|',':',3) AS VARCHAR(500)) AS udfld3, CAST(dbo.csfn_parse_individual(imst.user_defined,'|',':',4) AS VARCHAR(500)) AS udfld4, imst.max_age_of_concrete, imst.strgth2_code, imst.time_to_strgth2, imst.agg_moisture_ref_code, imst.strgth3_code, imst.time_to_strgth3, imst.max_water, imst.pct_air, imst.lwt_qty, imst.slump, imst.slump_type, imst.slump_uom, imst.min_slump, imst.max_slump, imst.min_load_size, imst.max_load_size, imst.min_cem_cont, imst.water_hold, imst.sort_code, imst.modifier_slump, imst.min_temp, imst.max_temp, imst.min_temp_uomfrom qprd left outer join usge on qprd.usage_code = usge.usage_code left outer join uoms on qprd.order_qty_uom = uoms.uom left outer join imst on qprd.item_code = imst.item_code left outer join icat on imst.item_cat = icat.item_cat left outer join uoms uoms1 on imst.strgth_uom = uoms1.uomwhere imst.inactive_code != '02'
```

## View: dbo.YQSC

```sql

CREATE VIEW [dbo].[YQSC] ASSELECT a.quote_code, a.rev_num, a.sort_line_num, b.clause_code, SubString(b.descr, 1, 250) as descr, SubString(b.descr, 251, 100) as descr2, b.apply_code	 FROM qstc a, stdc b WHERE a.clause_code = b.clause_code
```

## View: dbo.YQSD

```sql

CREATE VIEW [dbo].[YQSD] ASSELECT a.quote_code, a.rev_num, a.sort_line_num, b.clause_code, SubString(b.descr, 1, 250) as descr, SubString(b.descr, 251, 100) as descr2, b.apply_code	 FROM qstd a, stdc b WHERE a.clause_code = b.clause_code
```

## View: dbo.yqsg

```sql

create view [dbo].[yqsg] asSELECT DISTINCT qusc.quote_code, qusc.rev_num, qusc.intrnl_line_num, qusc.prod_line_code, qusc.sundry_chrg_table_id, qusc.sort_line_num, qusc.item_code, qusc.price, qusc.price_uom, qusc.price_ext_code, qusc.effect_date, qusc.prev_price, qusc.prev_price_ext_code, qusc.sep_invc_flag, qusc.modified_date, pchg.descr, pchg.short_descr, pchg.auto_chrg_flag, pchg.cc_apply_auto_chrg_flag, pchg.ca_apply_auto_chrg_flag, 'comp_code' = case pchc.comp_code when '#' then 'All' else pchc.comp_code end, 'plant_code' = case pchc.plant_code when '#' then 'All' else pchc.plant_code end, pchc.prod_code, pchc.chrg_type, pchc.target_uom, pchc.time_to_use, pchc.first_load_flag, left(CONVERT(varchar(5), pchc.from_date, 110),5) from_date, left(CONVERT(varchar(5), pchc.thru_date, 110),5) thru_date, pchc.comb_matl_price_code, pchc.apply_min_chrg_item, pchc.delv_meth_code, uoms.abbr, uoms.short_descr as uom_short_descr  FROM qusc inner join quot on quot.quote_code = qusc.quote_code inner join pchg on pchg.sundry_chrg_table_id = qusc.sundry_chrg_table_id inner join pchc on pchc.sundry_chrg_table_id = qusc.sundry_chrg_table_id left outer join uoms on qusc.price_uom = uoms.uom  inner join plnt on plnt.plant_code = case qusc.prod_line_code when 'CC' then quot.cc_price_plant_code when 'CA' then quot.ca_price_plant_code when 'CB' then quot.cb_price_plant_code when 'CD' then quot.cd_price_plant_code else '#' end WHERE qusc.rev_num = quot.rev_num and pchc.comp_code = case pchc.comp_code when '#' then pchc.comp_code else plnt.comp_code end  AND pchc.plant_code = case pchc.plant_code when '#' then pchc.plant_code else plnt.plant_code end
```

## View: dbo.yqsl

```sql

create view [dbo].[yqsl] asSELECT DISTINCT yqsg.quote_code, yqsg.rev_num, yqsg.intrnl_line_num, yqsg.prod_line_code, yqsg.sort_line_num, pchl.sundry_chrg_table_id, 'comp_code' = case pchl.comp_code when '#' then 'All' else pchl.comp_code end, 'plant_code' = case pchl.plant_code when '#' then 'All' else pchl.plant_code end, pchl.unique_num, left(CONVERT(varchar(5), pchl.begin_time, 8), 5) begin_time, left(CONVERT(varchar(5), pchl.end_time, 8), 5) end_time, pchl.day_1_flag, pchl.day_2_flag, pchl.day_3_flag, pchl.day_4_flag, pchl.day_5_flag, pchl.day_6_flag, pchl.day_7_flag, pchl.curr_chrg, pchl.curr_pct, pchl.prev_chrg, pchl.effect_date, pchl.item_code, pchl.item_cat, uoms.abbr, uoms.short_descr FROM yqsg inner join pchl on yqsg.sundry_chrg_table_id = pchl.sundry_chrg_table_id left outer join uoms on yqsg.target_uom = uoms.uom WHERE (yqsg.comp_code = pchl.comp_code or pchl.comp_code = '#') and (yqsg.plant_code = pchl.plant_code or pchl.plant_code = '#')
```

## View: dbo.yquj

```sql

create view [dbo].[yquj] asselect quot.quote_code, quot.rev_num, quot.job_id, quot.bill_cust_code, quot.bill_cust_name, quot.bill_cust_bus_addr_line_1, quot.bill_cust_bus_addr_line_2, quot.bill_cust_bus_addr_city, quot.bill_cust_bus_addr_state, quot.bill_cust_bus_addr_cntry, quot.bill_cust_bus_addr_postcd, quot.bill_cust_mail_addr_line_1, quot.bill_cust_mail_addr_line_2, quot.bill_cust_mail_addr_city, quot.bill_cust_mail_addr_state, quot.bill_cust_mail_addr_cntry, quot.bill_cust_mail_addr_postcd, quot.bill_cust_phone_num_1, quot.bill_cust_phone_num_2, quot.bill_cust_phone_num_3, quot.bill_cust_phone_num_4, quot.ship_cust_code, quot.ship_cust_name, quot.ship_cust_bus_addr_line_1, quot.ship_cust_bus_addr_line_2, quot.ship_cust_bus_addr_city, quot.ship_cust_bus_addr_state, quot.ship_cust_bus_addr_cntry, quot.ship_cust_bus_addr_postcd, quot.ship_cust_mail_addr_line_1, quot.ship_cust_mail_addr_line_2, quot.ship_cust_mail_addr_city, quot.ship_cust_mail_addr_state, quot.ship_cust_mail_addr_cntry, quot.ship_cust_mail_addr_postcd, quot.ship_cust_phone_num_1, quot.ship_cust_phone_num_2, quot.ship_cust_phone_num_3, quot.ship_cust_phone_num_4, quot.ref_cust_code, quot.ref_cust_name, quot.ref_cust_bus_addr_line_1, quot.ref_cust_bus_addr_line_2, quot.ref_cust_bus_addr_city, quot.ref_cust_bus_addr_state, quot.ref_cust_bus_addr_cntry, quot.ref_cust_bus_addr_postcd, quot.ref_cust_mail_addr_line_1, quot.ref_cust_mail_addr_line_2, quot.ref_cust_mail_addr_city, quot.ref_cust_mail_addr_state, quot.ref_cust_mail_addr_cntry, quot.ref_cust_mail_addr_postcd, quot.ref_cust_phone_num_1, quot.ref_cust_phone_num_2, quot.ref_cust_phone_num_3, quot.ref_cust_phone_num_4, quot.curr_stat, quot.curr_stat_date, quot.job_begin_date, quot.job_expir_date, quot.created_date, quot.reqrd_date, quot.expir_date, quot.replcs_quote_code, quot.replcd_by_quote_code, quot.replcd_by_rev_num, quot.quote_type, quot.metric_cstmry_code, quot.doc_fmt_group_code, quot.lost_rsn_code, quot.lost_to_compet, quot.lost_to_amt, quot.ca_sales_anl_code, quot.cb_sales_anl_code, quot.cc_sales_anl_code, quot.cd_sales_anl_code, quot.ca_slsmn_empl_code, quot.cb_slsmn_empl_code, quot.cc_slsmn_empl_code, quot.cd_slsmn_empl_code, quot.ca_est_qty, quot.cb_est_qty, quot.cc_est_qty, quot.cd_est_qty, quot.ca_est_qty_uom, quot.cb_est_qty_uom, quot.cc_est_qty_uom, quot.cd_est_qty_uom, quot.ca_avg_price, quot.cb_avg_price, quot.cc_avg_price, quot.cd_avg_price, quot.ca_est_revenue, quot.cb_est_revenue, quot.cc_est_revenue, quot.cd_est_revenue, quot.map_page, quot.est_trvl_time, quot.ca_sched_plant_code, quot.cb_sched_plant_code, quot.cc_sched_plant_code, quot.cd_sched_plant_code, quot.ca_truck_type, quot.cb_truck_type, quot.cc_truck_type, quot.cd_truck_type, quot.ca_delv_meth_code, quot.cb_delv_meth_code, quot.cc_delv_meth_code, quot.cd_delv_meth_code, quot.ca_price_cat, quot.cb_price_cat, quot.cc_price_cat, quot.cd_price_cat, quot.ca_price_plant_code, quot.cb_price_plant_code, quot.cc_price_plant_code, quot.cd_price_plant_code, quot.ca_trade_disc_pct, quot.cb_trade_disc_pct, quot.cc_trade_disc_pct, quot.cd_trade_disc_pct, quot.ca_trade_disc_amt, quot.cb_trade_disc_amt, quot.cc_trade_disc_amt, quot.cd_trade_disc_amt, quot.ca_trade_disc_amt_uom, quot.cb_trade_disc_amt_uom, quot.cc_trade_disc_amt_uom, quot.cd_trade_disc_amt_uom, quot.ca_terms_code, quot.cb_terms_code, quot.cc_terms_code, quot.cd_terms_code, quot.ca_zone_code, quot.cb_zone_code, quot.cc_zone_code, quot.cd_zone_code, quot.ca_cart_code, quot.cb_cart_code, quot.cc_cart_code, quot.cd_cart_code, quot.ca_cart_rate, quot.cb_cart_rate, quot.cc_cart_rate, quot.cd_cart_rate, quot.ca_hler_code, quot.cb_hler_code, quot.cc_hler_code, quot.cd_hler_code, quot.ca_apply_zone_chrg_flag, quot.cb_apply_zone_chrg_flag, quot.cc_apply_zone_chrg_flag, quot.cd_apply_zone_chrg_flag, quot.ca_restrict_quoted_prod_flag, quot.cb_restrict_quoted_prod_flag, quot.cc_restrict_quoted_prod_flag, quot.cd_restrict_quoted_prod_flag, quot.ca_min_load_chrg_table_id, quot.cb_min_load_chrg_table_id, quot.cc_min_load_chrg_table_id, quot.cd_min_load_chrg_table_id, quot.ca_min_load_sep_invc_flag, quot.cb_min_load_sep_invc_flag, quot.cc_min_load_sep_invc_flag, quot.cd_min_load_sep_invc_flag, quot.ca_season_chrg_table_id, quot.cb_season_chrg_table_id, quot.cc_season_chrg_table_id, quot.cd_season_chrg_table_id, quot.ca_season_sep_invc_flag, quot.cb_season_sep_invc_flag, quot.cc_season_sep_invc_flag, quot.cd_season_sep_invc_flag, quot.ca_excess_unld_chrg_table_id, quot.cb_excess_unld_chrg_table_id, quot.cc_excess_unld_chrg_table_id, quot.cd_excess_unld_chrg_table_id, quot.ca_excess_unld_sep_invc_flag, quot.cb_excess_unld_sep_invc_flag, quot.cc_excess_unld_sep_invc_flag, quot.cd_excess_unld_sep_invc_flag, quot.allow_price_adjust_flag, quot.tax_code, quot.taxble_code, quot.non_tax_rsn_code, quot.prim_slsmn_empl_code, quot.ship_addr_line_1, quot.ship_addr_line_2, quot.ship_city, quot.ship_state, quot.ship_cntry, quot.ship_postcd, quot.ca_hler_pay_cart_code, quot.cb_hler_pay_cart_code, quot.cc_hler_pay_cart_code, quot.cd_hler_pay_cart_code, quot.quote_form, quot.curr_stat_rsn_code, quot.dataout_date, quot.type_price, quot.map_long, quot.map_lat, quot.map_radius, quot.po, quot.ca_print_tkt_prices_flag, quot.cb_print_tkt_prices_flag, quot.cc_print_tkt_prices_flag, quot.cd_print_tkt_prices_flag, quot.ca_allow_price_chng_flag, quot.cb_allow_price_chng_flag, quot.cc_allow_price_chng_flag, quot.cd_allow_price_chng_flag, quot.ca_apply_min_haul_flag, quot.cb_apply_min_haul_flag, quot.cc_apply_min_haul_flag, quot.cd_apply_min_haul_flag, quot.ca_apply_min_haul_pay_flag, quot.cb_apply_min_haul_pay_flag, quot.cc_apply_min_haul_pay_flag, quot.cd_apply_min_haul_pay_flag, quot.quote_to_contact_code, jobs.job_name, jobs.delv_addr as job_delv_addr, jobs.map_page as job_map_page, jobs.zone_code as job_zone_code, jobs.ca_zone_code as job_ca_zone_code, jobs.cb_zone_code as job_cb_zone_code, jobs.cc_zone_code as job_cc_zone_code, jobs.cd_zone_code as job_cd_zone_code, jobs.job_type, jobs.stat as job_stat, jobs.lost_rsn_code as job_lost_rsn_code, jobs.ca_plant_code as job_ca_plant_code, jobs.cb_plant_code as job_cb_plant_code, jobs.cc_plant_code as job_cc_plant_code, jobs.cd_plant_code as job_cd_plant_code, jobs.job_addr_line_1, jobs.job_addr_line_2, jobs.job_city, jobs.job_state, jobs.job_cntry, jobs.job_postcd, jobs.job_stage, jobs.tax_code as job_tax_code, jobs.taxble_code as job_taxble_code, jobs.non_tax_rsn_code as job_non_tax_rsn_code, jobs.ca_price_plant_code as job_ca_price_plant_code, jobs.cb_price_plant_code as job_cb_price_plant_code, jobs.cc_price_plant_code as job_cc_price_plant_code, jobs.cd_price_plant_code as job_cd_price_plant_code, jobs.po as job_po, quot.update_date, quot.u_version, quot.delv_addr, quot.proj_list, quot.ca_order_sur_codes, quot.cb_order_sur_codes, quot.cc_order_sur_codes, quot.cd_order_sur_codes, quot.ca_order_sur_rates, quot.cb_order_sur_rates, quot.cc_order_sur_rates, quot.cd_order_sur_rates, quot.tax_exempt_id, quot.ca_sundry_chrg_table_ids, quot.cb_sundry_chrg_table_ids, quot.cc_sundry_chrg_table_ids, quot.cd_sundry_chrg_table_ids, jobs.tax_exempt_ids as job_tax_exempt_idfrom quotleft outer join jobson quot.job_id = jobs.job_id
```

## View: dbo.yquo

```sql

create view [dbo].[yquo] as select 'Q' rec_type, CAST(null as varchar(12)) proj_code,  a.quote_code, a.bill_cust_code cust_code, c.sort_name, c.name cust_name,  a.ship_addr_line_1 addr_line, b.job_name proj_name, a.rev_num, a.expir_date, CAST(null as varchar(24)) po, CAST(null as varchar(16)) cust_job_num, CAST(null as varchar(4000)) delv_addr from quot as a left outer join jobs as b on a.job_id = b.job_id inner join cust as c on a.ship_cust_code = c.cust_code where a.curr_stat < 3 and (c.inactive_code != '02' or c.inactive_code = '' or c.inactive_code is null)
```

## View: dbo.ysch

```sql

create view [dbo].[ysch] asselectschc.seasonal_chrg_table_id,schc.comp_code,schc.plant_code,schg.descr,schg.short_descr,schc.beg_date,schc.end_date,schc.prod_code,schc.price,schc.price_uomfrom schc, schgwhere schc.seasonal_chrg_table_id = schg.season_chrg_table_id
```

## View: dbo.yscp

```sql

create view [dbo].[yscp] asselect p.order_date, p.order_code, p.order_intrnl_line_num, p.sched_num, s.load_num, p.plant_code, p.plant_fix_meth_code, s.load_size from SCPL as p inner join SCHO as son p.plant_fix_meth_code = 'RQ' AND s.order_date = p.order_date AND s.order_code = p.order_code AND s.order_intrnl_line_num = p.order_intrnl_line_numAND s.from_plant_code = p.plant_codeAND s.sched_num = p.sched_num
```

## View: dbo.ysea

```sql

create view dbo.ysea asSELECT q.QUOTE_CODE, q.REV_NUM, q.i prod_line_chg_desc, s.seasonal_chrg_table_id SeaChrgTID, s.comp_code CompCode, s.plant_code PlantCode, g.descr Descr, g.short_descr ShortDescr, s.beg_date BeginDate, s.end_date EndDate, s.prod_code ProdCode, i.descr ItmDescr, i.short_descr ItmShortDescr, s.price_uom PriceUom from SCHC s, SCHG g,IMST i, (SELECT QUOTE_CODE, REV_NUM, i, case i when 'CA_SEASON_CHRG_TABLE_ID' then CA_SEASON_CHRG_TABLE_ID when 'CB_SEASON_CHRG_TABLE_ID' then CB_SEASON_CHRG_TABLE_ID when 'CC_SEASON_CHRG_TABLE_ID' then CC_SEASON_CHRG_TABLE_ID when 'CD_SEASON_CHRG_TABLE_ID' then CD_SEASON_CHRG_TABLE_ID end as val FROM (SELECT p.i, QUOTE_CODE, REV_NUM, CA_SEASON_CHRG_TABLE_ID, CC_SEASON_CHRG_TABLE_ID, CB_SEASON_CHRG_TABLE_ID, CD_SEASON_CHRG_TABLE_ID FROM QUOT, (select 'CA_SEASON_CHRG_TABLE_ID' as i  UNION  select 'CC_SEASON_CHRG_TABLE_ID' as i  UNION  select 'CB_SEASON_CHRG_TABLE_ID' as i  UNION  select 'CD_SEASON_CHRG_TABLE_ID' as i) p) as c) q where s.prod_code = i.item_code and s.seasonal_chrg_table_id = q.valand g.season_chrg_table_id = s.seasonal_chrg_table_idand (i.inactive_code != '02' or i.inactive_code = '' or i.inactive_code is null)
```

## View: dbo.YSEQ

```sql
CREATE VIEW DBO.YSEQ AS     SELECT name as obj_name, current_value as last_number      FROM sys.sequences     WHERE name LIKE 'CS_SEQ%'
```

## View: dbo.ysls

```sql

create view [dbo].[ysls] as select slss.*,  cust1.name as cust_name,  cust2.name as ship_cust_name,  cust3.name as ref_cust_name,  proj.proj_name,  hler.name as hler_name,  imst.descr as item_descr,  empl1.name as slsmn_empl_name,  empl2.name as driv_empl_name,  acat.descr as acct_cat_descr,  comp1.name as price_comp_name,  comp2.name as ship_comp_name,  dlmt.descr as delv_meth_descr,  icat.descr as item_cat_descr,  maps.descr as map_page_descr,  plnt1.name as price_plant_name,  plnt2.name as ship_plant_name,  sanl.descr as sales_anl_descr,  truc.descr as truck_descr,  ttyp.descr as truck_type_descr,  usge.descr as usage_descr,  zone.descr as zone_descr from slss left outer join zone on slss.zone_code = zone.zone_code left outer join usge on slss.usage_code = usge.usage_code left outer join ttyp on slss.truck_type = ttyp.truck_type left outer join truc on slss.truck_code = truc.truck_code left outer join sanl on slss.sales_anl_code = sanl.sales_anl_code left outer join plnt as plnt2 on slss.ship_plant_code = plnt2.plant_code left outer join plnt as plnt1 on slss.price_plant_code = plnt1.plant_code left outer join maps on slss.map_page = maps.map_page left outer join icat on slss.item_cat = icat.item_cat left outer join dlmt on slss.delv_meth_code = dlmt.delv_meth_code left outer join cust as cust3 on slss.ref_cust_code = cust3.cust_code left outer join cust as cust2 on slss.ship_cust_code = cust2.cust_code left outer join cust as cust1 on slss.cust_code = cust1.cust_code left outer join comp as comp1 on slss.price_comp_code = comp1.comp_code left outer join comp as comp2 on slss.ship_comp_code = comp2.comp_code left outer join acat on slss.acct_cat_code = acat.acct_cat_code left outer join empl as empl1 on slss.slsmn_empl_code = empl1.empl_code left outer join empl as empl2 on slss.driv_empl_code = empl2.empl_code left outer join imst on slss.item_code = imst.item_code left outer join hler on slss.hler_code = hler.hler_code left outer join proj on slss.cust_code = proj.cust_code and slss.proj_code = proj.proj_code
```

## View: dbo.yslt

```sql

create view [dbo].[yslt] as select slst.*,  truc.descr as truck_descr,  empl.name as driv_empl_name,  cust1.name as cust_name,  cust2.name as ship_cust_name,  cust3.name as ref_cust_name,  proj.proj_name as proj_name,  plnt1.name as ship_plant_name, plnt2.name as truck_assgn_plant_name, plnt3.name as driv_assgn_plant_name from slst left outer join plnt as plnt1 on  slst.ship_plant_code = plnt1.plant_code left outer join plnt as plnt2 on slst.truck_assgn_plant_code = plnt2.plant_code left outer join plnt as plnt3 on slst.driv_assgn_plant_code = plnt3.plant_code left outer join proj on slst.cust_code = proj.cust_code and slst.proj_code = proj.proj_code left outer join cust as cust3 on slst.ref_cust_code = cust3.cust_code left outer join cust as cust2 on slst.ship_cust_code = cust2.cust_code left outer join cust as cust1 on slst.cust_code = cust1.cust_code left outer join empl on slst.driv_empl_code = empl.empl_code left outer join truc on slst.truck_code = truc.truck_code
```

## View: dbo.ytkl

```sql

create view [dbo].[ytkl] as select a.order_date, a.order_code, a.tkt_code, b.order_intrnl_line_num, a.remove_rsn_code, a.typed_time, b.delv_qty, b.price_qty, b.dump_qty, b.resold_qty, b.rm_mix_flag, a.cancel_rsn_code, a.exclude_from_ontm_flag from tick a, tktl b where a.order_date = b.order_date and a.order_code = b.order_code and a.tkt_code = b.tkt_code
```

## View: dbo.ytkt

```sql

create view [dbo].[ytkt] as select a.order_date, a.order_code, a.tkt_code, a.order_intrnl_line_num, b.sort_line_num, a.price_qty, a.ext_matl_cost_amt, a.ext_price_amt, b.prod_code, b.short_prod_descr, b.rm_mix_flag, a.cstmry_price_qty, a.metric_price_qty, b.price_ext_code, b.price, b.sales_anl_adjust_code, b.price_uom, b.price_derived_from_code, a.delv_qty, a.delv_qty_uom, b.non_tax_rsn_code, b.prod_cat, b.delv_price_flag, c.abbr, b.prod_descr, b.usage_code, b.taxble_code, b.proj_line_num, b.cust_line_num from tktl as a inner join ordl as b on a.order_date = b.order_date and a.order_code = b.order_code and a.order_intrnl_line_num = b.order_intrnl_line_num join uoms as c on b.price_uom = c.uom
```

## View: dbo.ytla

```sql

create view [dbo].[ytla] as select a.order_code, a.order_date, a.tkt_code, a.order_intrnl_line_num, a.assoc_prod_intrnl_line_num, a.price_qty, a.ext_matl_cost_amt, a.ext_price_amt, a.delv_qty, a.delv_qty_uom, b.price_ext_code, b.prod_code, b.short_prod_descr, b.price, b.price_uom, b.price_derived_from_code, b.non_tax_rsn_code, c.abbr, b.prod_descr, b.prod_cat from tlap as a inner join olap as b on a.order_date = b.order_date and a.order_code = b.order_code  and a.order_intrnl_line_num = b.order_intrnl_line_num and a.assoc_prod_intrnl_line_num = b.assoc_prod_intrnl_line_num join uoms as c on b.price_uom = c.uom
```

## View: dbo.ytlp

```sql

create view [dbo].[ytlp] as Select a.order_date,  a.order_code,  a.tkt_code,  b.order_intrnl_line_num,  b.assoc_prod_intrnl_line_num,  a.remove_rsn_code,  b.delv_qty  from tick as a inner join tlap as b on a.order_date = b.order_date and  a.order_code = b.order_code and  a.tkt_code = b.tkt_code
```

## View: dbo.YTOR

```sql

CREATE VIEW DBO.YTOR AS SELECT t.order_date, t.order_code, t.tkt_code, t.tkt_date, t.driv_empl_code, t.hler_code, t.lot_block, t.min_load_chrg_table_id, t.season_chrg_table_id, t.po, CASE WHEN t.ship_plant_code is not NULL THEN t.ship_plant_code + ' - ' + (SELECT name from PLNT where plant_code = t.ship_plant_code) ELSE NULL END as ship_plant_code, t.ship_plant_loc_code, t.scale_code, t.truck_code, CASE WHEN t.truck_type is not NULL THEN t.truck_type + ' - ' + (SELECT descr from TTYP where truck_type = t.truck_type) ELSE NULL END as truck_type, CASE WHEN t.delv_meth_code is not NULL THEN t.delv_meth_code + ' - ' + (SELECT short_descr from DLMT where delv_meth_code = t.delv_meth_code) ELSE NULL END as delv_meth_code, t.weigh_master_empl_code, CASE WHEN t.remove_rsn_code is not NULL THEN t.remove_rsn_code + ' - ' + (SELECT descr from RSNC where rsn_code = t.remove_rsn_code and rsn_code_use = '01') ELSE NULL END as remove_rsn_code, t.cod_amt, t.disc_amt, t.invc_code, t.invc_date, t.load_num, CASE WHEN t.tax_code is not NULL THEN t.tax_code + ' - ' + (SELECT descr from TAXC where tax_code = t.tax_code) ELSE NULL END as tax_code, t.sched_num, t.sched_load_time, CASE WHEN t.susp_rsn_code is not NULL THEN t.susp_rsn_code + ' - ' + (SELECT descr from RSNC where rsn_code = t.susp_rsn_code and rsn_code_use = '02') ELSE NULL END as susp_rsn_code, t.susp_user_name, t.susp_date_time, t.susp_cancel_date_time, t.susp_cancel_user_name, t.typed_time, t.load_time, t.to_job_time, t.on_job_time, t.begin_unld_time, t.end_unld_time, t.wash_time, t.to_plant_time, t.at_plant_time, t.distance, t.map_long, t.map_lat, t.map_radius, t.truck_tare_wgt, t.truck_tare_wgt_uom, t.truck_net_wgt, t.truck_net_wgt_uom, t.truck_gross_wgt, t.truck_gross_wgt_uom, t.prim_trlr_code, t.prim_trlr_tare_wgt, t.prim_trlr_tare_wgt_uom, t.prim_trlr_net_wgt, t.prim_trlr_net_wgt_uom, t.prim_trlr_gross_wgt, t.prim_trlr_gross_wgt_uom, t.scndry_trlr_code, t.scndry_trlr_tare_wgt, t.scndry_trlr_tare_wgt_uom, t.scndry_trlr_net_wgt, t.scndry_trlr_net_wgt_uom, t.scndry_trlr_gross_wgt, t.scndry_trlr_gross_wgt_uom, t.man_wgt_flag, t.reused_order_date, t.reused_order_code, t.job_phase, t.job_code, t.phase_code, t.pmt_amt, CASE WHEN t.ship_to_plant_code is not NULL THEN t.ship_to_plant_code + ' - ' + (SELECT name from PLNT where plant_code = t.ship_to_plant_code) ELSE NULL END as ship_to_plant_code, t.pmt_meth, t.modified_date, t.dataout_date, CASE WHEN t.pmt_form_code is not NULL THEN t.pmt_form_code + ' - ' + (SELECT descr from PMTF where pmt_form_code = t.pmt_form_code) ELSE NULL END as pmt_form_code, t.inventory_post_stat, CASE WHEN t.cancel_rsn_code is not NULL THEN t.cancel_rsn_code + ' - ' + (SELECT descr from RSNC where rsn_code = t.cancel_rsn_code and rsn_code_use = '01') ELSE NULL END as cancel_rsn_code, t.mobileticket_status, (SELECT cast(CASE WHEN Count(tkt_chrg_code) = 0 THEN 0 ELSE 1 END as bit) FROM tlac WHERE order_date = t.order_date AND order_code = t.order_code AND tkt_code = t.tkt_code AND tkt_chrg_code = '01') AS min_load_chrg_exists_flag, (SELECT cast(CASE WHEN Count(tkt_chrg_code) = 0 THEN 0 ELSE 1 END as bit) FROM tlac WHERE order_date = t.order_date AND order_code = t.order_code AND tkt_code = t.tkt_code AND tkt_chrg_code = '02') AS unload_chrg_exists_flag, (SELECT cast(CASE WHEN Count(tkt_chrg_code) = 0 THEN 0 ELSE 1 END as bit) FROM tlac WHERE order_date = t.order_date AND order_code = t.order_code AND tkt_code = t.tkt_code AND tkt_chrg_code = '03') AS seasonal_chrg_exists_flag, (SELECT cast(CASE WHEN Count(tkt_chrg_code) = 0 THEN 0 ELSE 1 END as bit) FROM tlac WHERE order_date = t.order_date AND order_code = t.order_code AND tkt_code = t.tkt_code AND tkt_chrg_code in ('04','91','92','94','96')) AS cartage_chrg_exists_flag, (SELECT cast(CASE WHEN Count(tkt_chrg_code) = 0 THEN 0 ELSE 1 END as bit) FROM tlac WHERE order_date = t.order_date AND order_code = t.order_code AND tkt_code = t.tkt_code AND tkt_chrg_code in ('06','08','09','10','11')) AS surcharges_exists_flag, (SELECT cast(CASE WHEN Count(tkt_chrg_code) = 0 THEN 0 ELSE 1 END as bit) FROM tktc WHERE order_date = t.order_date AND order_code = t.order_code AND tkt_code = t.tkt_code AND tkt_chrg_code = '07') AS sundry_chrg_exists_flag, o.order_type, o.prod_line_code, o.cust_code, o.cust_name, o.cust_sort_name, o.proj_code, o.zone_code, o.cust_job_num, o.taken_by_empl_code, o.order_by_name, o.order_by_phone_num, CASE WHEN o.price_plant_code is not NULL THEN o.price_plant_code + ' - ' + (SELECT name from PLNT where plant_code = o.price_plant_code) ELSE NULL END as price_plant_code, o.price_plant_loc_code, o.comp_code, o.sales_anl_code, o.slsmn_empl_code, o.quote_code, o.map_page, o.ship_addr_line, o.ship_city, o.ship_state, o.ship_cntry, o.ship_postcd, (SELECT SUM(CASE WHEN i.item_type in ('01','02','04','15','16','24','25') THEN y.price_qty ELSE 0 END) FROM ytkt y, icat i WHERE y.order_date = t.order_date and y.order_code = t.order_code and y.tkt_code = t.tkt_code and y.prod_cat = i.item_cat) as price_qty,  o.email_addr_mobile, c.mobileticket_code, cast (substring(t.delv_addr,1,1000) as varchar(1000)) as delv_addr, cast (substring(t.instr,1,1000) as varchar(1000)) as instr FROM tick t INNER JOIN ordr o ON t.order_date = o.order_date AND t.order_code = o.order_code INNER JOIN cust c ON c.cust_code = o.cust_code
```

## View: dbo.ytou

```sql

create view [dbo].[ytou] as select a.order_date, a.order_code, a.tkt_code, a.order_intrnl_line_num, a.assoc_prod_intrnl_line_num, a.price_qty, a.ext_matl_cost_amt, a.ext_price_amt, a.delv_qty, a.delv_qty_uom, b.price_ext_code, b.prod_cat, b.prod_code, b.short_prod_descr, b.price, b.price_uom, b.price_derived_from_code, b.non_tax_rsn_code, b.taxble_code, b.prod_descr, b.sales_anl_adjust_code, b.sort_line_num, c.abbr from tlap as a inner join olap as b on a.order_date = b.order_date and a.order_code = b.order_code and a.order_intrnl_line_num = b.order_intrnl_line_num and a.assoc_prod_intrnl_line_num = b.assoc_prod_intrnl_line_num join uoms as c on b.price_uom = c.uom
```

## View: dbo.ytsa

```sql

create view [dbo].[ytsa] as select o.cust_code,  o.proj_code,  sum(l.delv_qty) as shipped_qty, l.price_uomfrom ordr o left outer join ordl as l on l.order_code = o.order_code and  l.order_date = o.order_date  where l.price_uom = '60003' or l.price_uom = '60013' and  o.remove_rsn_code is null and  o.proj_code is not null and  o.order_date < DATEADD(month, DATEDIFF(month, 0, CURRENT_TIMESTAMP), 0) and o.order_type != '5' and o.order_type != '6' and o.order_type != '7'group by cust_code, proj_code, price_uom
```

## View: dbo.ytsc

```sql

create view [dbo].[ytsc] as select o.cust_code, o.proj_code, sum(l.delv_qty) as shipped_qtyfrom ordr oleft outer join ordl as l on l.order_code = o.order_code and l.order_date = o.order_date where l.rm_mix_flag = '1' and o.remove_rsn_code is null and o.proj_code is not null and o.order_date < DATEADD(month, DATEDIFF(month, 0, CURRENT_TIMESTAMP), 0) and o.order_type != '5' and o.order_type != '6' and o.order_type != '7'group by cust_code, proj_code
```

## View: dbo.yuch

```sql

create view [dbo].[yuch] as select uchg.unld_chrg_table_id id, uchg.descr, uchg.short_descr, 'COMP_CODE' = CASE uchc.comp_code  WHEN '#' THEN 'All' ELSE uchc.comp_code END, 'PLANT_CODE' = CASE uchc.plant_code  WHEN '#' THEN 'All' ELSE uchc.plant_code END, uchc.allow_mins_per_load minperload, uchc.allow_mins_per_unit minsperunit, u1.short_descr load_uom, 'Method' = case when uchc.chrg_avg_meth = '1' then 'Tickets' when uchc.chrg_avg_meth = '2' then 'Order' when uchc.chrg_avg_meth = '3' then 'Project' else 'None' end, uchc.wrtoff_mins_per_chrg wrtoffmins, space(8-len('$'+cast(uchc.price as varchar(6))))+'$'+ cast(uchc.price as varchar(6)) price, u2.short_descr price_uom from uchc left outer join uoms as u1 on uchc.allow_mins_per_unit_uom = u1.uom left outer join uoms as u2 on uchc.price_uom = u2.uomINNER JOIN quot ON  uchc.unld_chrg_table_id = quot.cc_excess_unld_chrg_table_id LEFT OUTER JOIN uchg ON  uchc.unld_chrg_table_id = uchg.unld_chrg_table_idINNER JOIN plnt ON plnt.plant_code = quot.cc_price_plant_codeINNER JOIN comp ON comp.comp_code = plnt.comp_codeWHERE (uchc.comp_code = comp.comp_code OR uchc.comp_code = '#') AND (uchc.plant_code = plnt.plant_code OR uchc.plant_code = '#')
```

## View: dbo.yulc

```sql

create view [dbo].[yulc] asselectuchc.unld_chrg_table_id,uchc.comp_code,uchc.plant_code,uchg.descr,uchg.short_descr,uchc.begin_stat,uchc.end_stat,uchc.allow_mins_per_load,uchc.allow_mins_per_unit,uchc.allow_mins_per_unit_uom,uchc.minimum_allow_mins_per_load,uchc.unld_chrg_incr_mins,uchc.prod_code,uchc.chrg_avg_meth,uchc.wrtoff_mins_per_chrg,uchc.add_to_tkt,uchc.unld_qty_round_code,uchc.delv_qty_round_code,uchc.price,uchc.price_uomfrom uchc, uchgwhere uchc.unld_chrg_table_id = uchg.unld_chrg_table_id
```

## View: dbo.yvir

```sql

CREATE VIEW [dbo].[yvir] AS SELECT c.item_code, c.loc_code FROM dbo.iloc as c INNER JOIN dbo.imlb as m ON c.item_code = m.item_code AND c.loc_code = m.loc_code WHERE c.batch_matl_flag = 1
```

## View: dbo.ywat

```sql

CREATE VIEW [dbo].[ywat]ASSELECT DISTINCT i.item_code,i.descr AS imst_descr,i.qc_note, u.uom,u.abbr AS uoms_abbr,u.imperial_flag, l.loc_code AS iloc_loc_code,l.spec_grav FROM dbo.imst AS i INNER JOIN dbo.uoms AS u ON i.batch_uom = u.uom INNER JOIN dbo.icat AS c ON i.item_cat = c.item_cat LEFT OUTER JOIN dbo.iloc AS l ON i.item_code = l.item_code WHERE ( c.item_type IN ('05') AND  l.loc_code IS NOT NULL and (l.inactive_code != '02' or l.inactive_code = '' or l.inactive_code is null) AND (i.inactive_code != '02' or i.inactive_code = '' or i.inactive_code is null) )
```

## View: dbo.yxah

```sql

CREATE VIEW [dbo].[yxah] AS WITH base AS ( SELECT imlb.item_code, imlb.loc_code, imlb.batch_code, imlb.sort_line_num, imlb.descr, imlb.short_descr FROM imst INNER JOIN icat ON imst.item_cat = icat.item_cat AND (icat.item_type = '01' OR icat.item_type = '27') INNER JOIN iloc ON imst.item_code = iloc.item_code INNER JOIN imlb ON iloc.item_code = imlb.item_code AND iloc.loc_code = imlb.loc_code ) SELECT a.* FROM base a WHERE EXISTS (SELECT 1 FROM base WHERE item_code != a.item_code AND loc_code = a.loc_code AND batch_code = a.batch_code) AND	 EXISTS (SELECT 1 FROM cnel WHERE object_id = '002' AND loc_code = a.loc_code) AND	 NOT EXISTS (SELECT 1 FROM imst WHERE item_code = a.batch_code)
```

## View: dbo.yxam

```sql

CREATE VIEW [dbo].[yxam] ASWITH base AS (SELECT imlb.item_code, imlb.loc_code, imlb.batch_code, imlb.sort_line_num, imlb.descr, imlb.short_descr,  Row_Number() OVER (PARTITION BY imlb.item_code, imlb.loc_code ORDER BY imlb.item_code, imlb.loc_code, imlb.batch_code) AS rn FROM imst INNER JOIN icat ON imst.item_cat = icat.item_cat AND (icat.item_type = '01' OR icat.item_type = '27') INNER JOIN iloc ON imst.item_code = iloc.item_code INNER JOIN imlb ON iloc.item_code = imlb.item_code AND iloc.loc_code = imlb.loc_code)SELECT a.* FROM base a WHERE EXISTS (SELECT 1 FROM base WHERE item_code = a.item_code AND loc_code = a.loc_code AND rn > 1) AND EXISTS (SELECT 1 FROM base WHERE item_code = a.item_code AND loc_code = a.loc_code AND batch_code NOT IN (SELECT item_code FROM imst))
```

## View: dbo.yxnx

```sql

CREATE VIEW [dbo].[yxnx] AS SELECT b.item_code, b.loc_code, b.batch_code, b.sort_line_num, b.descr, b.short_descr FROM imlb b INNER JOIN imst i ON (b.item_code = i.item_code AND EXISTS (SELECT * FROM imst s, icat c WHERE s.item_code = b.batch_code AND				 s.item_cat = c.item_cat AND					 c.item_type != '01' AND					 c.item_type != '27')	 ) INNER JOIN icat c ON (i.item_cat = c.item_cat AND (c.item_type = '01' OR c.item_type = '27'))
```

