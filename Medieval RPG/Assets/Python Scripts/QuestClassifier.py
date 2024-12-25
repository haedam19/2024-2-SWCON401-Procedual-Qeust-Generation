import spacy
from spacy.util import get_installed_models
import classy_classification

QUEST_TYPE = ["Exploration", "Combat", "Gathering"]

# print(get_installed_models())

data = dict()

for type in QUEST_TYPE:
    with open("ClassificationData/" + type + ".txt", 'r') as f:
        samples = f.read().splitlines()
        data[type] = samples

print("Create NLP object...", end='')
nlp = spacy.load("en_core_web_md")
print("OK")
print("Add classification pipeline...", end='')
nlp.add_pipe(
    "classy_classification", 
    config={
        "data": data
    }
)
print("OK", end='\n\n')

def ClassifyInput(msg):
    probabilities = nlp(msg)._.cats
    maxType = "Unknown"
    maxValue = 0
    for type in QUEST_TYPE:
        if (probabilities[type] > maxValue and probabilities[type] >= 0.4):
            maxType = type
            maxValue = probabilities[type]
    return maxType
