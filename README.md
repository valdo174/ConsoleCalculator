# ConsoleCalculator
Тестовое задание для Byndyusoft на должность .NET Developer.

## Текст задания
Предлагаем написать на C# консольный калькулятор (можно с веб-интерфейсом), который принимает входную строку, содержащую математическое выражение (целые и десятично-дробные числа, знаки +, -, *, / и скобки) и выводит в консоль результат его вычисления. Задание предполагает самостоятельную реализацию парсинга и расчета математического выражения.

Главным критерием при оценке задания является использование при разработке TDD и принципов SOLID. Архитектура решения должна обеспечивать расширение списка поддерживаемых операций при минимальном и максимально безболезненном для существующей функциональности внесении изменений в исходный код. Код должен быть легко читаем и отформатирован в едином стиле, содержать минимальное число поясняющих комментариев.

Пример консольного ввода:

Введите выражение: 1+2-3

Результат: 0

## Итоги
Было реалзиовано консольное приложение на .NET Core 3.1.
В качестве алгоритма парсинга выражений был реализован алгоритм обратной польской нотации и стековый калькулятор.
