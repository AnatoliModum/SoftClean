﻿using AppSoftClean.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftClean.Data.Infraestructure
{
    interface IProdQuimRepository
    {
        bool InsertarQuimico(AdmProdQuim Quimico);
        List<AdmProdQuim> GetAllQuimicos();
        List<AdmProdQuim> GetQuimicoByID(int id);
        bool EliminarQuimico(int id);
        bool ActualizarQuimico(AdmProdQuim Quimico);
    }
}