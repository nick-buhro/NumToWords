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
    RussianConverter.Format(12));
// Output: "двенадцать"

// Formatting number with unit of measure
Console.WriteLine(
	RussianConverter.Format(12, UnitOfMeasure.Ruble));
// Output: "двенадцать рублей"

// Formatting number with custom unit of measure
var unit = new UnitOfMeasure(Gender.Masculine, "литр", "литра", "литров");
Console.WriteLine(
	RussianConverter.Format(12, unit));
// Output: "двенадцать литров"

// Formatting currency
Console.WriteLine(
	RussianConverter.FormatCurrency(12.01));
// Output: "двенадцать рублей одна копейка"

// Formatting currency in dollars
var dollarUnit = new UnitOfMeasure(Gender.Masculine, "доллар", "доллара", "долларов");
var centUnit = new UnitOfMeasure(Gender.Masculine, "цент", "цента", "центов");
Console.WriteLine(
	RussianConverter.FormatCurrency(12.01, dollarUnit, centUnit));	
// Output: "двенадцать долларов один цент"
```

## Compatibility

The library is build for .NET Standard 2.0 and don't have other dependencies.
