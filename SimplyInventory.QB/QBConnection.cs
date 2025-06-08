﻿using System.Xml.Linq;

namespace SimplyInventory.Data.QBSync;

internal class QBConnection(ILogger<QBConnection> logger) : IDisposable
{
    private bool disposedValue;
    private IRequestProcessor5? rp;
    private string? ticket;

    // TODO: Move these into a QBContext class?
    public string? QBFile { get; set; }
    public required string AppId { get; set; } = "QBSDK";

    public XDocument? ProcessRequest(XElement request, int majorVersion = 13, int minorVersion = 0)
    {
        string rq = GenerateRqString(request, majorVersion, minorVersion);

        try
        {
            var result = ProcessRequest(rq);

            if (result != null)
            {
                return XDocument.Parse(result);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error processing request: {request}", request);
        }
        return null;
    }

    public string? ProcessRequest(string request)
    {
        if (Open())
        {
            try
            {
                // RP can not be null if Open was true.
                return rp!.ProcessRequest(ticket, request);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error processing QuickBooks request.");
            }
        }
        return null;
    }

    private bool Open()
    {
        if (IsCorrectFileOpen())
        {
            return true;
        }

        Close();

        try
        {
            rp = new RequestProcessor3Class();
            rp.OpenConnection2(AppId, AppId, QBXMLRPConnectionType.localQBD);
            ticket = rp.BeginSession(QBFile, QBFileMode.qbFileOpenDoNotCare);
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error trying to open connection to QuickBooks.");
            return false;
        }
    }

    private bool IsCorrectFileOpen()
    {
        if (rp == null || string.IsNullOrWhiteSpace(ticket))
        {
            return false;
        }

        try
        {
            var currentFile = rp.GetCurrentCompanyFileName(ticket);

            if (string.IsNullOrWhiteSpace(QBFile))
            {
                return true;
            }

            return Equals(System.IO.Path.GetFullPath(currentFile), System.IO.Path.GetFullPath(QBFile));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error getting current company file from QuickBooks.");
            return false;
        }

    }

    private void Close()
    {
        EndSession();
        CloseConnection();
    }

    private void EndSession()
    {
        try
        {
            if (rp != null && !string.IsNullOrWhiteSpace(ticket))
            {
                rp.EndSession(ticket);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error ending session with QuickBooks.");
        }
        finally
        {
            ticket = null;
        }
    }

    private void CloseConnection()
    {
        try
        {
            if (rp != null)
            {
                rp.CloseConnection();
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error closing connection with QuickBooks.");
        }
        finally
        {
            rp = null;
        }
    }

    private string GenerateRqString(XElement request, int majorVersion, int minorVersion) => $"<?xml \"version=1.0\" encoding=\"utf-8\" ?><?qbxml version=\"{majorVersion}.{minorVersion}\" ?><QBXML><QBXMLMsgsRq onError=\"stopOnError\">{request}</QBXMLMsgsRq></QBXML>";

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // Free unmanaged resources (unmanaged objects) and override finalizer
            Close();

            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // Override finalizer as 'Dispose(bool disposing)' has code to free unmanaged resources
    ~QBConnection()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
