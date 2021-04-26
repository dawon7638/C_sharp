/**
 * Class to represents a single item of a SinglyLinkedList that can be
 * linked to other Node instances to form a list of linked nodes.
 */
class Node {
	/**
	 * Constructs a new Node instance. Executed when the 'new' keyword is used.
	 * @param {any} data The data to be added into this new instance of a Node.
	 *    The data can be anything, just like an array can contain strings,
	 *    numbers, objects, etc.
	 * @returns {Node} A new Node instance is returned automatically without
	 *    having to be explicitly written (implicit return).
	 */
	constructor(data) {
		this.data = data;
		/**
		 * This property is used to link this node to whichever node is next
		 * in the list. By default, this new node is not linked to any other
		 * nodes, so the setting / updating of this property will happen sometime
		 * after this node is created.
		 */
		this.next = null;
	}
}

/**
 * Class to represent a list of linked nodes. Nodes CAN be linked together
 * without this class to form a linked list, but this class helps by providing
 * a place to keep track of the start node (head) of the list at all times and
 * as a place to add methods (functions inside an object) so that every new
 * linked list that is instantiated will inherit helpful the same helpful
 * methods, just like every array you create inherits helpful methods.
 */
class SinglyLinkedList {
	/**
	 * Constructs a new instance of an empty linked list that inherits all the
	 * methods.
	 * @returns {SinglyLinkedList} The new list that is instantiated is implicitly
	 *    returned without having to explicitly write "return".
	 */
	constructor() {
		this.head = null;
	}

	/**
	 * Determines if this list is empty.
	 * - Time: O(1) constant.
	 * - Space: O(1) constant.
	 * @returns {boolean}
	 */
	isEmpty() {
		return this.head === null;
	}

	/**
	 * Creates a new node with the given data and inserts it at the back of
	 * this list.
	 * - Time: O(n) linear, n = length of list.
	 * - Space: O(1) constant.
	 * @param {any} data The data to be added to the new node.
	 * @returns {SinglyLinkedList} This list.
	 */
	insertAtBack(data) {
		const newNode = new Node(data);

		// Empty list, add first node.
		if (this.head === null) {
			this.head = newNode;
			return this;
		}

		let runner = this.head;

		while (runner.next !== null) {
			runner = runner.next;
		}

		// After loop, runner is on the last node.
		runner.next = newNode;
		return this;
	}

	/**
	 * Calls insertAtBack on each item of the given array.
	 * - Time: O(n * m) n = list length, m = arr.length.
	 * - Space: O(1) constant.
	 * @param {Array<any>} vals The data for each new node.
	 * @returns {SinglyLinkedList} This list.
	 */
	seedFromArr(vals) {
		for (const item of vals) {
			this.insertAtBack(item);
		}
		return this;
	}

	/**
	 * Converts this list into an array containing the data of each node.
	 * - Time: O(n) linear.
	 * - Space: O(n).
	 * @returns {Array<any>} An array of each node's data.
	 */
	toArr() {
		const arr = [];
		let runner = this.head;

		while (runner) {
			arr.push(runner.data);
			runner = runner.next;
		}
		return arr;
	}

	/**
	 * Creates a new node with the given data and inserts that node at the front
	 * of the list.
	 * - Time: O(1) constant.
	 * - Space: O(1) constant.
	 * @param {any} data The data for the new node.
	 * @returns {SinglyLinkedList} This list.
	 */
	insertAtFront(data) {
		const newHead = new Node(data);
		newHead.next = this.head;
		this.head = newHead;
		return this;
	}

	/**
	 * Removes the first node of this list.
	 * - Time: O(1) constant.
	 * - Space: O(1) constant.
	 * @returns {any} The data from the removed node.
	 */
	removeHead() {
		if (this.isEmpty()) {
			return null;
		}

		const oldHead = this.head;
		this.head = oldHead.next;
		return oldHead.data;
	}

	/**
	 * Calculates the average of this list.
	 * - Time: O(n) linear, n = length of list.
	 * - Space: O(1) constant.
	 * @returns {number|NaN} The average of the node's data.
	 */
	average() {
		let runner = this.head;
		let sum = 0;
		let cnt = 0;

		while (runner) {
			cnt++;
			sum += runner.data;
			runner = runner.next;
		}

		/**
		 * Dividing by 0 will give you NaN (Not a Number), so an empty list
		 * will return NaN in this case, it may make sense to allow NaN to be
		 * returned, because the average of an empty list doesn't make sense and
		 * it could be misleading to return 0 since 0 is the average of any
		 * list with a sum of 0 (due to negatives or all zeros).
		 */
		return sum / cnt;
	}

	/**
	 * Determines whether or not the given search value exists in this list.
	 * - Time: O(n) linear, n = length of list.
	 * - Space: O(1) constant.
	 * @param {any} val The data to search for in the nodes of this list.
	 * @returns {boolean}
	 */
	contains(val) {
		let runner = this.head;

		while (runner) {
			if (runner.data === val) {
				return true;
			}
			runner = runner.next;
		}
		return false;
	}

	/**
	 * Determines whether or not the given search value exists in this list.
	 * - Time: O(n) linear, n = length of list.
	 * - Space: O(1) constant.
	 * @param {any} val The data to search for in the nodes of this list.
	 * @param {?node} current The current node during the traversal of this list
	 *    or null when the end of the list has been reached.
	 * @returns {boolean}
	 */
	containsRecursive(val, current = this.head) {
		if (current === null) {
			return false;
		}
		if (current.data === val) {
			return true;
		}
		return this.containsRecursive(val, current.next);
	}

	/**
	 * Removes the last node of this list.
	 * - Time: O(n) linear, n = length of list.
	 * - Space: O(1) constant.
	 * @returns {any} The data from the node that was removed.
	 */
	removeBack() {
		if (this.isEmpty()) {
			return null;
		}

		// Only 1 node.
		if (this.head.next === null) {
			return this.removeHead();
		}

		// More than 1 node.
		let runner = this.head;

		while (runner.next.next) {
			runner = runner.next;
		}

		// after while loop finishes, runner is now at 2nd to last node
		const removedData = runner.next.data;
		runner.next = null; // remove it from list
		return removedData;
	}

	/**
	 * Removes the last node of this list.
	 * - Time: O(n) linear, n = length of list.
	 * - Space: O(1) constant.
	 * @returns {any} The data from the node that was removed.
	 */
	removeBack2() {
		let removedData = null;

		if (!this.isEmpty()) {
			if (this.head.next === null) {
				// head only node
				removedData = this.head.data;
				this.head = null; // remove it from list
			} else {
				let runner = this.head;
				// right of && will only be checked if left is true
				while (runner.next && runner.next.next) {
					runner = runner.next;
				}

				// after while loop finishes, runner is now at 2nd to last node
				removedData = runner.next.data;
				runner.next = null; // remove it from list
			}
		}
		return removedData;
	}

	/**
	 * Retrieves the data of the second to last node in this list.
	 * - Time: (?).
	 * - Space: (?).
	 * @returns {any} The data of the second to last node or null if there is no
	 *    second to last node.
	 */
	secondToLast() {
		// If empty or 1 node only.
		if (this.isEmpty() || this.head.next === null) {
			return null;
		}

		// More than 1 node.
		let runner = this.head;

		while (runner.next.next) {
			runner = runner.next;
		}

		// after while loop finishes, runner is now at 2nd to last node
		return runner.data;
	}

	/**
	 * Removes the node that has the matching given val as it's data.
	 * - Time: (?).
	 * - Space: (?).
	 * @param {any} val The value to compare to the node's data to find the
	 *    node to be removed.
	 * @returns {boolean} Indicates if a node was removed or not.
	 */
	removeVal(val) {
		if (this.isEmpty()) {
			return false;
		}

		if (this.head.data === val) {
			this.removeHead();
			return true;
		}

		let runner = this.head;

		while (runner.next.next) {
			if (runner.next.data === val) {
				// runner is 1 node before the node to be removed.
				runner.next = runner.next.next;
				return true;
			}
			runner = runner.next;
		}

		// No matching data found.
		return false;
	}

	/**
	 * Inserts a new node before a node with that has a specified value.
	 * - Time: O(n) linear, n = list length, because we could end up pre-pending
	 *    to the last node.
	 * - Space: O(1) constant.
	 * @param {any} newVal The value to use for the new node that is being added.
	 * @param {any} targetVal The value to use to find the node that the newVal
	 *    should be inserted in front of.
	 * @returns {boolean} To indicate whether the node was prepended or not.
	 */
	prepend(newVal, targetVal) {
		const newNode = new Node(newVal);

		if (this.isEmpty()) {
			return false;
		}

		if (this.head.data === targetVal) {
			newNode.next = this.head;
			this.head = newNode;
			return true;
		}

		// we already know we're not going to need to prepend before the head
		let runner = this.head;

		while (runner) {
			// End of list and not found.
			if (runner.next === null) {
				return false;
			}

			if (runner.next.data === targetVal) {
				newNode.next = runner.next;
				runner.next = newNode;
				return true;
			}
			runner = runner.next;
		}
	}

	/**
	 * Concatenates the nodes of a given list onto the back of this list.
	 * - Time: O(n) n = "this" list length -> O(n) linear.
	 *    addList does not need to be looped over.
	 * - Space: O(1) constant, although this list grows by addList's length,
	 *    our algo doesn't create extra objects or arrays to take up more space.
	 * @param {SinglyLinkedList} addList An instance of a different list whose
	 *    whose nodes will be added to the back of this list.
	 * @returns {SinglyLinkedList} This list with the added nodes.
	 */
	concat(addList) {
		let runner = this.head;

		if (runner === null) {
			this.head = addList.head;
		} else {
			while (runner.next) {
				runner = runner.next;
			}
			runner.next = addList.head;
		}
		return this;
	}

	/**
	 * Finds the node with the smallest number as data and moves it to the front
	 * of this list.
	 * - Time: O(2n) n = list length -> O(n) linear,
	 *    2nd loop could go to end if min is at end.
	 * - Space: O(1) constant.
	 * @returns {SinglyLinkedList} This list.
	 */
	moveMinToFront() {
		/* 
        Alternatively, we could swap the data only in min node and head,
        but it's better to swap the nodes themselves in case anyone has variables
        pointing to these nodes already so that we don't unexpectedly change the
        the data in those nodes potentially causing unwanted side-effects.
      */
		if (this.isEmpty()) {
			return this;
		}

		let minNode = this.head;
		let runner = this.head;
		let prev = this.head;

		while (runner) {
			if (runner.data < minNode.data) {
				minNode = runner;
			}

			runner = runner.next;
		}
		// now that we know the min, if it is already the head, nothing needs to be done
		if (minNode === this.head) {
			return this;
		}

		runner = this.head;

		while (runner !== minNode) {
			prev = runner;
			runner = runner.next;
		}

		prev.next = minNode.next; // remove the minNode
		minNode.next = this.head;
		this.head = minNode;
		return this;
	}

	/**
	 * Finds the node with the smallest data and moves it to the front of
	 * this list.
	 * - Time: O(n) linear, n = list length. This avoids the extra loop in
	 *    the above sln.
	 * - Space: O(n) linear.
	 * @returns {SinglyLinkedList} This list.
	 */
	moveMinFront() {
		if (this.isEmpty()) {
			return this;
		}

		let minNode = this.head;
		let runner = this.head;
		let prev = this.head;

		while (runner) {
			if (runner.data < minNode.data) {
				minNode = runner;
			}

			// make sure the prev stays the prev of minNode
			// if minNode is last node, we don't want prev to become the runner
			if (prev.next !== minNode && runner.next !== null) {
				prev = runner;
			}
			runner = runner.next;
		}

		if (minNode === this.head) {
			return this;
		}

		prev.next = minNode.next;
		minNode.next = this.head;
		this.head = minNode;
		return this;
	}

	/**
	 * Reverses this list in-place without using any extra lists.
	 * - Time: O(n) linear, n = list length.
	 * - Space: O(1) constant.
	 * @returns {SinglyLinkedList} This list.
	 */
	reverse() {
		/*
        Each iteration we cut out current's next node to make it the new head
        iteration-by-iteration example:
  
        1234 -> initial list, 'current' is 1, next is 2.
        2134 -> 'current' is still 1, next is 3.
        3214
        4321
      */
		if (!this.head || !this.head.next) {
			return this;
		}

		let current = this.head;

		while (current.next) {
			const newHead = current.next;
			// cut the newHead out from where it currently is
			current.next = current.next.next;
			newHead.next = this.head;
			this.head = newHead;
		}
		return this;
	}

	// TODO: iteration by iteration comment example of swaps.
	reverse2() {
		let prev = null;
		let node = this.head;

		while (node) {
			const nextNode = node.next;
			node.next = prev;
			prev = node;
			node = nextNode;
		}
		this.head = prev;
		return this;
	}

	/**
	 * Determines whether the list has a loop in it which would result in
	 * infinitely traversing unless otherwise avoided. A loop is when a node's
	 * next points to a node that is behind it.
	 * - Time: O(n) linear, n = list length.
	 * - Space: O(1) constant.
	 * @returns {boolean} Whether the list has a loop or not.
	 */
	hasLoop() {
		/**
        APPROACH:
        two runners are sent out and one runner goes faster so it will
        eventually 'lap' the slower runner if there is a loop, 
        at the moment faster runner laps slower runner, they are at the same
        place, aka same instance of a node.
      */
		if (!this.head) {
			return false;
		}

		let fasterRunner = this.head;
		let runner = this.head;

		while (fasterRunner && fasterRunner.next) {
			runner = runner.next;
			fasterRunner = fasterRunner.next.next;

			if (runner === fasterRunner) {
				return true;
			}
		}
		return false;
	}

	/**
	 * Determines whether the list has a loop in it which would result in
	 * infinitely traversing unless otherwise avoided.
	 * In a normal object, the keys cannot be other objects, but in a Map object,
	 * they can be. We can't use the .data as the keys in a normal object because
	 * that would could cause hasLoop to return a false positive when there are
	 * nodes with duplicate data but no loop.
	 * - Time: O(n) linear, n = list length.
	 * - Space: O(1) constant.
	 * @returns {boolean} Whether the list has a loop or not.
	 */
	hasLoopMap() {
		if (this.isEmpty()) {
			return false;
		}

		const seenMap = new Map();
		let runner = this.head;

		while (runner) {
			if (seenMap.has(runner)) {
				return true;
			}
			seenMap.set(runner, true);
			runner = runner.next;
		}
		return false;
	}

	/**
	 * Determines whether the list has a loop in it which would result in
	 * infinitely traversing unless otherwise avoided.
	 * This approaches adds a seen key to the nodes, then removes them when done.
	 * - Time: O(2n) -> O(n) linear. The 2nd loop is to remove the extra seen key
	 *    that was added.
	 * - Space: O(n) because "seen" key is being stored n times.
	 * @returns {boolean} Whether the list has a loop or not.
	 */
	hasLoopSeen() {
		if (this.isEmpty()) {
			return false;
		}

		let runner = this.head;
		let hasLoop = false;

		while (runner) {
			if (runner.hasOwnProperty("seen")) {
				hasLoop = true;
				break;
			} else {
				runner.seen = true;
			}
			runner = runner.next;
		}

		runner = this.head;

		while (runner && runner.hasOwnProperty("seen")) {
			delete runner.seen;
			runner = runner.next;
		}
		return hasLoop;
	}

	/**
	 * Removes all the nodes that have a negative integer as their data.
	 * - Time: O(n) linear, n = list length.
	 * - Space: O(1) constant.
	 * @returns {SinglyLinkedList} This list after the negatives are removed.
	 */
	removeNegatives() {
		if (this.isEmpty()) {
			return this;
		}

		let runner = this.head;

		// get rid of all negatives at start so head will be positive, or null
		while (runner && runner.data < 0) {
			runner = runner.next;
		}

		this.head = runner;

		//  head may have become null, that's why we check runner && runner.next
		while (runner && runner.next) {
			if (runner.next.data < 0) {
				runner.next = runner.next.next;
			} else {
				runner = runner.next;
			}
		}
		return this;
	}
}

const emptyList = new SinglyLinkedList();
const singleNodeList = new SinglyLinkedList().insertAtBack(1);
const biNodeList = new SinglyLinkedList().insertAtBack(1).insertAtBack(2);
const firstThreeList = new SinglyLinkedList().seedFromArr([1, 2, 3]);
const secondThreeList = new SinglyLinkedList().seedFromArr([4, 5, 6]);
const unorderedList = new SinglyLinkedList().seedFromArr([
	-5,
	-10,
	4,
	-3,
	6,
	1,
	-7,
	-2,
]);

// // node 4 connects to node 1, back to head
const perfectLoopList = new SinglyLinkedList().seedFromArr([1, 2, 3, 4]);
perfectLoopList.head.next.next.next = perfectLoopList.head;

// // node 4 connects to node 2
const loopList = new SinglyLinkedList().seedFromArr([1, 2, 3, 4]);
loopList.head.next.next.next = loopList.head.next;

const sortedDupeList = new SinglyLinkedList().seedFromArr([
	1,
	1,
	1,
	2,
	3,
	3,
	4,
	5,
	5,
]);

console.log(emptyList.removeVal(5), "should equal", false);
console.log(singleNodeList.removeVal(1), "should equal", true);
console.log(singleNodeList.toArr(), "should be empty list");
console.log(biNodeList.removeVal(5), "should equal", false);
console.log(firstThreeList.removeVal(2), "should equal", true);
console.log(firstThreeList.toArr(), "2 should be removed");
