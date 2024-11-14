from pyvis.network import Network

# 네트워크 객체 생성  
net = Network(notebook=True)

# Character / NPC Nodes
net.add_node(1, label='Aladdin(Player)', color='#97c2fc')
net.add_node(2, label='Jasmine', color='#97c2fc')
net.add_node(3, label='Jafa', color='#97c2fc')
net.add_node(4, label='Dalia', color='#97c2fc')
net.add_node(5, label='Smith', color='#97c2fc')
net.add_node(6, label='Brown', color='#97c2fc')

net.add_node(11, label='Dragon', color='#6600cc')

net.add_node(21, label='Lamp', color='#ff9933')
net.add_node(22, label='Sword', color='#ff9933')
net.add_node(23, label='Iron', color='#ff9933')
net.add_node(24, label='Key', color='#ff9933')

net.add_node(31, label='Palace', color='#00cc00')
net.add_node(32, label='Field', color='#00cc00')
net.add_node(33, label='Market', color='#00cc00')
net.add_node(34, label='Mountain', color='#00cc00')
net.add_node(35, label='Cave', color='#00cc00')


# 엣지 추가
net.add_edge(2, 3)
net.add_edge(2, 31)
net.add_edge(3, 31)
net.add_edge(4, 31)
net.add_edge(2, 4)
net.add_edge(5, 6)
net.add_edge(21, 35)
net.add_edge(22, 23)
net.add_edge(24, 11)
net.add_edge(11, 34)
net.add_edge(24, 35)
net.add_edge(5, 33)
net.add_edge(6, 33)
net.add_edge(3, 21)
net.add_edge(23, 32)
net.add_edge(5, 22)
net.add_edge(11, 22)

# 네트워크 시각화
net.show('mygraph.html')