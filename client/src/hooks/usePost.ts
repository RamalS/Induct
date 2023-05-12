
import { useEffect, useState } from "react";

export const usePost = <T>(promise: () => Promise<T>, message?: object) => {
    const [response, setResponse] = useState<T>();
    let finishFunc: () => Promise<void> | void | undefined;

    useEffect(() => {
        const execute = async () => {
            if (response !== undefined) {
                await finishFunc?.();
            }
        }

        execute();
    }, [response])

    const send = async () => {
        const resPromise = promise();
        const res = await resPromise;
        setResponse(res);
    }

    const onFinish = async (finish: () => Promise<void> | void | undefined) => {
        finishFunc = finish;
    }

    return [response, send, onFinish] as const;
}