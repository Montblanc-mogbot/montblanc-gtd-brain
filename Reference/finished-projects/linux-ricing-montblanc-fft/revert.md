# Revert plan (back to stock Fedora / Adwaita)

## GNOME themes (gsettings)
```bash
gsettings set org.gnome.desktop.interface gtk-theme 'Adwaita'
gsettings set org.gnome.desktop.interface icon-theme 'Adwaita'
gsettings set org.gnome.desktop.interface cursor-theme 'Adwaita'

# Fonts (defaults)
gsettings set org.gnome.desktop.interface font-name 'Adwaita Sans 11'
gsettings set org.gnome.desktop.interface monospace-font-name 'Adwaita Mono 11'
```

## Wallpaper (default Fedora 43)
```bash
gsettings set org.gnome.desktop.background picture-uri 'file:///usr/share/backgrounds/f43/default/f43-01-day.jxl'
```

## Extensions
Disable via Extensions app (or remove packages/flatpaks you installed).

## Packages installed for ricing
If we install via dnf, list them here and remove later if desired:
```bash
sudo dnf remove <packages>
```
