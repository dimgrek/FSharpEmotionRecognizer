namespace FsharpTest

open Xamarin.Forms

type App() = 
    inherit Application()
    let stack = StackLayout(VerticalOptions = LayoutOptions.Center)
    let label = Label(XAlign = TextAlignment.Center, Text = "Welcome to F# Xamarin.Forms!")
    let sendButton = Button(Text = "Send picture" )
    do 
        stack.Children.Add(label)
        stack.Children.Add(sendButton)
        base.MainPage <- ContentPage(Content = stack)

