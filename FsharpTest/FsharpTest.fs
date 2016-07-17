namespace FsharpTest

open Xamarin.Forms
open Microsoft.ProjectOxford.Emotion
open Microsoft.ProjectOxford.Emotion.Contract
open System

type App() = 
    inherit Application()
    let uri = "https://www.xamarin.com/content/images/pages/forms/example-app.png"
    let subscriptionKey = "40778dfbd2884ee4870526cf17cc15bd"
    let mutable number = 0
    let stack = StackLayout(VerticalOptions = LayoutOptions.Center)
    let label = Label(XAlign = TextAlignment.Center, Text = "Emotion Recognizer")
    let downloaded = Label(XAlign = TextAlignment.Center, Text = "Downloaded Image")
    let webImage = Image(Aspect = Aspect.AspectFit, Source = ImageSource.FromUri(Uri(uri)))
    let result = Label(XAlign = TextAlignment.Center, Text = "Emotion will be stated here")
    

    let sendButton = Button(Text = "Send picture")

    let log (logMessage:string) = 
        match String.IsNullOrEmpty(logMessage) || logMessage = "\n" with
        | true -> result.Text <- result.Text + "\n"
        | false -> result.Text <- result.Text + "[" + DateTime.Now.ToString("HH:mm:ss.ffffff")  + "]: " + logMessage + "\n" 
        

    let UploadAndDetectEmotions(url:string) = EmotionServiceClient(subscriptionKey)

    let emotion = async {
        let emotionClientService = new EmotionServiceClient(subscriptionKey)
        emotionClientService.RecognizeAsync(uri)}

    

    let logEmotionResult (emotionResult : Emotion[]) = 
        let emotionResultCount = 0
        match emotionResult<> null && emotionResult.Length>0 wih
        | true -> for emotion in emotionResult do log("Emotion[" + emotionResultCount.ToString() + "]")
        | false -> log("No emotion is detected. This might be due to:\n" + "    image is too small to detect faces\n" + "    no faces are in the images\n" + "    faces poses make it difficult to detect emotions\n" + "    or other factors")
    
    let Async.StartAsTask <| emotion


    //do sendButton.Clicked.Add(fun _->
    //do result.Text <- UploadAndDetectEmotions uri)

    //do sendButton.Clicked.Add(fun _ -> 
    //number <- number + 1
    //do timesClicked.Text<- sprintf "%i times clicked" number)




    do 
        stack.Children.Add(label)
        stack.Children.Add(downloaded)
        stack.Children.Add(webImage)
        stack.Children.Add(sendButton)
        base.MainPage <- ContentPage(Content = stack)

