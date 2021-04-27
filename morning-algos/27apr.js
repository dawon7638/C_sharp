/* 
- A Doubly Linked List is a singly linked list with the added functionality of being able to traverse in both directions.
- Since you can traverse forwards or backwards, that means you should be able to start at the head or tail (end). After creating the necessary classes, then build the following methods:
- Create the node class that allows for forwards and backwards traversal.
- insertAtFront
  - Given some new data, add it as the new head
- insertAtBack
  - Given some new data, add it to the back of the DList
- removeMiddleNode
*/
class Node {
	constructor(data) {
		this.data = data;
		this.next = null;
		this.prev = null;
	}
}

class DoublyLinkList {
	constructor() {
		this.head = null;
		this.tail = null;
	}

	insertAtFront(data) {
		const newHead = new Node(data);

		if (this.head === null) {
			this.head = newHead;
			this.tail = newHead;
			return this;
		}
		this.head.prev = newHead;
		newHead.next = this.head;
		this.head = newHead;
		return this;
	}
	insertAtBack(data) {
		const newTail = new Node(Data);
		if (this.tail === null) {
			this.head = newTail;
			this.tail = newTail;
			return this;
		}
		this.tail.next = newTail;
		newTail.prev = this.newTail;
		this.tail = newTail;
		return this;
	}
    removeMiddleNode(){
        
    }
}
