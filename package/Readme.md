# Console Hyperlinks

## How to use 💡
1) Decorate a static method that accepts two string arguments with a ``Needle.HyperlinkCallback`` attribute with a ``void`` or ``bool`` return type (return ``true`` if your implementation handled the provided ``path`` and no other callbacks should be called).

   ```csharp
   [Needle.HyperlinkCallback]
   private static bool OnHyperlinkClicked(string path, string line)
   ```

2) That's it. Now when you log something to the console using the following pattern you will receive a callback: ``<a href=\"My callback string">My clickable link</a>``. 

You can implement anything you like as a link of course. A default implementation for urls is already provided with the package.

You can also just use the handy ``LinkTo(string url)`` extension method like this: ``"Open Unity Website".LinkTo("https://www.unity.com")``



## Contact ✒️
<b>[🌵 needle — tools for unity](https://needle.tools)</b> • 
[@NeedleTools](https://twitter.com/NeedleTools) • 
[@marcel_wiessler](https://twitter.com/marcel_wiessler) • 
[@hybridherbst](https://twitter.com/hybridherbst) • 
[Needle Discord](https://discord.gg/CFZDp4b)

