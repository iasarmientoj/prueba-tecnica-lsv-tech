**Prueba Técnica - Experiencia de Realidad Virtual Multijugador**  
 
Este repositorio contiene el desarrollo de una prueba técnica enfocada en la creación de una experiencia de realidad virtual multijugador en Unity 6, utilizando URP, XR Interaction Toolkit y una solución de red como Mirror Networking o Unity Netcode.  

### Tarea 1.1: Crear el proyecto en Unity 6 y configurar el Universal Render Pipeline.

<details><summary><i>Tutoriales guía:</i></summary>

- [Best Unity 6 setup for XR using Universal Render Pipeline - Step by Step Performance Guide](https://www.youtube.com/watch?v=Vlmy0JJ_E3c)

</details>

- Configuraciones óptimas VR Unity 6 + URP
	- Eliminar de packages innecesarios
	- Optimizaciones en Projects Settings
	- Habilitar SpriteAtlas para reducir los DrawCalls
	- Configurar Mobile_RPAsset

### Tarea 1.2: Importar y configurar XR Interaction Toolkit y XR Plugin Management para Meta/Pico.

<details><summary><i>Tutoriales guía:</i></summary>

- [How To Make A VR Game in an Hour Using Unity 6!](https://www.youtube.com/watch?v=kbBYcVrGZus)

</details>

- Configuración de XR Plugin Management para Meta/Pico
- Instalación de XR Interaction Toolkit

### Tarea 1.3: Configurar Addressables y ajustar GPU Instancing en URP.

<details><summary><i>Tutoriales guía:</i></summary>

- [Unity VR Optimization : Draw Calls](https://youtu.be/EMA5-WqkEAo?si=_VwUrR9FhFFJ9Wv1)
- [What are Addressables in Unity and How to use to them | Unity Tutorial](https://www.youtube.com/watch?v=wEuFAA-Ktwc)

</details>

- Instalar el Package Addressables
- Habilitar GPU Instancing en cada material

### Tarea 2.1: Seleccionar e integrar Mirror Networking o Unity Netcode.

<details><summary><i>Tutoriales guía:</i></summary>

- [How To Make a VR Multiplayer Game - Unity Netcode](https://www.youtube.com/watch?v=6fZ7LT5AeTw)

</details>

- Instalar el Package de Unity Netcode, usé Unity Netcode en este caso por facilidad en la implementación
- Instalar el Package de Multiplayer Play Mode, para realizar pruebas con varios jugadores en el mismo editor

### Tarea 2.2: Configurar la lógica de conexión local (host/cliente).

- Desarrollado en la Tarea 3.2
- Funciona en LAN, sin necesidad de servidores externos

### Tarea 2.3: Desarrollar la UI para selección y validación de IP (formato 192.168.x.x) y manejo de errores.

<details><summary><i>Tutoriales guía:</i></summary>

- Minuto 08:39 Crear UIs [Make a VR multiplayer game - part 2 | Unity](https://www.youtube.com/watch?v=OT12GfUKpYI)
- [Connect Across Devices on same LAN | Unity Netcode - Quick Tutorial](https://www.youtube.com/watch?v=yCQ26wADnDM)

</details>

- Extraje el teclado del VR Sample

### Tarea 3.1: Configurar el XR Origin con Action-Based Continuous Move Provider.

<details><summary><i>Tutoriales guía:</i></summary>

- Minuto 11:52 Crear escena. [How To Make A VR Game in an Hour Using Unity 6!](https://www.youtube.com/watch?v=kbBYcVrGZus)
- Minuto 02:39 Simulador. [Create a VR UI in Unity 6, FAST & SIMPLE | XR Interaction Toolkit](https://www.youtube.com/watch?v=8MN8fyp6s9E)

</details>

- Probar en el editor con XR Device Simulator Settings
- Usé Dynamic Move Provider en lugar de Continuous Move Provider, ya que vienen en la escena de ejemplo y no tengo un Headset para verificar el funcionamiento correcto si cambió de Provider.
- "*Action-Based* Continuous Move Provider" está depreciado en lugar de ese ahora está disponible el "Continuous Move Provider".


### Tarea 3.2: Sincronizar posiciones, rotaciones y gestos entre clientes.

<details><summary><i>Tutoriales guía:</i></summary>

- [How To Make a VR Multiplayer Game - Unity Netcode](https://www.youtube.com/watch?v=6fZ7LT5AeTw)

</details>

- Modelo de cabeza utilizado: [Loomis Head Foundation](https://sketchfab.com/3d-models/loomis-head-foundation-f0ed55b94b334bd7ac9e5e5656cd5bc0)
- Deshabilitar la cabeza para el propio jugador, los demás sí lo ven
- Movimientos y animaciones solo afectan al player propio

### Tarea 4.1: Configurar Objeto 1 con Rigidbody, gravedad activada, colisiones precisas y uso de Physics.Simulate.

-

### Tarea 4.2: Crear Objeto 2 cinemático controlado por triggers (ej.: plataforma móvil).

-

### Tarea 4.3: Configurar Objeto 3 dinámico con constraints (ej.: puerta giratoria).

-

### Tarea 4.4: Implementar la lógica de exclusividad (desactivar collider al ser sostenido) usando NetworkVariable.

-

### Tarea 5.1: Definir y desarrollar la mecánica creativa.

-

### Tarea 5.2: Organizar el código de forma modular (uso de #region, comentarios XML, patrones de diseño).

-

### Tarea 5.3: Implementar pruebas unitarias para la lógica principal con Unity Test Framework.

-

### Tarea 6.1: Desarrollar pruebas automatizadas que simulen interacciones multijugador y condiciones de lag con Unity Test Framework.

-

### Tarea 6.2: Integrar Addressables para carga dinámica de assets y optimizar Draw Calls con GPU Instancing.

-

### Tarea 6.3: Ajustar la configuración de URP para optimización de rendimiento.

-

### Tarea 7.1: Grabar y editar el vídeo de demostración (3-5 minutos).

-

### Tarea 7.2: Organizar y documentar el código fuente (incluyendo pruebas unitarias).

-

### Tarea 7.3: Generar la build ejecutable (.exe o APK compatible con Meta Quest/Pico, 64-bit, Vulkan).

-

### Tarea 7.4: Redactar el documento técnico explicando decisiones de diseño y optimizaciones aplicadas.

-









### Otros tutoriales seguidos:

<details><summary><i>Tutoriales guía:</i></summary>

- 1. [VR Optimization and Performance Tips for Unity](https://www.youtube.com/watch?v=xqgt9W4Zrjg)
- 2. [Best Unity 6 setup for XR using Universal Render Pipeline - Step by Step Performance Guide](https://www.youtube.com/watch?v=Vlmy0JJ_E3c)
- 3. [What is Polycount and How Does It Affect YOUR Unity VR Game?](https://youtu.be/Fg_v7xm8pQQ?si=qfHH7MDTtCrfujvZ)
- 4. [Unity VR Optimization : Draw Calls](https://youtu.be/EMA5-WqkEAo?si=_VwUrR9FhFFJ9Wv1)
- 5. [Optimize your Unity Game Settings for the Meta Quest](https://youtu.be/swQFRKlgL24?si=ihtfl9TsjFs0Xax4)
- 6. [Unity VR Optimization : Light Probes](https://youtu.be/T13h3So6oFU?si=bG8WpRQgNxPnFB_q)
- 7. [Unity 6 VR Archery That Actually Feels Good!](https://www.youtube.com/watch?v=hm9K0AndDiU)
- 8. [How To Make A VR Game in an Hour Using Unity 6!](https://www.youtube.com/watch?v=kbBYcVrGZus)

</details>

- 1. Conceptos clave en optimización VR
- 3. Oclusión culling VR
- 4. Draw calls VR
- 5. Configuraciones puntuales y de la documentación oficial pero del 2021 VR
- 6. Light Probes VR
- 7. Ejemplo de una mecánica VR
- 8. Ejemplo de un proyecto VR


