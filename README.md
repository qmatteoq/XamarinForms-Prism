# Using Prism in a Xamarin.Forms app

Sample Xamarin.Forms applications built with **Prism for Xamarin.Forms (6.2)**, showing
how to apply MVVM, navigation and dependency injection in a cross-platform mobile app.

> **Historical sample.** These projects use Xamarin.Forms and Prism 6.2. Xamarin.Forms
> has been succeeded by **.NET MAUI**, and Prism has newer releases — the concepts carry
> over but the packages and project structure have since changed.

## What's included

| Folder | What it demonstrates |
| --- | --- |
| `DeepNavigation` | Deep / hierarchical navigation between pages using Prism's `INavigationService`. |
| Additional folders | Further Prism scenarios such as dependency registration, view-model location and platform services. |

Each sample contains the shared Xamarin.Forms project plus the Android (`.Droid`) head.

## Prerequisites

- Visual Studio 2017 (or Visual Studio for Mac) with the **Mobile development with .NET (Xamarin)** workload
- Android SDK / emulator (and a Mac build host for iOS, where applicable)

## Getting started

1. Clone the repository.
2. Open the `.sln` inside the sample folder you want to run.
3. Restore NuGet packages, set the platform head as the startup project and run.

## Related resources

The demos accompany a series of blog posts on [blog.qmatteoq.com](https://blog.qmatteoq.com).

## License

Released under the [MIT License](LICENSE).
