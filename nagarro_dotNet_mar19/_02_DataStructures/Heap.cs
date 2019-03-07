using System;
using System.Collections.Generic;
using System.Text;
using utils;

namespace nagarro_dotNet_mar19
{
    namespace datastructures
    {
        class PriorityQueue
        {
            private List<int> heap_; // TODO
            private int count_;
            private int TOPIDX = 1;

            private int parent(int idx) { return idx / 2; }
            private int left(int idx) { return idx * 2; }
            private int right(int idx) { return idx * 2 + 1; }

            public int Count
            {
                get { return count_; }
            }


            public PriorityQueue()
            {
                heap_ = new List<int>();
                heap_.Add(int.MaxValue);
                count_ = 0;
            }

            public void insert(int element)
            {
                heap_.Add(element);
                count_++;
                int elementIdx = count_;
                while (parent(elementIdx) > TOPIDX && heap_[elementIdx] > heap_[parent(elementIdx)])
                {
                    //Utils.Swap(ref heap_[parent(elementIdx)], ref heap_[elementIdx]);
                    int tmp = heap_[parent(elementIdx)];
                    heap_[parent(elementIdx)] = heap_[elementIdx];
                    heap_[elementIdx] = tmp;
                    elementIdx = parent(elementIdx);
                }

            }

            public int Remove()
            {
                int retVal = Top();
                heap_[TOPIDX] = heap_[count_];
                heap_.RemoveAt(count_);
                count_--;
                heapify(TOPIDX);
                return retVal;
            }

            private void heapify(int idx)
            {
                int maxIdx = idx;
                if (left(idx) <= count_ && heap_[left(idx)] > heap_[idx])
                {
                    maxIdx = left(idx);
                }

                if (right(idx) <= count_ && heap_[right(idx)] > heap_[maxIdx])
                {
                    maxIdx = right(idx);
                }

                if (maxIdx != idx)
                {
                    //swap and heapify
                    int tmp = heap_[maxIdx];
                    heap_[maxIdx] = heap_[idx];
                    heap_[idx] = tmp;
                    heapify(maxIdx);
                }
            }


            public int Top()
            {
                try
                {
                    return heap_[TOPIDX];
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    return -1;
                    //throw;
                }
            }
        }

        public class Heap
        {
            public static void main()
            {
                PriorityQueue pq = new PriorityQueue();
                // perform operations
                pq.insert(1);
                pq.insert(2);
                pq.insert(-2);
                Console.Write(pq.Remove());
                Console.Write(pq.Remove());
                pq.insert(40);
                Console.Write(pq.Remove());
            }

        }

    }
}