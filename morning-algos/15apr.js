/**
 * Class to represent a stack using an array to store the stacked items.
 * Follows a LIFO (Last In First Out) order where new items are stacked on
 * top (back of array) and removed items are removed from the top / back.
 */
class Stack {
	/**
	 * The constructor is executed when instantiating a new Stack() to construct
	 * a new instance.
	 * @returns {Stack} This new Stack instance is returned without having to
	 *    explicitly write 'return' (implicit return).
	 */
	constructor() {
		this.items = [];
	}

	/**
	 * Adds a new given item to the top / back of this stack.
	 * - Time: O(1) constant.
	 * - Space: O(1) constant.
	 * @param {any} item The new item to be added to the top / back.
	 * @returns {number} The new length of this stack.
	 */
	push(item) {
		this.items.push(item);
		return this.size();
	}

	/**
	 * Removes the top / last item from this stack.
	 * - Time: O(1) constant.
	 * - Space: O(1) constant.
	 * @returns {any} The removed item or undefined if this stack was empty.
	 */
	pop() {
		return this.items.pop();
	}

	/**
	 * Retrieves the top / last item from this stack without removing it.
	 * - Time: O(1) constant.
	 * - Space: O(1) constant.
	 * @returns {any} The top / last item of this stack.
	 */
	peek() {
		return this.items[this.items.length - 1];
	}

	/**
	 * Returns whether or not this stack is empty.
	 * - Time: O(1) constant.
	 * - Space: O(1) constant.
	 * @returns {boolean}
	 */
	isEmpty() {
		return this.items.length === 0;
	}

	/**
	 * Returns the size of this stack.
	 * - Time: O(1) constant.
	 * - Space: O(1) constant.
	 * @returns {number} The length.
	 */
	size() {
		return this.items.length;
	}
}

module.exports = Stack;
// Import our stack data structure to use in this file.
// const Stack = require("./Stack");

/**
 * Class to represent a Queue but is implemented using two stacks to store the
 * queued items without using any other objects or arrays to store the items.
 * Retains the FIFO (First in First Out) ordering when adding / removing items.
 */
class TwoStackQueue {
	constructor() {
		this.stack1 = new Stack();
		this.stack2 = new Stack();
	}

	/**
	 * Adds a new item to the back of the queue.
	 * - Time: O(?).
	 * - Space: O(?).
	 * @param {any} item To be added.
	 * @returns {number} The new number of items in the queue.
	 */
	enqueue(item) {
		this.stack1.push(item);
		return this.stack1.size();
	}

	/**
	 * Removes the next item in the line / queue.
	 * - Time: O(?).
	 * - Space: O(?).
	 * @returns {any} The removed item.
	 */
	dequeue() {
		var returnVal = 0;
		var firstFor = this.stack1.size();
		var secondFor = this.stack2.size();
		for (let i = 0; i < firstFor; i++) {
			this.sack2.push(this.stack1.pop());
		}
		returnVal = this.stack1.pop();

		for (let i = 0; i < secondFor; i++) {
			this.stack1.push(this.stack2.pop());
		}
		return returnVal;
	}
}
const firstQueue = new TwoStackQueue();
console.log(firstQueue.enqueue(1)); //[1] 1
console.log(firstQueue.enqueue(2)); //[1,2] 2
console.log(firstQueue.enqueue(3)); //[1,2,3] 3
console.log(firstQueue.enqueue(5)); //[1,2,3,5] 4
console.log(firstQueue.enqueue(8)); //[1,2,3,5,8] 5
console.log(firstQueue.enqueue(2)); //[1,2,3,5,8,2] 6
console.log(firstQueue.dequeue()); //[2,3,5,8,2] 5
console.log(firstQueue.dequeue()); //[3,5,8,2] 4
console.log(firstQueue.dequeue()); //[5,8,2] 3
console.log(firstQueue.dequeue()); //[8,2] 2
console.log(firstQueue.dequeue()); //[2] 1
// console.log(firstQueue.dequeue());
