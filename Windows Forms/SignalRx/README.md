SignalR y Reactive Extensions
=========

Este ejemplo tiene dos proyectos:

Un proyecto de consola que hace de servidor y usa una configuración estándar de SignalR. Esta aplicación recibe los mensajes a ser enviados.

Un proyecto de Windows Forms que se conecta al server y filtrará los mensajes que vengan, haciendo uso del `IObservable` entregado por el método [Observe] y los Reactive Extensions, y mostrará solo aquellos que sean = "Hola".

[Observe]:https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.client.hubs.hubproxyextensions.observe%28v=vs.111%29.aspx