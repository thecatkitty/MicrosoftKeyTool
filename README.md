# Key retrieval tool for Microsoft products
A little command-line utility for retrieving Microsoft product keys from partially damaged Certificates of Authenticity.

Before running the `Cruncher` program, download the product key configuration file by running `Get-PKeyConfig.ps1`.

## Usage
Provide the product key with unknown characters replaced with question marks:
```
> dotnet run PVMYG-HQDP7-PHHFT-X2PBD-6VDX?
PVMYG-HQDP7-PHHFT-X2PBD-6VDX2 - INVALID [Invalid]
00.00:00:35, 1/24, ETA: 00.00:13:25

PVMYG-HQDP7-PHHFT-X2PBD-6VDX3 - INVALID [Invalid]
00.00:01:11, 2/24, ETA: 00.00:13:03

PVMYG-HQDP7-PHHFT-X2PBD-6VDX4 - VALID [Windows 7 Ultimate Retail]
00.00:01:36, 3/24, ETA: 00.00:11:15

PVMYG-HQDP7-PHHFT-X2PBD-6VDX6 - INVALID [Invalid]
00.00:02:09, 4/24, ETA: 00.00:10:47

PVMYG-HQDP7-PHHFT-X2PBD-6VDX7 - INVALID [Invalid]
00.00:02:09, 5/24, ETA: 00.00:08:12

...

PVMYG-HQDP7-PHHFT-X2PBD-6VDXY - INVALID [Invalid]
00.00:05:48, 24/24, ETA: 00.00:00:00
```
