import React, { useState, useEffect } from "react";
import { Layout, Sidebar, MainContainer } from "../components/Layout";
import { TestPoint } from "../ModelTypes";
import { UploadJson } from "../features/TestPoint/UploadJson/UploadJson";
import { useForm } from "react-hook-form";
import Input from "../components/Input/Input";
import { NoData } from "../features/TestPoint/NoData/NoData";

const Main = () => {
  const {
    reset,
    control,
    watch,
    formState: { errors },
    handleSubmit,
  } = useForm<TestPoint>({
    defaultValues: {
      inputCondition: 0,
      samples: [],
      testPoints: [],
    },
  });

  return (
    <>
      <Layout>
        <Sidebar>
          <h1 className="text-16 text-bold w-100">Enter test points</h1>
          {/* <Input
            control={control}
            name="inputCondition"
            label="Input condition"
          /> */}
          <br />
          <UploadJson />

        </Sidebar>
        <MainContainer>
          <NoData />
        </MainContainer>
      </Layout>
    </>
  );
};

export default Main;
