# Grid Table

I [found there is no a Grid control](https://forums.xamarin.com/discussion/2397/how-to-display-multiple-columns-in-a-uitableview) on Xamarin ios base controls, but you can build one, so, I decided to use the code showed on the previous link and learn something new.

I googled all of my doubts and read [xamarin's docs](https://developer.xamarin.com/guides/ios/user_interface/tables/) on this topic and ended up with this implementation.

Some things I learned include:

- [Rx ObserveOn](https://forums.xamarin.com/discussion/9496/how-can-i-get-the-ui-synchronization-context-for-rx-subscribeon)
- I don't know why, but if you want to refresh the table data, [sometimes you must reset the table `DataSource`](http://stackoverflow.com/a/8207287/1229323) 
- Tooling [isn't ready](https://forums.xamarin.com/discussion/27308/debugger-doesnt-work-frame-not-in-module) and is so frustrating to work with the Mac Agent and those things.

### Disclamer

I've not tested this on real device and I'm not sure [if it works out of emulator](https://forums.xamarin.com/discussion/16547/getviewforheader-works-in-the-simulator-but-not-working-on-the-device)

### Usage 

Checkout the two implementations, the first one is Two Columns Grid and the other one is multicolumn, using some reflection. To change the view set the controller on AppDelegate.
