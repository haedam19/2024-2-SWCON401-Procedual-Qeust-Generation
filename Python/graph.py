from pyvis.network import Network

# 네트워크 객체 생성  
net = Network(notebook=True, directed=True)

# Character / NPC Nodes
net.add_node(1, label="1", color='#97c2fc')
net.add_node(2, label="2", color='#97c2fc')
net.add_node(3, label="3", color='#97c2fc')

net.add_node(11, label="11", color='#6600cc')

net.add_node(21, label="21", color='#ff9933')
net.add_node(22, label="22", color='#ff9933')
net.add_node(23, label="23", color='#ff9933')

net.add_node(31, label="31", color='#00cc00')


# 엣지 추가
net.add_edge(1, 21, title = "want")
net.add_edge(2, 11, title = "want to kill")
net.add_edge(11, 21, title = "has")
net.add_edge(11, 22, title = "cna be killed by")
net.add_edge(3, 22, title = "can make")
net.add_edge(22, 23, title = "is made of")
net.add_edge(23, 31, title = "is located on")

# 네트워크 시각화
net.show('mygraph.html')