import React, { useState, useEffect } from "react";
import { Layout, Sidebar, MainContainer } from "../components/Layout";
import { TestPoint } from "../ModelTypes";
import { useForm } from "react-hook-form";
import Input from "../components/Input/Input";

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
          <p className="text-16 text-bold">Enter test points</p>
          <Input
            control={control}
            name="inputCondition"
            label="Input condition"
          />
        </Sidebar>
        <MainContainer>
          <h1>Main</h1>
        </MainContainer>
      </Layout>
    </>
  );
};

export default Main;
