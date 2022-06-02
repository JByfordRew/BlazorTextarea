# BlazorTextarea
Improved textarea component which solves slow typing user experience of standard textarea.

## What it does?
Blazor standard `textarea` value binding is slow in web assembly when a relatively small amount of characters are present.  This component overcomes this by using `StringBuilder` and a simple difference engine via Javascript interop to transfer the changes.  Generally you can expect 16x binding improvement with Web Assembly without AOT compilation and 1.5x with AOT.  Server-Side Blazor binding sees no significant improvement but the inbuilt batching mechanism solves the 'Connection disconnected' issue.

### Stats
Here are the limitations of the standard textarea binding compared to this improved Textarea component.  For reference, 5 x Lorum Ipsum paragraphs equals about 3,500 characters, this is about one web page screen full of text.
* non AOT, standard vs improved
  * repeated chars slows; 12,000 vs 200,000 (16x)
  * normal typing slows; 24,000 vs 400,000 (16x)
* AOT compiled, standard vs improved
  * repeated chars slows; 120,000 vs 200,000 (1.6x)
  * normal typing slows; 150,000 vs 400,000 (2.6x)

## Feature Summary
* Same parameters as standard textarea, just change to `Textarea`
* Up to 16x typing performance improvement.
* Get faster binding via batch updates as text changes, for example, large text pastes respond quicker if batched.
* Batching solves the 'Connection disconnected' error with Server-Side Blazor.
* Element reference to the underlying `textarea` provided.

## When to use?
Recommendations for when to use.
* Web Assembly
  * Batching updates - use if large text changes occur and your app needs to process and respond asynchronously to changes.
  * Binding performance - use standard textarea when AOT compilation used, due to only 50% improvement at very large character counts.
* Server-Side Blazor
  * Batching updates - SignalR default MaximumReceiveMessageSize 'Connection disconnected' issue. The inbuilt batching of this component was designed to overcome this issue but changing the default value will also solve it.
  * Binding performance - use standard textarea due to no performance improvement and standard textarea is more stable at extreme character counts.

## Installation
Latest version in here:  [![NuGet](https://img.shields.io/nuget/v/BlazorTextarea.svg)](https://www.nuget.org/packages/BlazorTextarea/)

```
Install-Package BlazorTextarea
```
or 
```
dotnet add package BlazorTextarea
```
  
## The API
The `Textarea` component provides the same interface as a standard textarea with added batch update options
* `value` - textarea value binding. i.e. `@bind-value=MyText` 
* `value:event` - textarea binding event. i.e. `@bind-value:event='oninput'`
* `UpdateBatchCount` - updates are sent in batches of characters (default 16,000 to fix Blazor Server SignalR default max receive message size limit).
* `BatchUpdates` - choose to receive updates via binding event on each batch of text sent (default false). 

### Server-Side Blazor 'Connection disconnected' issue
Here is some advice on this issue.

This issue can be resolved currently by changing the `MaximumReceiveMessageSize` or the SignalR Hub

```cs
builder.Services.AddServerSideBlazor()
    .AddHubOptions(o => o.MaximumReceiveMessageSize = null)
```

but, this component has batch updates built in to specifically solve this issue.  Nothing needs to be done to implement this as it has a built in `UpdateBatchCount` of 16,000 that updates the value binding without disconnecting the connection.

## Version History
* Version 1.0.0 initial release .NET 6 component.

## Roadmap
* None planned
