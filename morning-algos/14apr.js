const Stack = require("./Stack");

/**
 * Class to represent a queue using an array to store the queued items.
 * Follows a FIFO (First In First Out) order where new items are added to the
 * back and items are removed from the front.
 */
/**
 * Class to represent a queue using an array which follows a FIFO
 * (First In First Out) order. New items are added to the back and items are
 * removed from the front.
 */
class Queue {
	/**
	 *
	 * @param {Array<any>} items The starting items, useful for if you already
	 *    have an array of items in the right order and want to convert it to a
	 *    queue instance to get access to the queue methods.
	 */
	constructor(items = []) {
		this.items = items;
	}

	/**
	 * Adds a new given item to the back of this queue.
	 * - Time: O(1) constant.
	 * - Space: O(1) constant.
	 * @param {any} item The new item to add to the back.
	 * @returns {number} The new size of this queue.
	 */
	enqueue(item) {
		this.items.push(item);
		return this.size();
	}

	/**
	 * Removes and returns the first item of this queue.
	 * - Time: O(n) linear, due to having to shift all the remaining items to
	 *    the left after removing first elem.
	 * - Space: O(1) constant.
	 * @returns {any} The first item or undefined if empty.
	 */
	dequeue() {
		return this.items.shift();
	}

	/**
	 * Retrieves the first item without removing it.
	 * - Time: O(1) constant.
	 * - Space: O(1) constant.
	 * @returns {any} The first item or undefined if empty.
	 */
	front() {
		return this.items[0];
	}

	/**
	 * Returns whether or not this queue is empty.
	 * - Time: O(1) constant.
	 * - Space: O(1) constant.
	 * @returns {boolean}
	 */
	isEmpty() {
		return this.items.length === 0;
	}

	/**
	 * Retrieves the size of this queue.
	 * - Time: O(1) constant.
	 * - Space: O(1) constant.
	 * @returns {number} The length.
	 */
	size() {
		return this.items.length;
	}

	/**
	 * Compares this queue to another given queue to see if they are equal.
	 * Avoid indexing the queue items directly via bracket notation, use the
	 * queue methods instead for practice.
	 * Use no extra array or objects.
	 * The queues should be returned to their original order when done.
	 * - Time: O(n^2) quadratic, n = queue length. Quadratic due to dequeue on an
	 *     array queue being O(n).
	 * - Space: O(1) constant.
	 * @param {Queue} q2 The queue to be compared against this queue.
	 * @returns {boolean} Whether all the items of the two queues are equal and
	 *    in the same order.
	 */

	compareQueues(q2) {
        if (this.size() !== q2.size()) {
            return false;
        }
        var result = true;

        for (let i = 0; i < this.size(); i++) {
            var q1Data = this.dequeue();    
            var q2Data = q2.dequeue();
            if (q1Data !== q2Data) {
                return false;
            }
            this.enqueue(q1Data);
            q2.enqueue(q2Data);    
        }
        return result;
    }
	/**
	 * Determines if the queue is a palindrome (same items forward and backwards).
	 * Avoid indexing queue items directly via bracket notation, instead use the
	 * queue methods for practice.
	 * Use only 1 stack as additional storage, no other arrays or objects.
	 * The queue should be returned to its original order when done.
	 * - Time: O(n^2) quadratic, n = queue length. Quadratic due to dequeue on an
	 *     array queue being O(n).
	 * - Space: O(n) from the stack being used to store the items again.
	 * @returns {boolean}
	 */
	isPalindrome() {
		const compareStack = new Stack();
        
        for(var i = 0; i < this.size(); i++){
            var qData = this.dequeue();
            compareStack.push(qData);
            this.enqueue(qData);
        }

        var result = true;

        for(var i = 0; i < this.size(); i++){
            var qData = this.dequeue();
            var sData = compareStack.pop();
            if (qData !== sData){
                result = false;
            }
            this.enqueue(qData);
        }

        return result;
	}
}
