// Copyright (c) 1995-2009 held by the author(s).  All rights reserved.
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions
// are met:
// * Redistributions of source code must retain the above copyright
//    notice, this list of conditions and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright
//   notice, this list of conditions and the following disclaimer
//   in the documentation and/or other materials provided with the
//   distribution.
// * Neither the names of the Naval Postgraduate School (NPS)
//   Modeling Virtual Environments and Simulation (MOVES) Institute
//   (http://www.nps.edu and http://www.MovesInstitute.org)
//   nor the names of its contributors may be used to endorse or
//   promote products derived from this software without specific
//   prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// AS IS AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
// COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
// LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// POSSIBILITY OF SUCH DAMAGE.
//
// Copyright (c) 2008, MOVES Institute, Naval Postgraduate School. All 
// rights reserved. This work is licensed under the BSD open source license,
// available at https://www.movesinstitute.org/licenses/bsd.html
//
// Author: DMcG
// Modified for use with C#:
//  - Peter Smith (Naval Air Warfare Center - Training Systems Division)
//  - Zvonko Bostjancic (Blubit d.o.o. - zvonko.bostjancic@blubit.si)

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using Core;

namespace Dis1998
{
    /// <summary>
    /// Section 5.3.10.4 proivde the means to request a retransmit of a minefield data pdu. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EightByteChunk))]
    public partial class MinefieldResponseNackPdu : MinefieldFamilyPdu, IEquatable<MinefieldResponseNackPdu>
    {
        /// <summary>
        /// Minefield ID
        /// </summary>
        private EntityID _minefieldID = new EntityID();

        /// <summary>
        /// entity ID making the request
        /// </summary>
        private EntityID _requestingEntityID = new EntityID();

        /// <summary>
        /// request ID
        /// </summary>
        private byte _requestID;

        /// <summary>
        /// how many pdus were missing
        /// </summary>
        private byte _numberOfMissingPdus;

        /// <summary>
        /// PDU sequence numbers that were missing
        /// </summary>
        private List<EightByteChunk> _missingPduSequenceNumbers = new List<EightByteChunk>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MinefieldResponseNackPdu"/> class.
        /// </summary>
        public MinefieldResponseNackPdu()
        {
            PduType = (byte)40;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(MinefieldResponseNackPdu left, MinefieldResponseNackPdu right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(MinefieldResponseNackPdu left, MinefieldResponseNackPdu right)
        {
            if (object.ReferenceEquals(left, right))
            {
                return true;
            }

            if (((object)left == null) || ((object)right == null))
            {
                return false;
            }

            return left.Equals(right);
        }

        public override int GetMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.GetMarshalledSize();
            marshalSize += this._minefieldID.GetMarshalledSize();  // this._minefieldID
            marshalSize += this._requestingEntityID.GetMarshalledSize();  // this._requestingEntityID
            marshalSize += 1;  // this._requestID
            marshalSize += 1;  // this._numberOfMissingPdus
            for (int idx = 0; idx < this._missingPduSequenceNumbers.Count; idx++)
            {
                EightByteChunk listElement = (EightByteChunk)this._missingPduSequenceNumbers[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Minefield ID
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "minefieldID")]
        public EntityID MinefieldID
        {
            get
            {
                return this._minefieldID;
            }

            set
            {
                this._minefieldID = value;
            }
        }

        /// <summary>
        /// Gets or sets the entity ID making the request
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "requestingEntityID")]
        public EntityID RequestingEntityID
        {
            get
            {
                return this._requestingEntityID;
            }

            set
            {
                this._requestingEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the request ID
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "requestID")]
        public byte RequestID
        {
            get
            {
                return this._requestID;
            }

            set
            {
                this._requestID = value;
            }
        }

        /// <summary>
        /// Gets or sets the how many pdus were missing
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfMissingPdus method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfMissingPdus")]
        public byte NumberOfMissingPdus
        {
            get
            {
                return this._numberOfMissingPdus;
            }

            set
            {
                this._numberOfMissingPdus = value;
            }
        }

        /// <summary>
        /// Gets the PDU sequence numbers that were missing
        /// </summary>
        [XmlElement(ElementName = "missingPduSequenceNumbersList", Type = typeof(List<EightByteChunk>))]
        public List<EightByteChunk> MissingPduSequenceNumbers
        {
            get
            {
                return this._missingPduSequenceNumbers;
            }
        }

        /// <summary>
        /// Automatically sets the length of the marshalled data, then calls the marshal method.
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        public override void MarshalAutoLengthSet(DataOutputStream dos)
        {
            // Set the length prior to marshalling data
            this.Length = (ushort)this.GetMarshalledSize();
            this.Marshal(dos);
        }

        /// <summary>
        /// Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Marshal(DataOutputStream dos)
        {
            base.Marshal(dos);
            if (dos != null)
            {
                try
                {
                    this._minefieldID.Marshal(dos);
                    this._requestingEntityID.Marshal(dos);
                    dos.WriteUnsignedByte((byte)this._requestID);
                    dos.WriteUnsignedByte((byte)this._missingPduSequenceNumbers.Count);

                    for (int idx = 0; idx < this._missingPduSequenceNumbers.Count; idx++)
                    {
                        EightByteChunk aEightByteChunk = (EightByteChunk)this._missingPduSequenceNumbers[idx];
                        aEightByteChunk.Marshal(dos);
                    }
                }
                catch (Exception e)
                {
                    if (PduBase.TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    this.RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw e;
                    }
                }
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Unmarshal(DataInputStream dis)
        {
            base.Unmarshal(dis);

            if (dis != null)
            {
                try
                {
                    this._minefieldID.Unmarshal(dis);
                    this._requestingEntityID.Unmarshal(dis);
                    this._requestID = dis.ReadUnsignedByte();
                    this._numberOfMissingPdus = dis.ReadUnsignedByte();

                    for (int idx = 0; idx < this.NumberOfMissingPdus; idx++)
                    {
                        EightByteChunk anX = new EightByteChunk();
                        anX.Unmarshal(dis);
                        this._missingPduSequenceNumbers.Add(anX);
                    }
                }
                catch (Exception e)
                {
                    if (PduBase.TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    this.RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// This allows for a quick display of PDU data.  The current format is unacceptable and only used for debugging.
        /// This will be modified in the future to provide a better display.  Usage: 
        /// pdu.GetType().InvokeMember("Reflection", System.Reflection.BindingFlags.InvokeMethod, null, pdu, new object[] { sb });
        /// where pdu is an object representing a single pdu and sb is a StringBuilder.
        /// Note: The supplied Utilities folder contains a method called 'DecodePDU' in the PDUProcessor Class that provides this functionality
        /// </summary>
        /// <param name="sb">The StringBuilder instance to which the PDU is written to.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<MinefieldResponseNackPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<minefieldID>");
                this._minefieldID.Reflection(sb);
                sb.AppendLine("</minefieldID>");
                sb.AppendLine("<requestingEntityID>");
                this._requestingEntityID.Reflection(sb);
                sb.AppendLine("</requestingEntityID>");
                sb.AppendLine("<requestID type=\"byte\">" + this._requestID.ToString(CultureInfo.InvariantCulture) + "</requestID>");
                sb.AppendLine("<missingPduSequenceNumbers type=\"byte\">" + this._missingPduSequenceNumbers.Count.ToString(CultureInfo.InvariantCulture) + "</missingPduSequenceNumbers>");
                for (int idx = 0; idx < this._missingPduSequenceNumbers.Count; idx++)
                {
                    sb.AppendLine("<missingPduSequenceNumbers" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"EightByteChunk\">");
                    EightByteChunk aEightByteChunk = (EightByteChunk)this._missingPduSequenceNumbers[idx];
                    aEightByteChunk.Reflection(sb);
                    sb.AppendLine("</missingPduSequenceNumbers" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</MinefieldResponseNackPdu>");
            }
            catch (Exception e)
            {
                    if (PduBase.TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    this.RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw e;
                    }
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this == obj as MinefieldResponseNackPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(MinefieldResponseNackPdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._minefieldID.Equals(obj._minefieldID))
            {
                ivarsEqual = false;
            }

            if (!this._requestingEntityID.Equals(obj._requestingEntityID))
            {
                ivarsEqual = false;
            }

            if (this._requestID != obj._requestID)
            {
                ivarsEqual = false;
            }

            if (this._numberOfMissingPdus != obj._numberOfMissingPdus)
            {
                ivarsEqual = false;
            }

            if (this._missingPduSequenceNumbers.Count != obj._missingPduSequenceNumbers.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._missingPduSequenceNumbers.Count; idx++)
                {
                    if (!this._missingPduSequenceNumbers[idx].Equals(obj._missingPduSequenceNumbers[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            return ivarsEqual;
        }

        /// <summary>
        /// HashCode Helper
        /// </summary>
        /// <param name="hash">The hash value.</param>
        /// <returns>The new hash value.</returns>
        private static int GenerateHash(int hash)
        {
            hash = hash << (5 + hash);
            return hash;
        }

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            int result = 0;

            result = GenerateHash(result) ^ base.GetHashCode();

            result = GenerateHash(result) ^ this._minefieldID.GetHashCode();
            result = GenerateHash(result) ^ this._requestingEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._requestID.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfMissingPdus.GetHashCode();

            if (this._missingPduSequenceNumbers.Count > 0)
            {
                for (int idx = 0; idx < this._missingPduSequenceNumbers.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._missingPduSequenceNumbers[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
