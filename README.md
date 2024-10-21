# How to Read a Text with AzureOpenAI

## 1. Create an Azure OpenAI and deploy a tts model

We create an Azure OpenAI service

![image](https://github.com/user-attachments/assets/9ada8093-bcac-427b-acf1-e68519ff7e09)

We input the data definition

![image](https://github.com/user-attachments/assets/4c7629cb-7e08-44f3-afd0-42ca8e7033b8)

We verify the Azure OpenAI was created

![image](https://github.com/user-attachments/assets/a4dd9743-d547-463e-b5f7-32cbd7758289)

This is the tts model deployment

![image](https://github.com/user-attachments/assets/0314d263-9294-4daa-9a74-147fdb5ff324)

![image](https://github.com/user-attachments/assets/e2d78e86-fe43-4a8f-b018-9c0cedc6527e)

## 2. Create C# console application with Visual Studio 2022

This is the application source code:

```csharp
using Azure;
using Azure.AI.OpenAI;
using Azure.Identity;
using OpenAI.Audio;

var endpoint = new Uri("https://voiceaimodel.openai.azure.com");
var credentials = new AzureKeyCredential("71df94595ffa4b8ba3f3b39de2d80ae9");

var deploymentName = "tts";
string speechFilePath = "C:\\Autónomo\\speech_output.wav";

var openAIClient = new AzureOpenAIClient(endpoint, credentials);

var audioClient = openAIClient.GetAudioClient(deploymentName);

var result = await audioClient.GenerateSpeechAsync("Hello World",GeneratedSpeechVoice.Echo);

Console.WriteLine($"Streaming response to {speechFilePath}");

Directory.CreateDirectory(Path.GetDirectoryName(speechFilePath));

await File.WriteAllBytesAsync(speechFilePath, result.Value.ToArray());

Console.WriteLine("Finished streaming");
```

## 3. Run the application and see the results

![image](https://github.com/user-attachments/assets/f077281d-b2f7-40c9-94e6-69798fb83597)
