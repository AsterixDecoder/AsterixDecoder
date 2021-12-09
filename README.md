<h1 align="center">Asterix Decoder</h1>


<!-- ABOUT THE PROJECT -->
# About The Project

Project built for Projects In Air Traffic Management Course of EETAC-UPC Aerospace Systems Engineering Degree. Capable of full decoding of EuroControl Asterix CAT10 and CAT21 messages. Built by Galder Arcellares,Ulises Ortega and Marc Xapelli of Group 10. It was built in C# using Visual Studio and the Library GMAP.net.

## Functionalities 
* Full Decoding of CAT10 and CAT21 Asterix Packets.
* Packet View with all the info for CAT21 and CAT10.
* Processing of Packets to obtain Vehicles using MLAT or ADS-B.
* Transformation of coordinates to obtain WGS-84 Coordinates of CAT10 packets.
* Map View of traffic in function of the time.


# User Guide

![alt text](link imagen Pagina principal)

When opening, upload a file --> Open to select the .ast file.

After Loading, open a Tabla to see the information of the respective category.

![alt text](link imagen TablaCat21)

You can click on the cell that say "Click to expand", to see all the information of a certain Data Item. You can search also for packets using the Track Number in CAT10 and Target Identification in CAT21.

![alt text](link imagen busqueda)

In the Map View you can simulate the flights and there are checks to filter by type of emission and buttons to accelerate or decelerate the time. 
![alt text](link imagen mapa)

You can also search for a determined Target Identification or Track Number, and look at all the position of a determined flight.
![alt text](link imagen mapa View Old y solo un avion)
