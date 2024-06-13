# GeoTrackPro

GeoTrackPro is a command-line tool that retrieves geographical information about a given IP address. It fetches details such as the city, region, country, organization, postal code, and coordinates associated with the IP address.
All data is fetched from the ipinfo.io API.

## Features

- Retrieve geographical information for any IP address
- Display results in a colorful, easy-to-read format
- Supports multiple queries in a single session
- Exits gracefully with the 'exit' command

## Installation

To use GeoTrackPro, follow these steps:

1. **Download the Repository:**

   Download the entire repository as a ZIP file by clicking on the "Code" button and selecting "Download ZIP". Alternatively, you can clone the repository using Git:
   
   ```bash
   git clone https://github.com/xFanexx/GeoTrackPro.git


Extract the ZIP File:

If you downloaded the ZIP file, extract it to a location of your choice on your computer.



Navigate to the Executable:

The executable and its dependencies are located in the bin/Release/net8.0 folder. Navigate to this directory:

cd GeoTrackPro/bin/Release/net8.0


Run GeoTrackPro:
GeoTrackPro.exe


# Usage
Start the Program:

When you run GeoTrackPro.exe, you will see an ASCII art banner and a prompt asking you to enter an IP address.

Enter an IP Address:

Type the IP address you want to query and press Enter. The program will display the geographical information associated with the IP address in a colorful format.

Query Multiple IP Addresses:

After displaying the results, the program will prompt you to enter another IP address. You can continue to enter IP addresses for more queries or type exit to end the session.

Exit the Program:

Type exit at the prompt and press Enter to close the program.



# Example

GeoTrackPro started

- Enter the IP address: 94.130.134.147

- [+] Request successfully completed
- IP Address: 94.130.134.147
- Hostname: server.xfanexx.de
- City: Falkenstein
- Region: Saxony
- Country: DE
- Postal Code: 08223
- Timezone: Europe/Berlin
- Organization: AS24940 Hetzner Online GmbH
- Google Maps: https://www.google.com/maps/?q=50.4779,12.3713

- Enter a new IP address (or 'exit' to quit):
