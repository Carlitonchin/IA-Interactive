El proyecto contiene 2 subproyectos:\
. *backend:* una rest api desarrollada con asp.net core\
. *frontend:* una aplicación de frontend desarrollada con vue 3 que consume los endpoints expuestos por el proyecto *backend*

## Backend:
### Requisitos:
El proyecto fue desarrollado con asp.net core 6.0, por lo que se debe tener instalado una versión del *sdk* o del *runtime* compatibles con la 6.0
### Instrucciones:
<code> $ cd backend/
\
\$ dotnet run
</code>\
Estas instrucciones van a iniciar un server escuchando peticiones por el puerto *9999*

## Frontend
### Requisitos:
El proyecto fue desarrollado con *Vue3* por lo que es necesario que tenga instalado *Node.js* y *npm* (versiones lo más recientes posible)
### Instrucciones:
<code>
$ cd frontend/

$ npm install\
\$ npm run dev
</code>

### Notas:
La web es bastante fácil e intuitiva, consta de dos secciones:\
*. Productos:* podrá crear, modificar el stock y eliminar productos\
*. Órdenes:*  podrá gestionar las órdenes creadas, cambiarlas de estado, cancelarlas y añadir nuevas órdenes\
\
Cuando una orden es creada se restan del stock de productos las cantidades correspondientes, el stock podrá ser devuelto al estado previo a la creación de la orden solo si la orden es cancelada en el estado *Pendiente*
\
\
Las vistas están un poco descuidadas en cuanto a atractivo, y no contiene mucha validación del lado del frontend puesto que me enfoqué en la parte del backend\
\
En la carpeta *postman* se encuentra el archivo de postman para testear la api
\
\
Cualquier duda me pueden escribir a mi email: *carlozalejandro98@gmail.com*

## Muchas Gracias



