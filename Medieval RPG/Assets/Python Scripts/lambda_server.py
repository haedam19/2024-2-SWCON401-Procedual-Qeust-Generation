import json
import UdpComms as U
import time
from openai import OpenAI
import QuestClassifier

openai_api_key = "secret_haedam19_c32b61f8d66d4f919a6fa66d52ec6118.x8zz2TMQFR4QSgcdTaaWprLqTVrLBLsy"
openai_api_base = "https://api.lambdalabs.com/v1"

client = OpenAI(
    api_key=openai_api_key,
    base_url=openai_api_base,
)

model = 'hermes3-405b'

sock = U.UdpComms(udpIP="127.0.0.1", portTX=8000, portRX=8001, enableRX=True, suppressWarnings=True)

id = 2
path = "D:/2024-2-SWCON401-Procedual-Qeust-Generation/Medieval RPG/Assets/JSON Data/"

i = 0

while True:
    timedata = "Server is running for " + str(i) + " secs."
    data = sock.ReadReceivedData() # read data

    elem = []
    questType = QuestClassifier.ClassifyInput(data)
    if questType == "Exploration":
        elem = ["place to visit", "person to meet"]
    elif questType == "Gathering":
        elem = ["number to collect", "item to collect", "source of item or location of item"]
    elif questType == "Combat":
        elem = ["number to kill", "target to kill", "reward"]



    if (id > 2):
        break

with open(path + f'Character_{id}.json', 'r') as f:
    characterData = json.load(f)
    print(characterData)

# Process character data
name = characterData["characterName"]
age = characterData["age"]
gender = "woman"
personalityStr = characterData["personalities"][0]
if len(characterData["personalities"]) > 1:
    for p in characterData["personalities"][1:]:
        personalityStr += ", " + p
status = characterData["status"][0]
if len(characterData["status"]) > 1:
    for p in characterData["status"][1:]:
        status += ", " + p











systemMessage = f"You are {age}-year-old {gender} named {name}, who is {personalityStr} {status}."
completionMSG = [{"role": "system", "content": systemMessage}]
completionMSG.append({"role": "user", "content": "Hi, can I ask you something?"})
completionMSG.append({"role": "assistant", "content": "Sure, what is it?"})
completionMSG.append({"role": "user", "content": "I want the treasure. How can I get it?"})

chat_completion = client.chat.completions.create(
    messages=completionMSG,
    model=model,
)

print(str(chat_completion))