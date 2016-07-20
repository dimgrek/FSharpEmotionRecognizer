namespace FsharpTest

open Xamarin.Forms
open System.Text
open System.IO
open System.Net
open System
open FSharp.Data

type App() = 
    inherit Application()
    let uri = "https://s-media-cache-ak0.pinimg.com/736x/08/15/db/0815db06df850e27e74411a3232ffa3e.jpg"
    let subscriptionKey = "40778dfbd2884ee4870526cf17cc15bd"
    let scroll = ScrollView()
    let stack = StackLayout(VerticalOptions = LayoutOptions.Center, Padding = new Thickness(5.0, 20.0, 5.0, 5.0))
    let label = Label(XAlign = TextAlignment.Center, Text = "Emotion Recognizer")
    let webImage = Image(Aspect = Aspect.AspectFit, Source = ImageSource.FromUri(Uri(uri)))
    let sendButton = Button(Text = "Send picture")
    let statusLabel = Label(XAlign = TextAlignment.Center, Text = "Emotion will be stated here")
    


    //let log (logMessage:string) = 
    //    match String.IsNullOrEmpty(logMessage) || logMessage = "\n" with
    //    | true -> statusLabel.Text <- statusLabel.Text + "\n"
    //    | false -> statusLabel.Text <- statusLabel.Text + "[" + DateTime.Now.ToString("HH:mm:ss.ffffff")  + "]: " + logMessage + "\n" 
        

    //let UploadAndDetectEmotions(url:string) = EmotionServiceClient(subscriptionKey)

    //let emotion = 
    //    let emotionClientService = new EmotionServiceClient(subscriptionKey)
    //    try
    //    emotionClientService.RecognizeAsync(uri)
    //    with
    //    | ex -> statusLabel.Text <- ex.Message ; null

    
    //let logEmotionResult (emotionResult : Emotion[]) = 
    //    let emotionResultCount = 0
    //    match emotionResult<> null && emotionResult.Length>0 with
    //    | true -> for emotion in emotionResult do log("Emotion[" + emotionResultCount.ToString() + "]")
    //    | false -> log("No emotion is detected. This might be due to:\n" + "    image is too small to detect faces\n" + "    no faces are in the images\n" + "    faces poses make it difficult to detect emotions\n" + "    or other factors")
    
    


    //do sendButton.Clicked.Add(fun _ ->)





    do 
        stack.Children.Add(label)
        stack.Children.Add(webImage)
        stack.Children.Add(sendButton)
        stack.Children.Add(scroll)
        scroll.Content <- statusLabel
        base.MainPage <- ContentPage(Content = stack)

