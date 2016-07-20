namespace NetworkService

module WebClient = 
    //#if INTERACTIVE
    //#r @"/Users/johnnash/Projects/FsharpTest/FsharpTest/bin/Debug/Newtonsoft.Json.dll"
    //#endif

    open System.Text
    open System.IO
    open System.Net
    open Newtonsoft.Json
    open System.Collections.Generic
    open Microsoft.FSharp.Quotations.Patterns

    
    
    // URL of a simple page that takes two HTTP POST parameters. See the
    // form that submits there: http://www.snee.com/xml/crud/posttest.html
    let url = "https://api.projectoxford.ai/emotion/v1.0/recognize"
    let imageUrl = "{\"url\": \"https://s-media-cache-ak0.pinimg.com/736x/08/15/db/0815db06df850e27e74411a3232ffa3e.jpg\"}"
    //let imageUrl = "{\"url\": \"http://i.dailymail.co.uk/i/pix/2014/08/29/1409331226296_Image_galleryImage_17_Jan_2013_Businessman_y.JPG\"}"
    let OcpApimSubscriptionKey = "6fffa85f17474f62bf6958c22c7c2333"
    let headerName = "Ocp-Apim-Subscription-Key"
    
    // Create & configure HTTP web request
    let req = HttpWebRequest.Create(url) :?> HttpWebRequest 
    do req.ProtocolVersion <- HttpVersion.Version10
    do req.Method <- "POST"
    let header = new WebHeaderCollection()
    header.Add(headerName, OcpApimSubscriptionKey)
    req.Headers <- header

    //Encode body with POST data as array of bytes
    let postBytes = Encoding.ASCII.GetBytes(imageUrl)
    do req.ContentType <- "application/json";
    do req.ContentLength <- int64 postBytes.Length
    
     //Write data to the request
    let reqStream = req.GetRequestStream() 
    do reqStream.Write(postBytes, 0, postBytes.Length);
    do reqStream.Close()
    
    // Obtain response and download the resulting page 
    // (The sample contains the first & last name from POST data)
    let resp = req.GetResponse() 
    let stream = resp.GetResponseStream() 
    let reader = new StreamReader(stream) 
    let html = reader.ReadToEnd()


    
    

