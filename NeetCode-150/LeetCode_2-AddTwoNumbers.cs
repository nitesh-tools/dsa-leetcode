namespace dsa_leetcode.NeetCode_150;

/// <summary>
/// https://leetcode.com/problems/add-two-numbers
/// </summary>
internal class LeetCode_2_AddTwoNumbers
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode? newNode = null;
        ListNode? head = null;
        int carry = 0;

        while (l1 != null && l2 != null)
        {
            Tuple<int, int> result = FindSumAndCarry(l1.val, l2.val, carry);
            carry = result.Item2;

            ListNode temp = new ListNode(result.Item1);
            if (newNode == null)
            {
                newNode = temp;
                head = newNode;
            }
            else
            {
                newNode.next = temp;
                newNode = newNode.next;
            }
            l1 = l1.next;
            l2 = l2.next;
        }

        if (l1 != null)
        {
            AddRemainingNodes(ref l1, ref newNode, ref head, ref carry);
        }

        if (l2 != null)
        {
            AddRemainingNodes(ref l2, ref newNode, ref head, ref carry);
        }

        if (carry != 0)
        {
            newNode.next = new ListNode(carry);
        }

        return head;
    }

    public static void Run()
    {
        ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
        ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4)));

        var obj = new LeetCode_2_AddTwoNumbers();
        ListNode l3 = obj.AddTwoNumbers(l1, l2);
        obj.PrintList(l3);
    }

    private void PrintList(ListNode node)
    {
        if (node == null) return;

        while (node != null)
        {
            Console.WriteLine(node.val);
            node = node.next;
        }
    }

    private Tuple<int, int> FindSumAndCarry(int value1, int value2, int carry)
    {
        var sum = value1 + value2 + carry;
        var res = sum > 9 ? sum % 10 : sum;
        carry = sum > 9 ? 1 : 0;
        return Tuple.Create(res, carry);
    }

    private void AddRemainingNodes(ref ListNode currentNode, ref ListNode? newNode, ref ListNode? head, ref int carry)
    {
        while (currentNode != null)
        {
            Tuple<int, int> result = FindSumAndCarry(currentNode.val, 0, carry);
            carry = result.Item2;

            ListNode temp = new ListNode(result.Item1);
            if (newNode == null)
            {
                newNode = temp;
                head = newNode;
            }
            else
            {
                newNode.next = temp;
                newNode = newNode.next;
            }

            currentNode = currentNode.next;
        }
    }
}
