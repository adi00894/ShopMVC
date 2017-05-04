using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcSiteMapProvider;
using PraktyczneKursy.DAL;
using PraktyczneKursy.Models;

namespace PraktyczneKursy.Infrastructure
{
    public class KursySzczegolyDinamicNodeProvider : DynamicNodeProviderBase
    {
        private  KursyKontext _db = new KursyKontext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();

            foreach (Kurs kurs in _db.Kursy)
            {
                DynamicNode node = new DynamicNode();
                node.Title = kurs.TytulKursu;
                node.Key="Kurs_"+kurs.KursId;
                node.ParentKey="Kategoria_"+kurs.KategoriaId;
                node.RouteValues.Add("id",kurs.KursId);

                returnValue.Add(node);
            }

            return returnValue;
        }
    }
}