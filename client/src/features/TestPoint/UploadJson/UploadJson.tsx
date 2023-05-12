import React, { useState, useEffect } from "react";
import { FileForm } from "../../../components/FileForm/FileForm";
import { useForm } from "react-hook-form";
import { TestPointJson, TestVectorJson } from "../../../ModelTypes";
import { File } from "../../../components/File/File";
import axios from "axios";
import { useRecoilState } from "recoil";
import { withTestVectors } from "../../../recoil/TestVector/atom";
import { useNavigate } from "react-router-dom";
import { TestVector } from "../../../ModelTypes";

export const UploadJson = () => {
  const uploadUrl = "https://dev.digitando-server.com.hr/api/Data/UploadFile";
  const [vectors, setVectors] = useRecoilState(withTestVectors);
  const navigate = useNavigate();

  const uploadJsonAsync = async (model: TestPointJson) => {
    if (model.file === undefined) {
      return [];
    }

    console.log(model.file);

    const formData = new FormData();
    formData.append("files", model.file);

    console.log(formData, model, "formData model");

    return await axios
      .post<any>(uploadUrl, formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      })
      .then((x) => x.data);
  };

  useEffect(() => {
    console.log(vectors, "vectors");
  }, [vectors]);

  const {
    reset,
    control,
    watch,
    formState: { errors },
    handleSubmit,
    setValue,
  } = useForm<TestPointJson>({
    defaultValues: {},
  });

  return (
    <>
      <div>
        {/* <FileForm control={control} name="file" /> */}
        <File
          name="file"
          onChange={(file) => {
            console.log(file, "file");
            uploadJsonAsync({ file: file as File }).then((x) => {
              console.log(x, "x");
              setVectors(x as TestVectorJson);
              navigate("/generated-vectors");
            });
          }}
        />
      </div>
    </>
  );
};
