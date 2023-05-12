import React, { useState, useEffect } from "react";
import { Layout, Sidebar, MainContainer } from "../components/Layout";
import { TestPoint } from "../ModelTypes";
import { UploadJson } from "../features/TestPoint/UploadJson/UploadJson";
import { useForm } from "react-hook-form";
import Input from "../components/Input/Input";
import { TableVector } from "../features/TestVector/TableVector/TableVector";
import axios from "axios";

const GeneratedVectors = () => {
  const uploadUrl = "https://dev.digitando-server.com.hr/api/File/ExportAll";
  const upload = () => {
    axios.get(uploadUrl).then((x) => console.log(x.data));
  };

  return (
    <>
      <div className="generated-vectors">
        <Layout>
          <Sidebar>
            <h1 className="text-16 text-bold w-100">
              Yout test vectors have been generated
            </h1>
          </Sidebar>
          <MainContainer>
            <TableVector />
            <button className="generate-button" onClick={upload}>
              Generate
            </button>
          </MainContainer>
        </Layout>
      </div>
    </>
  );
};

export default GeneratedVectors;
