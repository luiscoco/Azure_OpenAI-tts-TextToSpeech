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