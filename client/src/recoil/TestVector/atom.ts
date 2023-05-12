import { atom } from 'recoil';
import { TestVector, TestVectorJson } from '../../ModelTypes';

export const withTestVectors = atom({
    key: 'testVectors',
    default: {labels: [], testVectors: []} as TestVectorJson,
});