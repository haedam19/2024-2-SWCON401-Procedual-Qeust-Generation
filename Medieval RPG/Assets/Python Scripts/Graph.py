from pyvis.network import Network

class Node:
    def __init__(self, id):
        self.id = id
        self.edges = None

    def __eq__(self, other):
        return self.id == other.id

class Edge:
    def __init__(self, s_id, e_id):
        self.s_id = s_id
        self.e_id = e_id
        self.values = list()

class Graph:
    def __init__(self):
        self.nodeCount = 0
        self.nodeSet = set()

    def searchNode(self, id):
        for node in self.nodeSet:
            if node.id == id:
                return node
        return None
    
    def addNode(self, id):
        if self.searchNode(id) == None:
            self.nodeSet.add(Node(id))
            return True
        else:
            return False
    