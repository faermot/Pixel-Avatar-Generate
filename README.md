# Генератор пиксельных аватаров из хэша SHA-256 на основе никнейма

_Генерирует симметричную пиксельную аватарку по никнейму с динамической размерностью пикселя (5x5, 8x8 и т. д.) с рандомным, но детерминированным цветом._


<img src="https://github.com/faermot/Pixel-Avatar-Generate/blob/master/PAG/examples/dobzhik_8x8.png" width="256" height="256"> <img src="https://github.com/faermot/Pixel-Avatar-Generate/blob/master/PAG/examples/cat_5x5.png" width="256" height="256"> <img src="https://github.com/faermot/Pixel-Avatar-Generate/blob/master/PAG/examples/faermot_9x9.png" width="256" height="256">

___
## Установка и сборка
Клонируйте репозиторий с помощью команды ниже:
   ```
   git clone https://github.com/faermot/Pixel-Avatar-Generate.git
   ```
Выполните сборку:
   ```
   dotnet build
   ```
   
## Использование
```
dotnet run
```
Программа запросит никнейм и размер (например, 8 для 8×8).
Готовое изображение сохраняется как `output.png` в папке запуска.

## Как это работает
Никнейм хешируется через SHA-256. Первый байт хеша даёт биты паттерна,
последние три байта — цвет. Паттерн отражается для симметрии.
