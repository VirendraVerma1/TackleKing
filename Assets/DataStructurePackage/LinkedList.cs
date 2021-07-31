using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using System.IO;

public class LinkedList : MonoBehaviour
{
    public  SimpleNode head;
    public  void add( string data,GameObject go=null)
    {
        SimpleNode newNode = new SimpleNode(data,go);
        
        if (head == null)
            head = newNode;
        else
        {
            SimpleNode temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = newNode;
        }
    }

    public  void add_at_index( string data,int index, GameObject go = null)
    {
        SimpleNode newNode = new SimpleNode(data, go);
        
        if (head == null)
            head = newNode;
        else
        {
            int counter = 0;
            SimpleNode temp = head;
            SimpleNode prev = null;
            while (temp.next != null && counter<index)
            {
                prev = temp;
                temp = temp.next;
                counter++;
            }
            newNode.next = temp.next;
            temp.next = newNode;
        }
    }

    public void pop(int index=-1)
    {
        SimpleNode tempNode = head;
        SimpleNode prev = null;

        if(index==-1)
        {
            while (tempNode.next != null)
            {
                prev = tempNode;
                tempNode = tempNode.next;
            }
            prev.next = null;
        }
        else if(index==0)
        {
            SimpleNode newhead = tempNode.next;
            head = newhead;
        }
        else
        {
            int counter = 0;
            while(tempNode.next!=null)
            {
                if (counter == index - 1)
                    break;

                tempNode = tempNode.next;
                counter++;
            }
            if(tempNode.next!=null&&tempNode.next.next!=null)
                tempNode.next = tempNode.next.next;
        }
        
    }

    public void clear()
    {
        head = null;
    }


    public int length()
    {
        SimpleNode temp = head;
        int counter = 0;
        while(temp!=null)
        {
            temp = temp.next;
            counter++;
        }
        return counter;
    }

    public  SimpleNode get(int index)
    {
        SimpleNode current = head;
        if (index == 0)
            return current;
        int counter = 0;
        while (current != null)
        {
            current = current.next;
            if (counter == index-1)
                break;
            counter++;
        }
        return current;
    }

    public SimpleNode set(int index,string dataa,GameObject go=null)
    {
        SimpleNode current = head;
        if(index==0)
        {
            current.data = dataa;
            current.godata = go;
            return current;
        }

        int counter = 0;
        while (current != null)
        {
            current = current.next;
            if (counter == index - 1)
                break;
            counter++;
        }

        current.data = dataa;
        current.godata = go;

        return current;
    }

    public  int intconvert(SimpleNode newNode)
    {
        SimpleNode tempNode = newNode;
        int numberr=0;
        int number;
        if (int.TryParse(tempNode.data, out number))
            numberr = number;
        return numberr;
    }

    public  float floatconvert(SimpleNode newNode)
    {
        SimpleNode tempNode = newNode;
        float numberr = 0.0f;
        float number;
        if (float.TryParse(tempNode.data, out number))
            numberr = number;
        return numberr;
    }

    void append(string data,GameObject go=null)//complexity  O(n)
    {
        //creating new SampleNode
        SimpleNode new_SampleNode = new SimpleNode(data,go);

        //check head if null then make new SampleNode as a head
        if (head == null)
        {
            head = new_SampleNode;
            return;
        }

        //initialize new SampleNode next to null
        new_SampleNode.next = null;

        //initialize last SampleNode to head
        SimpleNode last_SampleNode = head;

        while (last_SampleNode.next != null)
        {
            last_SampleNode = last_SampleNode.next;
        }


        last_SampleNode.next = new_SampleNode;
        return;
    }

    #region merge sort

    public void manageMergeSort()
    {
        SimpleNode temp = head;

        while (temp.next != null)
        {
            temp = temp.next;
        }
        LinkedList newList = mergeSort(head, temp);

        SimpleNode tempp = newList.head;
        
        head = newList.head;
        
    }

    LinkedList mergeSort(SimpleNode head, SimpleNode tail)
    {
        if (head == tail)
        {
            LinkedList lr = new LinkedList();
            lr.append(head.data,head.godata);
            return lr;
        }

        SimpleNode mid = midNode(head, tail);
        LinkedList fsh = mergeSort(head, mid);
        LinkedList ssh = mergeSort(mid.next, tail);
        LinkedList cl = mergeTwoSortedLists(fsh, ssh);
        return cl;
    }

    SimpleNode midNode(SimpleNode head, SimpleNode tail)
    {
        SimpleNode f = head;
        SimpleNode s = head;

        while (f != tail && f.next != tail)
        {
            f = f.next.next;
            s = s.next;
        }

        return s;
    }

    LinkedList mergeTwoSortedLists(LinkedList l1, LinkedList l2)
    {
        SimpleNode one = l1.head;
        SimpleNode two = l2.head;

        LinkedList res = new LinkedList();
        while (one != null && two != null)
        {
            float onedat = floatconvert(one);
            float twodat = floatconvert(two);
            if (onedat < twodat)
            {
                res.append(one.data,one.godata);
                one = one.next;
            }
            else
            {
                res.append(two.data,two.godata);
                two = two.next;
            }
        }

        while (one != null)
        {
            res.append(one.data,one.godata);
            one = one.next;
        }

        while (two != null)
        {
            res.append(two.data,two.godata);
            two = two.next;
        }

        return res;
    }

    #endregion

}

public class SimpleNode  //node class
{
    public string data;
    public GameObject godata;
    public SimpleNode next;  //its class

    public SimpleNode(string dataa,GameObject go=null) //constructor that stores its single value in data
    {
        data = dataa;
        godata = go;
        next = null;
    }
}