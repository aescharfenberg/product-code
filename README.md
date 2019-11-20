[![Build status](https://ci.appveyor.com/api/projects/status/pf6x7pjg984fbbym?svg=true)](https://ci.appveyor.com/project/aescharfenberg/product-code)

# DWG Product Code

.NET (C#) library that makes working with product codes simple and easy. Supports PLU, UPC-A, UPC-E, EAN, and GTIN. Brought to you by the Developer Workgroup (DWG).

# Quick Start

First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [DWG Product Code](https://www.nuget.org/packages/DWG.ProductCode/) from the package manager console:

```
PM> Install-Package DWG.ProductCode
```

Now, let's get to work! If you want to see what kind of code you are working with, use the Interpolate function like so:

```csharp
var barcode = "025200000148";
var productCode = ProductCodeTypes.Interpolate(barcode);
Console.Out.WriteLine(productCode);
```

Output:

```
UPC-A 025200000148 (Length = 12, CheckDigit = 8)
```

Neat! So, the barcode "025200000148" is a UPC-A. UPC-A barcodes have a length of 12, and the right-most digit (8) is a check digit used to ensure that the barcode scan was clean and complete.

## Price Lookup (PLU)

### Base Goods (PLU-5)

### Organic/Non-GMO Goods (PLU-6)

## Universal Product Code (UPC)

### UPC-A

### UPC-E

## Uniform Code Council (UCC)

## European Article Number (EAN)

## Global Trade Item Number (GTIN)

# Resources

The following resources contain a wealth of information about the various types of product codes used in industry. These are all great reads/resources if you would like to learn more about product codes:

* [Internet UPC Database](https://upcdatabase.com/)
  * [Check Digit Calculator](https://upcdatabase.com/checkdigit.asp)
* [TALtech - UPC Bardcode Information](https://www.taltech.com/barcodesoftware/symbologies/upc)
* [BarCodeIsland - UPC-E Symbology](http://www.barcodeisland.com/upce.phtml)
