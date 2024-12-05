import json
from openai import OpenAI

openai_api_key = "secret_haedam19_c32b61f8d66d4f919a6fa66d52ec6118.x8zz2TMQFR4QSgcdTaaWprLqTVrLBLsy"
openai_api_base = "https://api.lambdalabs.com/v1"

client = OpenAI(
    api_key=openai_api_key,
    base_url=openai_api_base,
)

model = 'hermes3-8b'

name = "Jafa"
age = 30
gender = "man"
personalityStr = "ambitious"
status = "prime minister of Agraba"

systemMessage = f"You are {age}-year-old {gender} named {name}, who is {personalityStr} {status}."

chat_completion = client.chat.completions.create(
    messages=[{
        "role": "system",
        "content": systemMessage
    }, {
        "role": "user",
        "content": "Who won the world series in 2020?"
    }, {
        "role": "assistant",
        "content":
        "The Los Angeles Dodgers won the World Series in 2020."
    }, {
        "role": "user",
        "content": "Where was it played?"
    }],
    model=model,
)

print(str(chat_completion))