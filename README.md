# Генератор пиксельных аватаров из hash-256 на основе никнейма

_Генерирует симметричную пиксельную аватарку по никнейму с динамической размерностью пикселя (5x5, 8x8 и т. д.) с рандомным, но детерминированным цветом._


<img src="https://github.com/faermot/Pixel-Avatar-Generate/blob/master/PAG/examples/dobzhik_8x8.png" width="256" height="256"> <img src="https://github.com/faermot/Pixel-Avatar-Generate/blob/master/PAG/examples/cat_5x5.png" width="256" height="256"> <img src="https://github.com/faermot/Pixel-Avatar-Generate/blob/master/PAG/examples/faermot_9x9.png" width="256" height="256">

___
## Установка и сборка
1. Клонируйте репозиторий с помощью команды ниже:
   ```
   git clone https://github.com/faermot/Pixel-Avatar-Generate.git
   ```
3. Установите необходимые зависимости:
   ```
   dotnet add package SixLabors.ImageSharp --version 3.1.12
   ```
5. Выполните сборку:
   ```
   dotnet build
   ```
