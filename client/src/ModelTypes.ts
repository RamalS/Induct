export interface TestPoint {
    inputCondition: number;
    samples: number[];
    testPoints: number[];
}

export interface TestPointJson {
    file: File;
}

export interface SelectedInput {
    id: number;
    inputConditionId: number;
    value: number;
}

export interface TestVector {
    id: number;
    isUsed: boolean;
    selectedInput: SelectedInput[];
}

export interface TestVectorJson {
    labels: string[];
    testVectors: TestVector[];
}