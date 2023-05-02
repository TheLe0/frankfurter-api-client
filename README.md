# Frankfurter .NET API Client

[![Tests CI](https://github.com/TheLe0/frankfurter-api-client/actions/workflows/tests.yml/badge.svg?branch=main)](https://github.com/TheLe0/frankfurter-api-client/actions/workflows/tests.yml)

## Introduction

The [Frankfurter API](https://github.com/hakanensari/frankfurter) is a powerful currency conversion API that allows you to retrieve up-to-date currency exchange rates for over 30 different currencies. With this .NET API client, you can easily integrate the Frankfurter API into your .NET applications and start converting currencies with just a few lines of code.

This API client is designed to make it simple and easy for developers to interact with the Frankfurter API. It provides a simple and intuitive interface that abstracts away the details of the underlying HTTP requests and responses, allowing you to focus on building great applications.

The client is built using the latest .NET technologies and follows modern best practices for software development. It is fully open source and actively maintained by a team of experienced developers, so you can be sure that it will be reliable, well-documented, and up-to-date with the latest features and bug fixes.

Whether you're building a financial application, a travel app, or any other type of application that needs currency conversion functionality, this .NET API client for the Frankfurter API is the perfect tool to get the job done quickly and easily.

## Packages

 | Package | Version | Downloads | Workflow |
   |---------|---------|-----------|----------|
   | [Frankfurter.API.Client](https://www.nuget.org/packages/Frankfurter.API.Client/) | [![NuGet Version](https://img.shields.io/nuget/v/Frankfurter.API.Client.svg)](https://www.nuget.org/packages/Frankfurter.API.Client/ "NuGet Version")| [![NuGet Downloads](https://img.shields.io/nuget/dt/Frankfurter.API.Client.svg)](https://www.nuget.org/packages/Frankfurter.API.Client/ "NuGet Downloads") | [![Deploy](https://github.com/TheLe0/frankfurter-api-client/actions/workflows/deploy_nuget_api_client.yml/badge.svg)](https://github.com/TheLe0/frankfurter-api-client/actions/workflows/deploy_nuget_api_client.yml) |
   | [Frankfurter.API.Client.DependencyInjection](https://www.nuget.org/packages/Frankfurter.API.Client.DependencyInjection/) | ![NuGet Version](https://img.shields.io/nuget/v/Frankfurter.API.Client.DependencyInjection.svg) | [![NuGet Downloads](https://img.shields.io/nuget/dt/Frankfurter.API.Client.DependencyInjection.svg)](https://www.nuget.org/packages/Frankfurter.API.Client.DependencyInjectionn/ "NuGet Downloads") | [![Deploy](https://github.com/TheLe0/frankfurter-api-client/actions/workflows/deploy_nuget_api_client_di.yml/badge.svg)](https://github.com/TheLe0/frankfurter-api-client/actions/workflows/deploy_nuget_api_client_di.yml) |

## Domain

Here I am going to explain the entities containning on this API client. In this solution we not only wraps the API, but we shape the data in a way that is going to be easier to use:

* <b>Currency</b>:Represents a currency, with its own enum code and name. Its a more informative thing;
* <b>CurrencyCode</b>: Where we store all avaliable currencies codes, in that way developers can know what currencies are currently avaliable;
* <b>Exchange</b>: Represents a exchange from a currency to multiple others;
* <b>CurrencyRate</b>: Is just used inside the <i>Exchange</i> entity, where we represent the result of a conversion of a currency to another.

## Avaliable Currencies

| Currency Code | Name                 |
|---------------|----------------------|
| AUD           |Australian Dollar     |
| BGN           |Bulgarian Lev         |
| BRL           |Brazilian Real        |
| CAD           |Canadian Dollar       |
| CHF           |Swiss Franc           |
| CNY           |Chinese Renminbi Yuan |
| CZK           |Czech Koruna          |
| DKK           |Danish Kron           |
| EUR           |Euro                  |
| GBP           |British Pound         |
| HKD           |Hong Kong Dollar      |
| HUF           |Hungarian Forint      |
| IDR           |Indonesian Rupiah     |
| ILS           |Israeli New Sheqel    |
| INR           |Indian Rupee          |
| ISK           |Icelandic Króna       |
| JPY           |Japanese Ye           |
| KRW           |South Korean Won      |
| MXN           |Mexican Peso          |
| MYR           |Malaysian Ringgit     |
| NOK           |Norwegian Krone       |
| NZD           |New Zealand Dollar    |
| PHP           |Philippine Peso       |
| PLN           |Polish Złoty          |
| RON           |Romanian Leu          |
| SEK           |Swedish Krona         |
| SGD           |Singapore Dollar      |
| THB           |Thai Baht             |
| TRY           |Turkish Lira          |
| USD           |United States Dollar  |
| ZAR           |South African Rand    |

>Note: We just wrap the API, so the currencies missing must be added on the
> Frankfurter API. We just consume its data.

## Methods

1. <b>GetAllAvaliableCurrenciesAsync</b>: Returns all the currently avaliable currencies on the API

```csharp
var currencies = await frankfurter
    .GetAllAvaliableCurrenciesAsync()
    .ConfigureAwait(false);
```

2. <b>CurrencyConvertAsync</b>: Do a currency convertion to a currency to another using a base amount.

```csharp
var exchange = await frankfurter
    .CurrencyConvertAsync(
        10, // Reference Amount
        CurrencyCode.BRL, // Reference Currency
        CurrencyCode.USD // Currency to Convert
    ).ConfigureAwait(false);
```

3. <b>CurrencyConvertByDateAsync</b>: Do a currency convertion to a currency to another using a base amount and a base date.

```csharp
var exchange = await frankfurter
    .CurrencyConvertByDateAsync(
        DateTime.UtcNow, // Reference Date
        10, // Reference Amount
        CurrencyCode.BRL // Reference Currency
    ).ConfigureAwait(false);
```

4. <b>CurrencyConvertByLastPublishedDateAsync</b>: Do a currency convertion to a currency to another using a base amount on the last published date;

```csharp
var exchange = await frankfurter
    .CurrencyConvertByLastPublishedDateAsync(
        10, // Reference Amount
        CurrencyCode.BRL // Reference Currency
    ).ConfigureAwait(false);
```

this method returns the conversation for all avaliable currencies. You can pass an extra parameter and do the conversion only for the currencies that you want:

```csharp
var toCurrencies = new List<CurrencyCode>
{
    CurrencyCode.EUR,
    CurrencyCode.USD
};

var exchange = await frankfurter
    .CurrencyConvertByLastPublishedDateAsync(
        10, // Reference Amount
        CurrencyCode.BRL, // Reference Currency
        toCurrencies // Currencies to convert
    ).ConfigureAwait(false);

```

5. <b>CurrencyConvertByDateIntervalAsync</b>: Do a currency convertion to a currency to another using a base amount on a date interval;

```csharp
var toCurrencies = new List<CurrencyCode>
{
    CurrencyCode.EUR,
    CurrencyCode.USD
};

var exchanges = await frankfurter
    .CurrencyConvertByDateIntervalAsync(
        10, // Reference Amount
        CurrencyCode.BRL, // Reference Currency
        toCurrencies, // Currencies to convert
        new DateTime(2020,1,1), // Start date
        new DateTime(2021,1,1) // End Date
    ).ConfigureAwait(false);

```

## Configuration

This Api integration is ver simple, there is no authentication/authorization requirements, you can use it with almost no configurations.

You can instanciate this client in three different ways:

1. Using default configs: This uses the default [baseUrl](https://github.com/TheLe0/frankfurter-api-client/blob/723d7d9c2b44a5a4b49403a3ebd02af220a010c3/src/Frankfurter.API.Client/Resources/Routes.resx#L121), [timeout](https://github.com/TheLe0/frankfurter-api-client/blob/723d7d9c2b44a5a4b49403a3ebd02af220a010c3/src/Frankfurter.API.Client/Configuration/FrankfurterClientConfiguration.cs#L27) and [Throw on any error flag](https://github.com/TheLe0/frankfurter-api-client/blob/723d7d9c2b44a5a4b49403a3ebd02af220a010c3/src/Frankfurter.API.Client/Configuration/FrankfurterClientConfiguration.cs#LL28C3-L28C3).

```csharp
var frankfurter = new FrankfurterClient();
```

or by dependency injection:

```csharp
services.AddFrankfurterApiClient();
```

2.Only configurating the API base url:

```csharp
var frankfurter = new FrankfurterClient(baseUrl);
```

or by dependency injection:

```csharp
services.AddFrankfurterApiClient(baseUrl);
```

3.And setup manually all configurations with your preferences:

```csharp

var configuration = new FrankfurterClientConfiguration
{
  BaseApiUrl = baseUrl,
  MaxTimeout = 5000,
  ThrowOnAnyError = true
};

var frankfurter = new FrankfurterClient(configuration);
```

or by dependency injection:

```csharp

var configuration = new FrankfurterClientConfiguration
{
  BaseApiUrl = baseUrl,
  MaxTimeout = 5000,
  ThrowOnAnyError = true
};

services.AddFrankfurterApiClient(configuration);
```
