# NickBuhro.NumToWords

C# library for converting numbers to words.

The current version of the library is also [available on NuGet](https://www.nuget.org/packages/NickBuhro.NumToWords).

## Features

This library can format:

* Number
* Number with unit of measure (you can specify your own unit of measure, for example *kilogram*)
* Currency amount (for example *one dollar fifty five cents*)

Supported languages:

* Russian

## Usage

``` C#
// Number formatting
Console.WriteLine(
    RussianConverter.Format(12));						// Result is "����������"

// Formatting number with unit of measure
Console.WriteLine(
	RussianConverter.Format(12, UnitOfMeasure.Ruble));	// Result is "���������� ������"

// Formatting number with custom unit of measure
var unit = new UnitOfMeasure(Gender.Masculine, "����", "�����", "������");
Console.WriteLine(
	RussianConverter.Format(12, unit));					// Result is "���������� ������"

// Formatting currency
Console.WriteLine(
	RussianConverter.FormatCurrency(12.01));			// Result is "���������� ������ ���� �������"

// Formatting currency in dollars
var dollarUnit = new UnitOfMeasure(Gender.Masculine, "������", "�������", "��������");
var centUnit = new UnitOfMeasure(Gender.Masculine, "����", "�����", "������");
Console.WriteLine(
	RussianConverter.FormatCurrency(12.01, dollarUnit, centUnit));	// Result is "���������� �������� ���� ����"
```

## Compatibility

The library uses no references except for `System` - it has no external dependencies.
It is cross compiled to:

* .NET Framework 2.0 
* .NET Framework 3.5 Client Profile
* .NET Framework 4.0 Client Profile
* .NET Framework 4.5
* .NET Platform 5.4

