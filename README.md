# Taxi Simulator

Videojuego 3D de simulación de conducción desarrollado en **Unity**, en el que el jugador controla un taxi con el objetivo de recoger pasajeros y llevarlos a su destino, respetando el límite de velocidad para evitar ser perseguido por la policía.

## Integrantes del grupo

- Bernardo Ordás
- Enrique Rodríguez
- Francisco López-Alvarado

## Descripción del juego

El jugador conduce un taxi por una ciudad simulada en 3D. Un cliente (NPC) aparece en un punto aleatorio del mapa y debe ser recogido acercando el taxi a su posición; una vez recogido, aparece en el minimapa un nuevo destino al que hay que llevarlo para completar el trayecto y terminar la partida.

Mecánicas principales:

- **Conducción física del vehículo:** control del taxi mediante `WheelCollider` (motor, frenado y dirección), con velocímetro en tiempo real.
- **Recogida y entrega de pasajeros:** un cliente aparece en un punto de spawn aleatorio; al acercarse el taxi lo recoge, y al llegar al destino asignado se completa el nivel.
- **Radar y persecución policial:** si el jugador supera el límite de velocidad, un coche de policía (con `NavMeshAgent`) inicia una persecución; si alcanza al jugador, lo "multa" y vuelve a su posición inicial.
- **Coleccionables:** objetos positivos y negativos repartidos por el mapa que aumentan o reducen drásticamente la fuerza del motor del taxi.
- **Sistema de vida:** el taxi pierde vida al chocar con obstáculos; si llega a 0, se reinicia el nivel.
- **Minimapa:** posición del taxi y del destino representada en tiempo real sobre el mapa.
- **Menús y progresión:** menú principal, pantalla de instrucciones y varios niveles (`Nivel1`, `Nivel2`) con transición entre escenas.

## Estructura del proyecto

```
FinalProjectTaxi/
├── historias_usuario_pdf.pdf        # Historias de usuario / documentación funcional
└── TaxiSimulator/                   # Proyecto de Unity
    └── Assets/
        ├── Scenes/                  # MainManu, Instrucciones, Nivel1, Nivel2
        ├── Scripts/
        │   ├── CarController.cs     # Física de conducción del taxi (WheelColliders, vida, velocidad)
        │   ├── Player.cs            # Lógica de recogida y entrega del pasajero
        │   ├── GameManager.cs       # Llamada del taxi y detección de llegada
        │   ├── GameManager2.cs      # Flujo de la partida (recogida, destino, final)
        │   ├── PedirUI.cs           # UI para solicitar el taxi
        │   ├── TaxiUI.cs            # UI de destino y pantalla final
        │   ├── Radar.cs             # Detección de exceso de velocidad
        │   ├── MoverPolicia.cs      # IA del coche de policía (persecución vía NavMesh)
        │   ├── MoverCoche.cs        # Movimiento de vehículos por NavMesh
        │   ├── Collectible.cs       # Objetos que modifican la potencia del motor
        │   ├── PositionMiniMap.cs   # Sincronización de posición en el minimapa
        │   └── SceneManager_.cs     # Cambio de escenas (siguiente nivel, reinicio, salir)
        ├── Prefabs/
        └── Materials/
```

## Tecnologías

- **Unity 2022.3.55f1** (motor de juego)
- **C#** para toda la lógica de gameplay
- **NavMesh / NavMeshAgent** para la IA de vehículos (policía y tráfico)
- **TextMesh Pro** para la interfaz de usuario
- Física de vehículos con **WheelCollider**

## Requisitos

- Unity Hub con la versión **2022.3.55f1** (o compatible) del Editor instalada

## Cómo ejecutar el proyecto

1. Abrir Unity Hub y añadir la carpeta `TaxiSimulator` como proyecto existente.
2. Abrir el proyecto con la versión de Unity indicada.
3. Cargar la escena `Assets/Scenes/MainManu.unity` y pulsar Play.

## Controles

- **W / A / S / D** o flechas: acelerar / girar / frenar
- **Espacio:** freno de mano
