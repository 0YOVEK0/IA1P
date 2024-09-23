# Proyecto de Inteligencia Artificial

En este repositorio se verán los conocimientos adquiridos en la clase de inteligencia artificial. La primera entrada se tratará sobre un cono de detección.

## Tabla de Contenidos
- [Descripción del Proyecto](#descripción-del-proyecto)
- [Características](#características)
- [Imagenes](#imagenes)
- [Tecnologías Utilizadas](#tecnologías-utilizadas)
- [Instalación](#instalación)


## Descripción del Proyecto

Este proyecto explora conceptos fundamentales de inteligencia artificial, comenzando con la implementación de un cono de detección que permite a un agente identificar objetos en su entorno.

## Características

- Implementación de un cono de detección usando:
  - `Physics.OverlapSphere`: Para detectar objetos dentro de un área esférica.
  - `Vector3.Angle`: Para calcular el ángulo entre la dirección del agente y los objetos detectados.
  - `Physics.Raycast`: Para comprobar si hay obstáculos entre el agente y los objetos detectados.
- Visualización del cono y su estado.
- Perspectiva de seguimiento de objetos usando comportamientos de steering.

 ## Imagenes

    [Tenemos dos objtos uno con una funcion de deteccion y otro como el que se detecta](IA1P/Assets/IMGS/ia1.png)
    
    [Se muestra con gizmos las funcines del cono de vision](IA1P/Assets/IMGS/ia2.png)
    
    [Se muestra con gizmos como cambia de color el cono de vision](IA1P/Assets/IMGS/ia3.png)



 
  

## Tecnologías Utilizadas

- **Lenguajes de programación:** C#
- **Framework:** Unity 2023.2.18f1
- **Documetacion Auxiliar:** Chatgpt-4o

## Instalación

Instrucciones para instalar y configurar el proyecto.

```bash
# Clona el repositorio
git clone https://github.com/0YOVEK0/IA1P.git
cd IA1P
