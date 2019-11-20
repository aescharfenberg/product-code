# DWG Product Code

.NET (C#) library that makes working with product codes simple and easy. Supports PLU, UPC-A, UPC-E, EAN, and GTIN. Brought to you by the Developer Workgroup (DWG).

# Quick Start

First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [DWG Product Code](https://www.nuget.org/packages/DWG.ProductCode/) from the package manager console:

```
PM> Install-Package DWG.ProductCode
```

Now, let's interpolate some product codes:

```csharp
var code = "025200000148";
var productCode = ProductCodeTypes.Interpolate(code);
```

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
