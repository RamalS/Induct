import React, { useState, useEffect } from "react";

type Props = {
  children: React.ReactNode;
};

export const Sidebar = ({ children }: Props) => {
  return (
    <>
      <div className="sidebar">{children}</div>
    </>
  );
};
