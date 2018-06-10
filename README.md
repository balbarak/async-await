# Introduction

This repository demonstrate the difference between using `async/await` and `Task` in `C#` 

The sample project using `WPF` application

# Sample

The sample project has a `DataService` class with a method called `GetData(string url)` that return `Task<WebResult>`

This method will be invoked using two differents approach:

* First using `async` keyword in the caller method
* Second using `Task.ContinueWith` without using `aysnc` keyword

`Note:` the method `GetData` has an `await` with `ConfigureAwait(false)` 
which means the caller `thread` of the method and the `thread` that will continue the rest of method after `await` might not be the same thead.
