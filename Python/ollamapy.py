import ollama

myText = 'Hello, can you explain where am I?'
response = ollama.chat(model='ALIENTELLIGENCE/gamemasterroleplaying', messages=[{'role': 'user','content': myText,},])
print(response['message']['content'])