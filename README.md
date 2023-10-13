
# Idevs.Net.CoreLib

A library to extended Serenity Framework 5.





## Installation

To install this module, run the following command in your computer terminal:

```console
  dotnet add package Idevs.Net.CoreLib
```

Install dependencies nuget packages

```console
  dotnet add package PugPDF.Core
```

Add the following code to /Initialization/Startup.cs

```console
  public void ConfigureServices(IServiceCollection services)
  {
    --- ommited ---

    services.AddScoped<IViewPageRenderer, ViewPageRenderer>();
    services.AddScoped<IIdevsPdfExporter, IdevsPdfExporter>();
    services.AddScoped<IIdevsExcelExporter, IdevsExcelExporter>();
  }

  --- ommited ---
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    StaticServiceProvider.Provider = app.ApplicationServices;

    --- ommited ---
  }
```

## License

[MIT](https://choosealicense.com/licenses/mit/)


## Authors

- [@klomkling](https://www.github.com/klomkling)


### Usage