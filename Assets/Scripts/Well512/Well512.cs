using UnityEngine;
using System.Collections;
using System;

public class Well512 {
	private UInt32[] state = new uint[16];
	private UInt32 index = 0;

	public Well512() {
		index = (UInt32)UnityEngine.Random.Range(0, 15);

		for (int i = 0; i < 16; i++)
			state[i] = (UInt32)UnityEngine.Random.Range(0, 100000);

//		System.Random random = new System.Random((int)DateTime.Now.Ticks);
//
//		for (int i = 0; i < 16; i++)
//			state[i] = (uint)random.Next();
	}

	public Well512(ulong[] seeds, UInt32 indexVal) {
		index = indexVal > 15 ? (indexVal % 16) : indexVal;

		for (int i = 0; i < 16; i++)
			state[i] = (UInt32)seeds[i];
	}

	public UInt32 Next(UInt32 minValue, UInt32 maxValue) {
		return (UInt32)((Next() % (maxValue - minValue)) + minValue);
	}
	
	public UInt32 Next(UInt32 maxValue) {
		return Next() % maxValue;
	}

	public UInt32 Next(UInt32[] probability) {
		UInt32 percentSum = 0;

		for (int i = 0; i < probability.Length; ++i)
			percentSum += probability[i];

		System.Diagnostics.Debug.Assert(percentSum > 99 && percentSum <= 101);

		UInt32 randValue = Next(0, percentSum);

		for (int num = 0; num < probability.Length; ++num) {
			if (randValue < probability[num])
				return (UInt32)num;

			randValue -= probability[num];
		}

		return 0;
	}
	
	public UInt32 Next() {
		UInt32 a, b, c, d;
		
		a = state[index];
		c = state[(index + 13) & 15];
		b = a ^ c ^ (a << 16) ^ (c << 15);
		c = state[(index + 9) & 15];
		c ^= (c >> 11);
		a = state[index] = b ^ c;
		d = a ^ ((a << 5) & 0xda442d24U);
		index = (index + 15) & 15;
		a = state[index];
		state[index] = a ^ b ^ d ^ (a << 2) ^ (b << 18) ^ (c << 28);
		
		return state[index];
	}
}
