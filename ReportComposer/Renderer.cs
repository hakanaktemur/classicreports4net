using System;
using System.Collections.Generic;
using System.Text;

namespace JDJ.ClassicReport.ReportComposer
{
    using JDJ.ClassicReport.Common;
    using JDJ.ClassicReport.Common.Widgets;

    class Renderer
    {
        List<Band> _bands;
        ReportComposer _composer;

        public Renderer(ReportComposer composer, List<Band> bands)
        {
            _composer = composer;
            _bands = bands;
        }

        virtual public void Render()
        {
            if (isOverflow())
            {
                _composer.RenderPageFooterSection();
                _composer.NewPage();
                _composer.RenderPageHeaderSection();
            }
            _composer.MovePrevious();
            Write();
            _composer.MoveNext();
        }

        protected void Write()
        {
            foreach (Band band in _bands)
            {
                foreach (BaseWidget widget in band.Items)
                {
                    //_composer.UpdateNonAggregate(widget);
                    widget.Write(_composer.CurrentPage);
                }
                _composer.CurrentPage.WriteLine();
            }
        }

        protected bool isOverflow()
        {
            return _composer.CurrentPage.CurrentRow + _bands.Count > _composer.Footer;
        }
    }
}
